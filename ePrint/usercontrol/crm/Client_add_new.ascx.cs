using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Department;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
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
using Telerik.Web.UI;

namespace ePrint.usercontrol.crm
{
    public partial class Client_add_new : System.Web.UI.UserControl
    {
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

        static Client_add_new()
        {
            Client_add_new.strFinalData = string.Empty;
        }

        public Client_add_new()
        {
        }

        protected void btncancel_onclick(object sender, EventArgs e)
        {
            try
            {
                if (this.sender1.ToLower() == "popup")
                {
                    this.pnlWinClose2.Visible = true;
                }
            }
            catch
            {
            }
            if (base.Request.Params["type"] == null)
            {
                QueryString queryString = new QueryString()
            {
                { "clientid", this.hid_ClientID.Value },
                { "isnew", "2" },
                { "bypass", "1" },
                { "type", this.companytype }
            };
                string str = string.Concat("client/client_detail.aspx", this.jID, this.InvID);
                QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                str = string.Concat(str, queryString1.ToString());
                base.Response.Redirect(string.Concat(this.strSitepath, str));
            }
            else
            {
                if (this.postback == "")
                {
                    HttpResponse response = base.Response;
                    string[] invID = new string[] { this.strSitepath, "client/client_view.aspx?type=", this.companytype, this.jID, this.InvID };
                    response.Redirect(string.Concat(invID));
                    return;
                }
                if (this.postback == "inv")
                {
                    if (this.mode != "edit")
                    {
                        this.pnl_supplier_add_frominventory.Visible = true;
                    }
                    else
                    {
                        HttpResponse httpResponse = base.Response;
                        string[] strArrays = new string[] { this.strSitepath, "warehouse/inventory_add.aspx?type=", this.mode, "&id=", this.id, this.jID, this.InvID };
                        httpResponse.Redirect(string.Concat(strArrays));
                    }
                }
                else if (this.postback == "settings")
                {
                    if (this.mode != "edit")
                    {
                        HttpResponse response1 = base.Response;
                        object[] clientID = new object[] { this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx?&clientID=", this.ClientID, "&from=", this.RedirectTo, this.jID, this.InvID };
                        response1.Redirect(string.Concat(clientID));
                    }
                    else
                    {
                        HttpResponse httpResponse1 = base.Response;
                        object[] objArray = new object[] { this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx?action=", this.mode, "&id=", this.id, "&clientID=", this.ClientID, "&from=", this.RedirectTo, this.jID, this.InvID };
                        httpResponse1.Redirect(string.Concat(objArray));
                    }
                }
                else if (this.postback == "store")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "warehouse/item_finishedgoods_add.aspx?page=store", this.jID, this.InvID));
                }
                else if (this.postback == "item")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "warehouse/item_finishedgoods_add.aspx?page=item", this.jID, this.InvID));
                }
                if (this.postback == "estimate")
                {
                    if (this.mode != "edit")
                    {
                        HttpResponse response2 = base.Response;
                        string[] invID1 = new string[] { this.strSitepath, "estimates/estimates_add.aspx?type=", this.mode, this.jID, this.InvID };
                        response2.Redirect(string.Concat(invID1));
                    }
                    else
                    {
                        HttpResponse httpResponse2 = base.Response;
                        string[] strArrays1 = new string[] { this.strSitepath, "estimates/estimates_add.aspx?type=", this.mode, "&estid=", this.id, this.jID, this.InvID };
                        httpResponse2.Redirect(string.Concat(strArrays1));
                    }
                }
                if (this.postback == "job")
                {
                    if (this.mode != "edit")
                    {
                        HttpResponse response3 = base.Response;
                        string[] invID2 = new string[] { this.strSitepath, "jobs/job_add.aspx?type=", this.mode, this.jID, this.InvID };
                        response3.Redirect(string.Concat(invID2));
                    }
                    else
                    {
                        HttpResponse httpResponse3 = base.Response;
                        string[] strArrays2 = new string[] { this.strSitepath, "jobs/job_add.aspx?type=", this.mode, "&estid=", this.id, this.jID, this.InvID };
                        httpResponse3.Redirect(string.Concat(strArrays2));
                    }
                }
                if (this.postback == "invoice")
                {
                    if (this.mode != "edit")
                    {
                        if (base.Request.Params["type"].ToString().ToLower() == "supplier")
                        {
                            ScriptManager.RegisterStartupScript(this, base.GetType(), "", "javascript:Close();", true);
                            return;
                        }
                        HttpResponse response4 = base.Response;
                        string[] invID3 = new string[] { this.strSitepath, "invoice/invoices_add.aspx?type=", this.mode, this.jID, this.InvID };
                        response4.Redirect(string.Concat(invID3));
                        return;
                    }
                    if (base.Request.Params["type"].ToString().ToLower() == "supplier")
                    {
                        ScriptManager.RegisterStartupScript(this, base.GetType(), "", "javascript:Close();", true);
                        return;
                    }
                    HttpResponse httpResponse4 = base.Response;
                    string[] strArrays3 = new string[] { this.strSitepath, "invoice/invoices_add.aspx?type=", this.mode, "&estid=", this.id, this.jID, this.InvID };
                    httpResponse4.Redirect(string.Concat(strArrays3));
                    return;
                }
                if (this.postback == "purchase")
                {
                    if (this.mode != "edit")
                    {
                        HttpResponse response5 = base.Response;
                        string[] invID4 = new string[] { this.strSitepath, "purchase/purchase_add.aspx?type=", this.mode, this.jID, this.InvID };
                        response5.Redirect(string.Concat(invID4));
                        return;
                    }
                    HttpResponse httpResponse5 = base.Response;
                    string[] strArrays4 = new string[] { this.strSitepath, "purchase/purchase_add.aspx?type=", this.mode, "&id=", this.id, this.jID, this.InvID };
                    httpResponse5.Redirect(string.Concat(strArrays4));
                    return;
                }
                if (this.postback == "delivery")
                {
                    if (this.mode != "edit")
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "delivery/delivery_add.aspx", this.jID, this.InvID));
                        return;
                    }
                    HttpResponse response6 = base.Response;
                    string[] invID5 = new string[] { this.strSitepath, "delivery/delivery_add.aspx?type=", this.mode, "&id=", this.id, this.jID, this.InvID };
                    response6.Redirect(string.Concat(invID5));
                    return;
                }
                if (this.postback == "ContactAdd")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "client/contact_add.aspx", this.jID, this.InvID));
                    return;
                }
                if (this.postback == "othercost")
                {
                    if (this.mode != "edit")
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "settings/othercost_add.aspx", this.jID, this.InvID));
                        return;
                    }
                    HttpResponse httpResponse6 = base.Response;
                    string[] strArrays5 = new string[] { this.strSitepath, "settings/othercost_add.aspx?type=", this.mode, "&id=", this.id, this.jID, this.InvID };
                    httpResponse6.Redirect(string.Concat(strArrays5));
                    return;
                }
                if (this.postback == "estimates" || this.postback == "jobs" || this.postback == "invoice")
                {
                    this.pnlWinClose2.Visible = true;
                    return;
                }
                if (this.postback == "accounts")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "Accounts/accounts_new_create.aspx?type=Customer", this.jID, this.InvID));
                    return;
                }
                if (this.postback == "setting1")
                {
                    ScriptManager.RegisterStartupScript(this, base.GetType(), "", "javascript:Close();", true);
                    return;
                }
                if (this.postback == "estimate1")
                {
                    ScriptManager.RegisterStartupScript(this, base.GetType(), "", "javascript:Close();", true);
                    return;
                }
            }
        }

        protected void btnsave_onclick(object sender, EventArgs e)
        {
            string[] invID;
            object[] str;
            string empty = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            foreach (RadComboBoxItem item in this.ddl_type.Items)
            {
                if (!((CheckBox)item.FindControl("chk1")).Checked)
                {
                    continue;
                }
                empty = string.Concat(empty, item.Text, "±");
                empty1 = string.Concat(empty1, item.Value, ",");
                str1 = string.Concat(str1, item.Text, ", ");
            }
            if (empty1 == "")
            {
                empty1 = "0,";
                empty = "±";
                str1 = ", ";
            }
            string[] strArrays = empty1.ToString().Split(new char[] { ',' });
            string[] strArrays1 = empty.ToString().Split(new char[] { '±' });
            empty1 = empty1.Substring(0, empty1.Length - 1);
            str1 = str1.Substring(0, str1.Length - 2);
            bool @checked = this.chk_defaultdeliveryaddress.Checked;
            bool flag = this.chk_defaultinvoiceaddress.Checked;
            string empty2 = string.Empty;
            int num = 0;
            if (this.chkcarrier.Checked)
            {
                num = 1;
            }
            bool flag1 = false;
            flag1 = (!this.ChkRoyalityFree.Checked ? false : true);
            string str2 = "1/1/1900";
            if (this.txt_acopened.Text != "")
            {
                str2 = this.comncls.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txt_acopened.Text);
            }
            DateTime now = DateTime.Now;
            this.txt_profitmargin.Text = this.txt_profitmargin.Text.Replace("%", "");
            this.txt_profitmargin.Text = this.txt_profitmargin.Text.Replace(",", "");
            empty2 = (this.txt_profitmargin.Text == "" ? Convert.ToString(0) : this.basecls.SpecialEncode(this.txt_profitmargin.Text));
            if (this.postback == "estimate" || this.postback == "estimates")
            {
                this.rdProspect.Checked = true;
                if (this.rdCustomer.Checked)
                {
                    this.lblCompanyType.Text = "Customer";
                }
                else if (this.rdProspect.Checked)
                {
                    this.lblCompanyType.Text = "Prospect";
                }
            }
            if (base.Request.QueryString["item"] != null && base.Request.QueryString["item"] == "Outwork")
            {
                this.lblCompanyType.Text = "Supplier";
                this.lblCompanyType.Visible = true;
            }
            if (base.Session["Flag"] == null && this.hdn_Referencedby.Value == "")
            {
                base.Session["Flag"] = false;
            }
            if (base.Session["Flag"] == null && this.hdn_Referencedby.Value != "")
            {
                base.Session["Flag"] = true;
            }
            if (base.Request.Params["type"] != null)
            {
                if (this.ddl_Deliverycountry.SelectedItem.Text.ToString().Equals("--- Select ---"))
                {
                    foreach (DataRow row in SettingsBasePage.settings_companyprofile_select(this.CompanyID).Rows)
                    {
                        this.ddl_Deliverycountry.SelectedIndex = this.ddl_Deliverycountry.Items.IndexOf(this.ddl_Deliverycountry.Items.FindByText(row["Country"].ToString()));
                    }
                }
                if (base.Session["Flag"] != null)
                {
                    if (base.Session["Flag"].ToString().ToLower() != "true")
                    {
                        this.retClientID = CompanyBasePage.Company_InsertUpdate(this.CompanyID, Convert.ToInt32(this.hid_ClientID.Value), this.lblCompanyType.Text, this.basecls.SpecialEncode(this.txt_companyname.Text), this.basecls.SpecialEncode(this.txt_companyalias.Text), this.basecls.SpecialEncode(this.ddl_type.SelectedValue), this.basecls.SpecialEncode(this.ddl_status.SelectedValue), this.basecls.SpecialEncode(this.txt_accountno.Text), this.basecls.SpecialEncode(this.txt_email.Text), this.basecls.SpecialEncode(this.txt_url.Text), this.basecls.SpecialEncode(this.txt_creditlimit.Text), this.basecls.SpecialEncode(this.txt_creditref.Text), Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_tax1.SelectedValue)), Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_tax2.SelectedValue)), this.basecls.SpecialEncode(this.txt_taxregno.Text), this.basecls.SpecialEncode(this.ddl_PaymentTerms.SelectedValue), this.basecls.SpecialEncode(this.txt_companyno.Text), empty2, Convert.ToDateTime(str2), this.basecls.SpecialEncode(this.txt_bankcode.Text), this.basecls.SpecialEncode(this.txt_bankacno.Text), this.basecls.SpecialEncode(this.txt_accountname.Text), Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_salesperson.SelectedValue)), this.basecls.SpecialEncode(this.txt_taxnumber.Text), this.basecls.SpecialEncode(this.txt_balance.Text), this.basecls.SpecialEncode(this.txt_description.Text), now, this.UserID, Convert.ToInt32(this.ddl_Referencedby.SelectedValue), num, flag1, this.basecls.SpecialEncode(empty1), this.basecls.SpecialEncode(str1), chkTaxPrecedence.Checked);
                    }
                    else
                    {
                        this.retClientID = CompanyBasePage.Company_InsertUpdate(this.CompanyID, Convert.ToInt32(this.hid_ClientID.Value), this.lblCompanyType.Text, this.basecls.SpecialEncode(this.txt_companyname.Text), this.basecls.SpecialEncode(this.txt_companyalias.Text), this.basecls.SpecialEncode(this.ddl_type.SelectedValue), this.basecls.SpecialEncode(this.ddl_status.SelectedValue), this.basecls.SpecialEncode(this.txt_accountno.Text), this.basecls.SpecialEncode(this.txt_email.Text), this.basecls.SpecialEncode(this.txt_url.Text), this.basecls.SpecialEncode(this.txt_creditlimit.Text), this.basecls.SpecialEncode(this.txt_creditref.Text), Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_tax1.SelectedValue)), Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_tax2.SelectedValue)), this.basecls.SpecialEncode(this.txt_taxregno.Text), this.basecls.SpecialEncode(this.ddl_PaymentTerms.SelectedValue), this.basecls.SpecialEncode(this.txt_companyno.Text), empty2, Convert.ToDateTime(str2), this.basecls.SpecialEncode(this.txt_bankcode.Text), this.basecls.SpecialEncode(this.txt_bankacno.Text), this.basecls.SpecialEncode(this.txt_accountname.Text), Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_salesperson.SelectedValue)), this.basecls.SpecialEncode(this.txt_taxnumber.Text), this.basecls.SpecialEncode(this.txt_balance.Text), this.basecls.SpecialEncode(this.txt_description.Text), now, this.UserID, Convert.ToInt32(this.hdn_Referencedby.Value), num, flag1, this.basecls.SpecialEncode(empty1), this.basecls.SpecialEncode(str1), chkTaxPrecedence.Checked);
                    }
                }
                this.hid_ClientID.Value = this.retClientID.ToString();
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    CompanyBasePage.crm_clientType_add((long)this.CompanyID, (long)this.retClientID, Convert.ToInt64(this.basecls.SpecialEncode(strArrays[i])), this.basecls.SpecialEncode(strArrays1[i]));
                }
                long num1 = (long)0;
                long num2 = Convert.ToInt64(this.retClientID);
                string str3 = this.basecls.SpecialEncode(this.txt_Deliveryaddr1.Text);
                string str4 = this.basecls.SpecialEncode(this.txt_Deliveryaddr3.Text);
                string str5 = this.basecls.SpecialEncode(this.txt_Deliveryaddr4.Text);
                string str6 = this.basecls.SpecialEncode(this.txt_Deliveryaddr5.Text);
                string str7 = this.basecls.SpecialEncode(this.ddl_Deliverycountry.SelectedItem.Text);
                string str8 = this.basecls.SpecialEncode(this.txt_Deliveryphone.Text);
                string str9 = this.basecls.SpecialEncode(this.txt_Deliveryfax.Text);
                string str10 = this.basecls.SpecialEncode(this.txt_url.Text);
                int userID = this.UserID;
                DateTime dateTime = DateTime.Now;
                //this.retAddressID = CompanyBasePage.CompanyDefaultAddress_InsertUpdate(num1, num2, str3, str4, str5, str6, str7, str8, str9, str10, userID, dateTime.ToString(), "Main", this.basecls.SpecialEncode(this.txt_Deliveryaddr2.Text), this.basecls.SpecialEncode(this.txt_email.Text), "N");
                this.retAddressID = CompanyBasePage.CompanyDefaultAddress_InsertUpdate(num1, num2, str3, str4, str5, str6, str7, str8, str9, str10, userID, dateTime.ToString(), "", this.basecls.SpecialEncode(this.txt_Deliveryaddr2.Text), this.basecls.SpecialEncode(this.txt_email.Text), "N");
                this.rtnDeptID = DepartmentBaseClass.departmentInsert((long)0, "Main", this.retClientID, this.retContactID, this.UserID, Convert.ToInt32(this.retAddressID), "A", DateTime.Now, DateTime.Now, this.CompanyID, (long)Convert.ToInt32(this.retAddressID), 0, 0, "N", Convert.ToBoolean(0), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", (long)0, "", "", false, "");
                if (this.Chkcreate_identical_contact.Checked)
                {
                    string empty3 = string.Empty;
                    string empty4 = string.Empty;
                    string empty5 = string.Empty;
                    string empty6 = string.Empty;
                    string text = this.txt_companyname.Text;
                    string[] strArrays2 = text.Split(new char[] { ' ' });
                    try
                    {
                        if ((int)strArrays2.Length <= 0)
                        {
                            empty3 = text;
                        }
                        else if ((int)strArrays2.Length > 2)
                        {
                            empty3 = strArrays2[0];
                            empty4 = strArrays2[1];
                            for (int j = 2; j < (int)strArrays2.Length; j++)
                            {
                                empty5 = string.Concat(empty5, strArrays2[j], " ");
                            }
                        }
                        else if ((int)strArrays2.Length != 2)
                        {
                            empty3 = strArrays2[0];
                        }
                        else
                        {
                            empty3 = strArrays2[0];
                            empty5 = strArrays2[1];
                        }
                    }
                    catch
                    {
                    }
                    empty6 = string.Concat(empty3, "_", empty5);
                    this.retContactID = CompanyBasePage.Contact_InsertUpdate(this.CompanyID, 0, Convert.ToInt32(this.retClientID), "", this.basecls.SpecialEncode(empty3.ToString()), this.basecls.SpecialEncode(empty4.ToString()), this.basecls.SpecialEncode(empty5.ToString()), this.basecls.SpecialEncode(empty6.ToString()), this.basecls.SpecialEncode(this.txt_companyname.Text), "", "", this.basecls.SpecialEncode(this.txt_Deliveryphone.Text), "", this.basecls.SpecialEncode(this.txt_email.Text), 0, this.UserID, this.rtnDeptID, this.basecls.SpecialEncode(this.txt_Deliveryfax.Text), Convert.ToInt32(this.retAddressID), true, 0, 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", false, DateTime.Now);
                }
                try
                {
                    if (this.sender1.ToLower() == "popup")
                    {
                        if (this.postback == null || !(this.postback.ToLower() == "purchase"))
                        {
                            this.pnlWinClose1.Visible = true;
                        }
                        else
                        {
                            this.pnl_Supp_Purchase.Visible = true;
                        }
                    }
                }
                catch
                {
                }
                if (this.post != "" && (this.post == "estimates" || this.type == "inventory"))
                {
                    if (this.mode != "add")
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "estimates/estimate_warehouse.aspx?page=FrmWareList", this.jID, this.InvID));
                    }
                    else
                    {
                        HttpResponse response = base.Response;
                        invID = new string[] { this.strSitepath, "estimates/estimate_warehouse.aspx?page=FrmWareList&type=", this.mode, "&estid=", this.id, this.jID, this.InvID };
                        response.Redirect(string.Concat(invID));
                    }
                }
                if (this.postback == "")
                {
                    QueryString queryString = new QueryString()
                {
                    { "clientid", this.retClientID.ToString() },
                    { "isnew", "2" },
                    { "bypass", "1" },
                    { "type", this.companytype },
                    { "suc", "in" }
                };
                    string str11 = "client/client_detail.aspx";
                    QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                    str11 = string.Concat(str11, queryString1.ToString());
                    base.Response.Redirect(string.Concat(this.strSitepath, str11));
                }
                else
                {
                    if (this.postback == "accounts")
                    {
                        if (this.mode != "edit")
                        {
                            base.Response.Redirect(string.Concat(this.strSitepath, "Accounts/accounts_new_create.aspx?type=Customer", this.jID, this.InvID));
                            return;
                        }
                        HttpResponse httpResponse = base.Response;
                        string[] invID1 = new string[] { this.strSitepath, "Accounts/accounts_new_create.aspx?type=", this.mode, "&id=", this.id, this.jID, this.InvID };
                        httpResponse.Redirect(string.Concat(invID1));
                        return;
                    }
                    if (this.postback == "inv")
                    {
                        this.pnl_supplier_add_frominventory.Visible = true;
                        return;
                    }
                    if (this.postback == "store")
                    {
                        if (this.mode != "edit")
                        {
                            base.Response.Redirect(string.Concat(this.strSitepath, "warehouse/item_finishedgoods_add.aspx?page=store", this.jID, this.InvID));
                            return;
                        }
                        HttpResponse response1 = base.Response;
                        string[] invID2 = new string[] { this.strSitepath, "warehouse/item_finishedgoods_add?page=store&type=", this.mode, "&id=", this.id, this.jID, this.InvID };
                        response1.Redirect(string.Concat(invID2));
                        return;
                    }
                    if (this.postback == "item")
                    {
                        if (this.mode != "edit")
                        {
                            base.Response.Redirect(string.Concat(this.strSitepath, "warehouse/item_finishedgoods_add.aspx?page=item", this.jID, this.InvID));
                            return;
                        }
                        HttpResponse httpResponse1 = base.Response;
                        string[] invID3 = new string[] { this.strSitepath, "warehouse/item_finishedgoods_add?page=item&type=", this.mode, "&id=", this.id, this.jID, this.InvID };
                        httpResponse1.Redirect(string.Concat(invID3));
                        return;
                    }
                    if (this.postback == "estimate" || this.postback == "estimates")
                    {
                        if (this.mode != "edit")
                        {
                            if (base.Request.Params["item"] != null && base.Request.Params["item"].ToString().ToLower() == "outwork")
                            {
                                object[] objArray = new object[] { this.retClientID.ToString(), "~", base.Request.Params["id"].ToString(), "~", this.basecls.SpecialEncode(this.txt_companyname.Text), "~", this.retContactID };
                                Client_add_new.strFinalData = string.Concat(objArray);
                                this.pnlWinClose.Visible = true;
                                return;
                            }
                            if (this.retContactID == 0)
                            {
                                if (this.ddl_salesperson.SelectedValue == "0")
                                {
                                    HttpResponse response2 = base.Response;
                                    string[] value = new string[] { this.strSitepath, "estimates/estimates_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, this.jID, this.InvID };
                                    response2.Redirect(string.Concat(value));
                                    return;
                                }
                                HttpResponse httpResponse2 = base.Response;
                                string[] value1 = new string[] { this.strSitepath, "estimates/estimates_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, "&salperson=", this.ddl_salesperson.SelectedValue, this.jID, this.InvID };
                                httpResponse2.Redirect(string.Concat(value1));
                                return;
                            }
                            if (this.ddl_salesperson.SelectedValue == "0")
                            {
                                HttpResponse response3 = base.Response;
                                object[] objArray1 = new object[] { this.strSitepath, "estimates/estimates_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, this.jID, this.InvID };
                                response3.Redirect(string.Concat(objArray1));
                                return;
                            }
                            HttpResponse httpResponse3 = base.Response;
                            object[] value2 = new object[] { this.strSitepath, "estimates/estimates_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, "&salperson=", this.ddl_salesperson.SelectedValue, this.jID, this.InvID };
                            httpResponse3.Redirect(string.Concat(value2));
                            return;
                        }
                        if (base.Request.Params["item"] != null && base.Request.Params["item"].ToString().ToLower() == "outwork")
                        {
                            str = new object[] { this.retClientID.ToString(), "~", base.Request.Params["id"].ToString(), "~", this.basecls.SpecialEncode(this.txt_companyname.Text), "~", this.retContactID };
                            Client_add_new.strFinalData = string.Concat(str);
                            this.pnlWinClose.Visible = true;
                            return;
                        }
                        if (this.retContactID == 0)
                        {
                            if (this.ddl_salesperson.SelectedValue == "0")
                            {
                                HttpResponse response4 = base.Response;
                                string[] value3 = new string[] { this.strSitepath, "estimates/estimates_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&cntct=new", this.jID, this.InvID };
                                response4.Redirect(string.Concat(value3));
                                return;
                            }
                            HttpResponse httpResponse4 = base.Response;
                            string[] strArrays3 = new string[] { this.strSitepath, "estimates/estimates_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&salperson=", this.ddl_salesperson.SelectedValue, "&cntct=new", this.jID, this.InvID };
                            httpResponse4.Redirect(string.Concat(strArrays3));
                            return;
                        }
                        if (this.ddl_salesperson.SelectedValue == "0")
                        {
                            HttpResponse response5 = base.Response;
                            object[] objArray2 = new object[] { this.strSitepath, "estimates/estimates_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, this.jID, this.InvID };
                            response5.Redirect(string.Concat(objArray2));
                            return;
                        }
                        HttpResponse httpResponse5 = base.Response;
                        object[] objArray3 = new object[] { this.strSitepath, "estimates/estimates_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, "&salperson=", this.ddl_salesperson.SelectedValue, this.jID, this.InvID };
                        httpResponse5.Redirect(string.Concat(objArray3));
                        return;
                    }
                    if (this.postback == "job" || this.postback == "jobs")
                    {
                        if (this.mode != "edit")
                        {
                            if (base.Request.Params["item"] != null && base.Request.Params["item"].ToString().ToLower() == "outwork")
                            {
                                str = new object[] { this.retClientID.ToString(), "~", base.Request.Params["id"].ToString(), "~", this.basecls.SpecialEncode(this.txt_companyname.Text), "~", this.retContactID };
                                Client_add_new.strFinalData = string.Concat(str);
                                this.pnlWinClose.Visible = true;
                                return;
                            }
                            if (this.retContactID == 0)
                            {
                                if (this.ddl_salesperson.SelectedValue == "0")
                                {
                                    HttpResponse response6 = base.Response;
                                    invID = new string[] { this.strSitepath, "jobs/job_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, this.jID, this.InvID };
                                    response6.Redirect(string.Concat(invID));
                                    return;
                                }
                                HttpResponse httpResponse6 = base.Response;
                                invID = new string[] { this.strSitepath, "jobs/job_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, "&salperson=", this.ddl_salesperson.SelectedValue, this.jID, this.InvID };
                                httpResponse6.Redirect(string.Concat(invID));
                                return;
                            }
                            if (this.ddl_salesperson.SelectedValue == "0")
                            {
                                HttpResponse response7 = base.Response;
                                str = new object[] { this.strSitepath, "jobs/job_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, this.jID, this.InvID };
                                response7.Redirect(string.Concat(str));
                                return;
                            }
                            HttpResponse httpResponse7 = base.Response;
                            str = new object[] { this.strSitepath, "jobs/job_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, "&salperson=", this.ddl_salesperson.SelectedValue, this.jID, this.InvID };
                            httpResponse7.Redirect(string.Concat(str));
                            return;
                        }
                        if (base.Request.Params["item"] != null && base.Request.Params["item"].ToString().ToLower() == "outwork")
                        {
                            object[] objArray4 = new object[] { this.retClientID.ToString(), "~", base.Request.Params["id"].ToString(), "~", this.basecls.SpecialEncode(this.txt_companyname.Text), "~", this.retContactID };
                            Client_add_new.strFinalData = string.Concat(objArray4);
                            this.pnlWinClose.Visible = true;
                            return;
                        }
                        if (this.retContactID == 0)
                        {
                            if (this.ddl_salesperson.SelectedValue == "0")
                            {
                                HttpResponse response8 = base.Response;
                                invID = new string[] { this.strSitepath, "jobs/job_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&cntct=new", this.jID, this.InvID };
                                response8.Redirect(string.Concat(invID));
                                return;
                            }
                            HttpResponse httpResponse8 = base.Response;
                            string[] value4 = new string[] { this.strSitepath, "jobs/job_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&salperson=", this.ddl_salesperson.SelectedValue, "&cntct=new", this.jID, this.InvID };
                            httpResponse8.Redirect(string.Concat(value4));
                            return;
                        }
                        if (this.ddl_salesperson.SelectedValue == "0")
                        {
                            HttpResponse response9 = base.Response;
                            object[] value5 = new object[] { this.strSitepath, "jobs/job_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, this.jID, this.InvID };
                            response9.Redirect(string.Concat(value5));
                            return;
                        }
                        HttpResponse httpResponse9 = base.Response;
                        object[] objArray5 = new object[] { this.strSitepath, "jobs/job_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, "&salperson=", this.ddl_salesperson.SelectedValue, this.jID, this.InvID };
                        httpResponse9.Redirect(string.Concat(objArray5));
                        return;
                    }
                    if (this.postback == "invoice")
                    {
                        if (this.mode != "edit")
                        {
                            if (base.Request.Params["item"] != null && base.Request.Params["item"].ToString().ToLower() == "outwork")
                            {
                                str = new object[] { this.retClientID.ToString(), "~", base.Request.Params["id"].ToString(), "~", this.basecls.SpecialEncode(this.txt_companyname.Text), "~", this.retContactID };
                                Client_add_new.strFinalData = string.Concat(str);
                                this.pnlWinClose.Visible = true;
                                return;
                            }
                            if (this.retContactID == 0)
                            {
                                if (this.ddl_salesperson.SelectedValue == "0")
                                {
                                    HttpResponse response10 = base.Response;
                                    invID = new string[] { this.strSitepath, "invoice/invoices_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, this.jID, this.InvID };
                                    response10.Redirect(string.Concat(invID));
                                    return;
                                }
                                HttpResponse httpResponse10 = base.Response;
                                invID = new string[] { this.strSitepath, "invoice/invoices_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, "&salperson=", this.ddl_salesperson.SelectedValue, this.jID, this.InvID };
                                httpResponse10.Redirect(string.Concat(invID));
                                return;
                            }
                            if (this.ddl_salesperson.SelectedValue == "0")
                            {
                                HttpResponse response11 = base.Response;
                                str = new object[] { this.strSitepath, "invoice/invoices_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, this.jID, this.InvID };
                                response11.Redirect(string.Concat(str));
                                return;
                            }
                            HttpResponse httpResponse11 = base.Response;
                            str = new object[] { this.strSitepath, "invoice/invoices_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, "&salperson=", this.ddl_salesperson.SelectedValue, this.jID, this.InvID };
                            httpResponse11.Redirect(string.Concat(str));
                            return;
                        }
                        if (base.Request.Params["item"] != null && base.Request.Params["item"].ToString().ToLower() == "outwork")
                        {
                            str = new object[] { this.retClientID.ToString(), "~", base.Request.Params["id"].ToString(), "~", this.basecls.SpecialEncode(this.txt_companyname.Text), "~", this.retContactID };
                            Client_add_new.strFinalData = string.Concat(str);
                            this.pnlWinClose.Visible = true;
                            return;
                        }
                        if (this.retContactID == 0)
                        {
                            if (this.ddl_salesperson.SelectedValue == "0")
                            {
                                HttpResponse response12 = base.Response;
                                invID = new string[] { this.strSitepath, "invoice/invoices_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&cntct=new", this.jID, this.InvID };
                                response12.Redirect(string.Concat(invID));
                                return;
                            }
                            HttpResponse httpResponse12 = base.Response;
                            invID = new string[] { this.strSitepath, "invoice/invoices_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&salperson=", this.ddl_salesperson.SelectedValue, "&cntct=new", this.jID, this.InvID };
                            httpResponse12.Redirect(string.Concat(invID));
                            return;
                        }
                        if (this.ddl_salesperson.SelectedValue == "0")
                        {
                            HttpResponse response13 = base.Response;
                            str = new object[] { this.strSitepath, "invoice/invoices_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, this.jID, this.InvID };
                            response13.Redirect(string.Concat(str));
                            return;
                        }
                        HttpResponse httpResponse13 = base.Response;
                        str = new object[] { this.strSitepath, "invoice/invoices_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, "&salperson=", this.ddl_salesperson.SelectedValue, this.jID, this.InvID };
                        httpResponse13.Redirect(string.Concat(str));
                        return;
                    }
                    if (this.postback == "purchase")
                    {
                        if (this.mode != "edit")
                        {
                            if (this.retContactID == 0)
                            {
                                HttpResponse response14 = base.Response;
                                invID = new string[] { this.strSitepath, "purchase/purchase_add.aspx?type=", this.mode, "&suplrid=", this.hid_ClientID.Value, this.jID, this.InvID };
                                response14.Redirect(string.Concat(invID));
                                return;
                            }
                            HttpResponse httpResponse14 = base.Response;
                            str = new object[] { this.strSitepath, "purchase/purchase_add.aspx?type=", this.mode, "&suplrid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, this.jID, this.InvID };
                            httpResponse14.Redirect(string.Concat(str));
                            return;
                        }
                        if (this.retContactID == 0)
                        {
                            HttpResponse response15 = base.Response;
                            invID = new string[] { this.strSitepath, "purchase/purchase_add.aspx?type=", this.mode, "&id=", this.id, "&suplrid=", this.hid_ClientID.Value, "&cntct=new", this.jID, this.InvID };
                            response15.Redirect(string.Concat(invID));
                            return;
                        }
                        HttpResponse httpResponse15 = base.Response;
                        str = new object[] { this.strSitepath, "purchase/purchase_add.aspx?type=", this.mode, "&id=", this.id, "&suplrid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, this.jID, this.InvID };
                        httpResponse15.Redirect(string.Concat(str));
                        return;
                    }
                    if (this.postback == "delivery")
                    {
                        if (this.mode != "edit")
                        {
                            if (this.retContactID != 0)
                            {
                                HttpResponse response16 = base.Response;
                                str = new object[] { this.strSitepath, "delivery/delivery_add.aspx?clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, this.jID, this.InvID };
                                response16.Redirect(string.Concat(str));
                                return;
                            }
                            HttpResponse httpResponse16 = base.Response;
                            str = new object[] { this.strSitepath, "delivery/delivery_add.aspx?clientid=", this.hid_ClientID.Value, this.jID, this.InvID, "&contactid=", this.retContactID };
                            httpResponse16.Redirect(string.Concat(str));
                            return;
                        }
                        if (this.retContactID == 0)
                        {
                            HttpResponse response17 = base.Response;
                            invID = new string[] { this.strSitepath, "delivery/delivery_add.aspx?type=", this.mode, "&id=", this.id, "&clientid=", this.hid_ClientID.Value, "&cntct=new", this.jID, this.InvID };
                            response17.Redirect(string.Concat(invID));
                            return;
                        }
                        HttpResponse httpResponse17 = base.Response;
                        str = new object[] { this.strSitepath, "delivery/delivery_add.aspx?type=", this.mode, "&id=", this.id, "&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, this.jID, this.InvID };
                        httpResponse17.Redirect(string.Concat(str));
                        return;
                    }
                    if (this.postback == "ContactAdd")
                    {
                        if (this.mode == "edit")
                        {
                            HttpResponse response18 = base.Response;
                            invID = new string[] { this.strSitepath, "client/contact_add.aspx?type=", this.mode, "&id=", this.id, this.jID, this.InvID };
                            response18.Redirect(string.Concat(invID));
                            return;
                        }
                        HttpResponse httpResponse18 = base.Response;
                        str = new object[] { this.strSitepath, "client/contact_add.aspx?type=", this.companytype, "&id=", this.retClientID, this.jID, this.InvID };
                        httpResponse18.Redirect(string.Concat(str));
                        return;
                    }
                    if (this.postback == "othercost")
                    {
                        if (this.mode != "edit")
                        {
                            HttpResponse response19 = base.Response;
                            invID = new string[] { this.strSitepath, "settings/othercost_add.aspx?suplrid=", this.hid_ClientID.Value, this.jID, this.InvID };
                            response19.Redirect(string.Concat(invID));
                            return;
                        }
                        HttpResponse httpResponse19 = base.Response;
                        invID = new string[] { this.strSitepath, "settings/othercost_add.aspx?type=", this.mode, "&id=", this.id, "&suplrid=", this.hid_ClientID.Value, this.jID, this.InvID };
                        httpResponse19.Redirect(string.Concat(invID));
                        return;
                    }
                    if (this.postback == "settings")
                    {
                        this.pnl_productsummary_supplieradd.Visible = true;
                        return;
                    }
                    if (this.postback == "estimate1")
                    {
                        if (this.mode == "edit")
                        {
                            this.id = "0";
                            ScriptManager.RegisterStartupScript(this, base.GetType(), "", "javascript:ddl_bind_supplier();", true);
                            return;
                        }
                        base.Response.Redirect(string.Concat(this.strSitepath, "common/common_popup.aspx?type=Paper&pg=estimate&item=Paper", this.jID, this.InvID));
                        return;
                    }
                }
            }
            else if (this.action != "" && this.action == "edit")
            {
                if (this.ddl_Deliverycountry.SelectedItem.Text.ToString().Equals("--- Select ---"))
                {
                    foreach (DataRow dataRow in SettingsBasePage.settings_companyprofile_select(this.CompanyID).Rows)
                    {
                        this.ddl_Deliverycountry.SelectedIndex = this.ddl_Deliverycountry.Items.IndexOf(this.ddl_Deliverycountry.Items.FindByText(dataRow["Country"].ToString()));
                    }
                }
                if (base.Session["Flag"] != null)
                {
                    if (base.Session["Flag"].ToString().ToLower() != "true")
                    {
                        CompanyBasePage.Company_InsertUpdate(this.CompanyID, Convert.ToInt32(this.hid_ClientID.Value), this.lblCompanyType.Text, this.basecls.SpecialEncode(this.txt_companyname.Text), this.basecls.SpecialEncode(this.txt_companyalias.Text), this.basecls.SpecialEncode(this.ddl_type.SelectedValue), this.basecls.SpecialEncode(this.ddl_status.SelectedValue), this.basecls.SpecialEncode(this.txt_accountno.Text), this.basecls.SpecialEncode(this.txt_email.Text), this.basecls.SpecialEncode(this.txt_url.Text), this.basecls.SpecialEncode(this.txt_creditlimit.Text), this.basecls.SpecialEncode(this.txt_creditref.Text), Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_tax1.SelectedValue)), Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_tax2.SelectedValue)), this.basecls.SpecialEncode(this.txt_taxregno.Text), this.basecls.SpecialEncode(this.ddl_PaymentTerms.SelectedValue), this.basecls.SpecialEncode(this.txt_companyno.Text), empty2, Convert.ToDateTime(str2), this.basecls.SpecialEncode(this.txt_bankcode.Text), this.basecls.SpecialEncode(this.txt_bankacno.Text), this.basecls.SpecialEncode(this.txt_accountname.Text), Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_salesperson.SelectedValue)), this.basecls.SpecialEncode(this.txt_taxnumber.Text), this.basecls.SpecialEncode(this.txt_balance.Text), this.basecls.SpecialEncode(this.txt_description.Text), now, this.UserID, Convert.ToInt32(this.ddl_Referencedby.SelectedValue), num, flag1, this.basecls.SpecialEncode(empty1), this.basecls.SpecialEncode(str1), chkTaxPrecedence.Checked);
                    }
                    else
                    {
                        CompanyBasePage.Company_InsertUpdate(this.CompanyID, Convert.ToInt32(this.hid_ClientID.Value), this.lblCompanyType.Text, this.basecls.SpecialEncode(this.txt_companyname.Text), this.basecls.SpecialEncode(this.txt_companyalias.Text), this.basecls.SpecialEncode(this.ddl_type.SelectedValue), this.basecls.SpecialEncode(this.ddl_status.SelectedValue), this.basecls.SpecialEncode(this.txt_accountno.Text), this.basecls.SpecialEncode(this.txt_email.Text), this.basecls.SpecialEncode(this.txt_url.Text), this.basecls.SpecialEncode(this.txt_creditlimit.Text), this.basecls.SpecialEncode(this.txt_creditref.Text), Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_tax1.SelectedValue)), Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_tax2.SelectedValue)), this.basecls.SpecialEncode(this.txt_taxregno.Text), this.basecls.SpecialEncode(this.ddl_PaymentTerms.SelectedValue), this.basecls.SpecialEncode(this.txt_companyno.Text), empty2, Convert.ToDateTime(str2), this.basecls.SpecialEncode(this.txt_bankcode.Text), this.basecls.SpecialEncode(this.txt_bankacno.Text), this.basecls.SpecialEncode(this.txt_accountname.Text), Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_salesperson.SelectedValue)), this.basecls.SpecialEncode(this.txt_taxnumber.Text), this.basecls.SpecialEncode(this.txt_balance.Text), this.basecls.SpecialEncode(this.txt_description.Text), now, this.UserID, Convert.ToInt32(this.hdn_Referencedby.Value), num, flag1, this.basecls.SpecialEncode(empty1), this.basecls.SpecialEncode(str1), chkTaxPrecedence.Checked);
                    }
                    for (int k = 0; k < (int)strArrays.Length - 1; k++)
                    {
                        CompanyBasePage.crm_clientType_add((long)this.CompanyID, Convert.ToInt64(this.hid_ClientID.Value), Convert.ToInt64(this.basecls.SpecialEncode(strArrays[k])), this.basecls.SpecialEncode(strArrays1[k]));
                    }
                }
                if (this.hdncmpnyaddressid.Value != "0" && (this.lblCompanyType.Text.ToLower() == "customer" || this.lblCompanyType.Text.ToLower() == "prospect" || this.lblCompanyType.Text.ToLower() == "supplier"))
                {
                    long num3 = Convert.ToInt64(this.hdncmpnyaddressid.Value);
                    long num4 = Convert.ToInt64(this.retClientID);
                    string str12 = this.basecls.SpecialEncode(this.txt_Deliveryaddr1.Text);
                    string str13 = this.basecls.SpecialEncode(this.txt_Deliveryaddr3.Text);
                    string str14 = this.basecls.SpecialEncode(this.txt_Deliveryaddr4.Text);
                    string str15 = this.basecls.SpecialEncode(this.txt_Deliveryaddr5.Text);
                    string str16 = this.basecls.SpecialEncode(this.ddl_Deliverycountry.SelectedItem.Text);
                    string str17 = this.basecls.SpecialEncode(this.txt_Deliveryphone.Text);
                    string str18 = this.basecls.SpecialEncode(this.txt_Deliveryfax.Text);
                    string str19 = this.basecls.SpecialEncode(this.txt_url.Text);
                    int userID1 = this.UserID;
                    DateTime now1 = DateTime.Now;
                    this.retAddressID = CompanyBasePage.CompanyDefaultAddress_InsertUpdate(num3, num4, str12, str13, str14, str15, str16, str17, str18, str19, userID1, now1.ToString(), "Main", this.basecls.SpecialEncode(this.txt_Deliveryaddr2.Text), this.basecls.SpecialEncode(this.txt_email.Text), "N");
                }
                else if (this.lblCompanyType.Text.ToLower() == "customer" || this.lblCompanyType.Text.ToLower() == "prospect" || this.lblCompanyType.Text.ToLower() == "supplier")
                {
                    long num5 = (long)0;
                    long num6 = (long)Convert.ToInt32(this.hid_ClientID.Value);
                    string str20 = this.basecls.SpecialEncode(this.txt_Deliveryaddr1.Text);
                    string str21 = this.basecls.SpecialEncode(this.txt_Deliveryaddr3.Text);
                    string str22 = this.basecls.SpecialEncode(this.txt_Deliveryaddr4.Text);
                    string str23 = this.basecls.SpecialEncode(this.txt_Deliveryaddr5.Text);
                    string str24 = this.basecls.SpecialEncode(this.ddl_Deliverycountry.SelectedItem.Text);
                    string str25 = this.basecls.SpecialEncode(this.txt_Deliveryphone.Text);
                    string str26 = this.basecls.SpecialEncode(this.txt_Deliveryfax.Text);
                    string str27 = this.basecls.SpecialEncode(this.txt_url.Text);
                    int userID2 = this.UserID;
                    DateTime dateTime1 = DateTime.Now;
                    this.retAddressID = CompanyBasePage.CompanyDefaultAddress_InsertUpdate(num5, num6, str20, str21, str22, str23, str24, str25, str26, str27, userID2, dateTime1.ToString(), "Main", this.basecls.SpecialEncode(this.txt_Deliveryaddr2.Text), this.basecls.SpecialEncode(this.txt_email.Text), "N");
                }
                QueryString queryString2 = new QueryString()
            {
                { "clientid", this.hid_ClientID.Value },
                { "isnew", "2" },
                { "bypass", "1" },
                { "type", this.companytype },
                { "suc", "up" }
            };
                string str28 = string.Concat("client/client_detail.aspx", this.jID, this.InvID);
                QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
                str28 = string.Concat(str28, queryString3.ToString());
                base.Response.Redirect(string.Concat(this.strSitepath, str28));
                return;
            }
        }

        public void Fill_Referencedby()
        {
            DataTable dataTable = CompanyBasePage.ClientReferencedByName_Select("", this.CompanyID);
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if (dataTable.Columns.Contains("Name"))
                    {
                        dataTable.Columns["Name"].ReadOnly = false;
                        dataTable.Rows[i]["Name"] = this.basecls.SpecialDecode(dataTable.Rows[i]["Name"].ToString());
                    }
                }
            }
            DataView dataViews = new DataView();
            dataViews = dataTable.DefaultView;
            dataViews.Sort = "Name ASC";
            this.ddl_Referencedby.DataSource = dataViews;
            this.ddl_Referencedby.DataTextField = "Name";
            this.ddl_Referencedby.DataValueField = "ReferencedID";
            this.ddl_Referencedby.DataBind();
            this.ddl_Referencedby.Items.Insert(0, " ");
            this.ddl_Referencedby.Items[0].Text = "None";
            this.ddl_Referencedby.Items[0].Value = "0";
            base.Session["Flag"] = false;
            DataTable dataTable1 = SettingsBasePage.settings_RefferceBy_SetDefault(this.CompanyID);
            string empty = string.Empty;
            foreach (DataRow row in dataTable1.Rows)
            {
                empty = this.basecls.SpecialDecode(row["Name"].ToString());
            }
            if (empty != "")
            {
                for (int j = 0; j < this.ddl_Referencedby.Items.Count; j++)
                {
                    if (string.Compare(this.ddl_Referencedby.Items[j].Text, empty, true) == 0)
                    {
                        this.ddl_Referencedby.SelectedIndex = j;
                        this.ddl_Referencedby.SelectedItem.Text = this.basecls.SpecialDecode(this.ddl_Referencedby.SelectedItem.Text);
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConnectionClass.ServerName.ToString().ToLower() == "coralcoast")
            {
                this.DivChkRoyalityFree.Style.Add("display", "block");
            }
            this.hdnsystemname.Value = ConnectionClass.ServerName.ToString();
            BaseClass baseClass = new BaseClass();
            string empty = string.Empty;
            if (baseClass.ReturnRoles_Privileges_ForGrid("clients", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                this.Divdiv_btnsave.Visible = true;
                this.DivImgRefferedByAdd.Visible = true;
            }
            else
            {
                this.Divdiv_btnsave.Visible = false;
                this.DivImgRefferedByAdd.Visible = false;
            }
            if (base.Request.QueryString["jID"] != null)
            {
                this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
            }
            if (base.Request.QueryString["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvID"]);
            }
            if (this.jobID != (long)0)
            {
                this.jID = string.Concat("&jID=", this.jobID);
            }
            if (this.InvoiceID != (long)0)
            {
                this.InvID = string.Concat("&InvID=", this.InvoiceID);
            }
            if (base.Request.Params["type"] != null)
            {
                this.companytype = base.Request.Params["type"].ToString();
                if (base.Request.Params["post"] != null)
                {
                    this.postback = base.Request.Params["post"].ToString();
                }
            }
            global.pageName = "client";
            global.pgName = "";
            this.gloobj.setpagename("client");
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.DateFormat = base.Session["DateFormat"].ToString();
            if (!base.IsPostBack)
            {
                foreach (DataRow row in this.objcomp.Clientaddresslabels(this.CompanyID).Rows)
                {
                    if ((!(this.hdnsystemname.Value == "fsg") || !(this.companytype.ToLower() == "prospect")) && (!(this.hdnsystemname.Value == "fsg") || !(this.postback == "estimate")))
                    {
                        if (row["addresslkey"].ToString().ToLower() == "address1")
                        {
                            if (row["addressvalue"].ToString() == "")
                            {
                                this.lbl_Deliveryaddr1.Text = this.objLangClass.GetLanguageConversion("Address1");
                            }
                            else
                            {
                                this.lbl_Deliveryaddr1.Text = row["addressvalue"].ToString();
                            }
                            if (row["isRequired"].ToString().ToLower() == "true")
                            {
                                this.lbl_Deliveryaddr1.Text = string.Concat(this.lbl_Deliveryaddr1.Text, "<span style='color: red;'>&nbsp;*</span>");
                                this.RequiredAddress = string.Concat(this.RequiredAddress, "1,");
                            }
                        }
                        if (row["addresslkey"].ToString().ToLower() == "address2")
                        {
                            if (row["addressvalue"].ToString() == "")
                            {
                                this.lbl_Deliveryaddr2.Text = this.objLangClass.GetLanguageConversion("Address2");
                            }
                            else
                            {
                                this.lbl_Deliveryaddr2.Text = row["addressvalue"].ToString();
                            }
                            if (row["isRequired"].ToString().ToLower() == "true")
                            {
                                this.lbl_Deliveryaddr2.Text = string.Concat(this.lbl_Deliveryaddr2.Text, "<span style='color: red;'>&nbsp;*</span>");
                                this.RequiredAddress = string.Concat(this.RequiredAddress, "2,");
                            }
                        }
                        if (row["addresslkey"].ToString().ToLower() == "address3")
                        {
                            if (row["addressvalue"].ToString() == "")
                            {
                                this.lbl_Deliveryaddr3.Text = this.objLangClass.GetLanguageConversion("Address3");
                            }
                            else
                            {
                                this.lbl_Deliveryaddr3.Text = row["addressvalue"].ToString();
                            }
                            if (row["isRequired"].ToString().ToLower() == "true")
                            {
                                this.lbl_Deliveryaddr3.Text = string.Concat(this.lbl_Deliveryaddr3.Text, "<span style='color: red;'>&nbsp;*</span>");
                                this.RequiredAddress = string.Concat(this.RequiredAddress, "3,");
                            }
                        }
                        if (row["addresslkey"].ToString().ToLower() == "address4")
                        {
                            if (row["addressvalue"].ToString() == "")
                            {
                                this.lbl_Deliveryaddr4.Text = this.objLangClass.GetLanguageConversion("Address4");
                            }
                            else
                            {
                                this.lbl_Deliveryaddr4.Text = row["addressvalue"].ToString();
                            }
                            if (row["isRequired"].ToString().ToLower() == "true")
                            {
                                this.lbl_Deliveryaddr4.Text = string.Concat(this.lbl_Deliveryaddr4.Text, "<span style='color: red;'>&nbsp;*</span>");
                                this.RequiredAddress = string.Concat(this.RequiredAddress, "4,");
                            }
                        }
                        if (row["addresslkey"].ToString().ToLower() != "address5")
                        {
                            continue;
                        }
                        if (row["addressvalue"].ToString() == "")
                        {
                            this.lbl_Deliveryaddr5.Text = this.objLangClass.GetLanguageConversion("Address5");
                        }
                        else
                        {
                            this.lbl_Deliveryaddr5.Text = row["addressvalue"].ToString();
                        }
                        if (row["isRequired"].ToString().ToLower() != "true")
                        {
                            continue;
                        }
                        this.lbl_Deliveryaddr5.Text = string.Concat(this.lbl_Deliveryaddr5.Text, "<span style='color: red;'>&nbsp;*</span>");
                        this.RequiredAddress = string.Concat(this.RequiredAddress, "5,");
                    }
                    else
                    {
                        if (row["addresslkey"].ToString().ToLower() == "address1")
                        {
                            if (row["addressvalue"].ToString() == "")
                            {
                                this.lbl_Deliveryaddr1.Text = this.objLangClass.GetLanguageConversion("Address1");
                            }
                            else
                            {
                                this.lbl_Deliveryaddr1.Text = row["addressvalue"].ToString();
                            }
                            this.lbl_Deliveryaddr1.Text = string.Concat(this.lbl_Deliveryaddr1.Text, "<span style='color: red;'>&nbsp;*</span>");
                            if (row["isRequired"].ToString().ToLower() == "true")
                            {
                                this.RequiredAddress1 = string.Concat(this.RequiredAddress1, "1,");
                            }
                        }
                        if (row["addresslkey"].ToString().ToLower() == "address2")
                        {
                            if (row["addressvalue"].ToString() == "")
                            {
                                this.lbl_Deliveryaddr2.Text = this.objLangClass.GetLanguageConversion("Address2");
                            }
                            else
                            {
                                this.lbl_Deliveryaddr2.Text = row["addressvalue"].ToString();
                            }
                            this.lbl_Deliveryaddr2.Text = string.Concat(this.lbl_Deliveryaddr2.Text, "<span style='color: red;'>&nbsp;*</span>");
                            if (row["isRequired"].ToString().ToLower() == "true")
                            {
                                this.RequiredAddress1 = string.Concat(this.RequiredAddress1, "2,");
                            }
                        }
                        if (row["addresslkey"].ToString().ToLower() == "address3")
                        {
                            if (row["addressvalue"].ToString() == "")
                            {
                                this.lbl_Deliveryaddr3.Text = this.objLangClass.GetLanguageConversion("Address3");
                            }
                            else
                            {
                                this.lbl_Deliveryaddr3.Text = row["addressvalue"].ToString();
                            }
                            this.lbl_Deliveryaddr3.Text = string.Concat(this.lbl_Deliveryaddr3.Text, "<span style='color: red;'>&nbsp;*</span>");
                            if (row["isRequired"].ToString().ToLower() == "true")
                            {
                                this.RequiredAddress1 = string.Concat(this.RequiredAddress1, "3,");
                            }
                        }
                        if (row["addresslkey"].ToString().ToLower() == "address4")
                        {
                            if (row["addressvalue"].ToString() == "")
                            {
                                this.lbl_Deliveryaddr4.Text = this.objLangClass.GetLanguageConversion("Address4");
                            }
                            else
                            {
                                this.lbl_Deliveryaddr4.Text = row["addressvalue"].ToString();
                            }
                            this.lbl_Deliveryaddr4.Text = string.Concat(this.lbl_Deliveryaddr4.Text, "<span style='color: red;'>&nbsp;*</span>");
                            if (row["isRequired"].ToString().ToLower() == "true")
                            {
                                this.RequiredAddress1 = string.Concat(this.RequiredAddress1, "4,");
                            }
                        }
                        if (row["addresslkey"].ToString().ToLower() != "address5")
                        {
                            continue;
                        }
                        if (row["addressvalue"].ToString() == "")
                        {
                            this.lbl_Deliveryaddr5.Text = this.objLangClass.GetLanguageConversion("Address5");
                        }
                        else
                        {
                            this.lbl_Deliveryaddr5.Text = row["addressvalue"].ToString();
                        }
                        this.lbl_Deliveryaddr5.Text = string.Concat(this.lbl_Deliveryaddr5.Text, "<span style='color: red;'>&nbsp;*</span>");
                        if (row["isRequired"].ToString().ToLower() != "true")
                        {
                            continue;
                        }
                        this.RequiredAddress1 = string.Concat(this.RequiredAddress1, "5,");
                    }
                }
            }
            if (ConnectionClass.Tax2 != null)
            {
                this.Tax2 = ConnectionClass.Tax2;
                if (this.Tax2.ToLower() != "yes")
                {
                    this.lbl_tax1.Text = this.objLangClass.GetLanguageConversion("Tax");
                }
                else
                {
                    this.div_Tax2.Style.Add("display", "block");
                }
            }
            this.txt_companyname.Focus();
            this.txt_Referencedby.Attributes.Add("autocomplete", "off");
            if (base.Request.Params["sender"] != null)
            {
                this.sender1 = base.Request.Params["sender"].ToString();
            }
            if (base.Request.Params["mode"] != null)
            {
                this.mode = base.Request.Params["mode"].ToString();
            }
            if (base.Request.Params["post"] != null)
            {
                this.postback = base.Request.Params["post"].ToString();
            }
            if (base.Request.Params["from"] != null)
            {
                this.RedirectTo = base.Request.Params["from"].ToString().ToLower().Trim();
            }
            if (base.Request.Params["clientID"] != null && base.Request.Params["clientID"].ToString() != "")
            {
                this.ClientID = Convert.ToInt32(base.Request.Params["clientID"].ToString());
            }
            if (base.Request.Params["type"] == null)
            {
                try
                {
                    string str = Encryption.DecryptQueryString(QueryString.FromCurrent()).ToString();
                    ArrayList arrayLists = Encryption.querystrvalue(str);
                    this.ClientID = int.Parse(arrayLists[1].ToString());
                    this.hid_ClientID.Value = arrayLists[1].ToString();
                    this.companytype = arrayLists[7].ToString();
                    this.action = arrayLists[9].ToString();
                    this.hdn_DeliveryaddressID.Value = arrayLists[11].ToString();
                    try
                    {
                        this.isnew = int.Parse(Convert.ToString(arrayLists[3]));
                    }
                    catch
                    {
                    }
                }
                catch
                {
                }
            }
            else
            {
                this.companytype = base.Request.Params["type"].ToString();
                if (base.Request.Params["post"] != null)
                {
                    this.postback = base.Request.Params["post"].ToString();
                }
                if (base.Request.Params["mode"] != null)
                {
                    this.mode = base.Request.Params["mode"].ToString();
                }
                if (base.Request.Params["id"] != null)
                {
                    this.id = base.Request.Params["id"].ToString();
                }
                if (base.Request.Params["estid"] != null)
                {
                    this.id = base.Request.Params["estid"].ToString();
                }
            }
            if (!base.IsPostBack)
            {
                DataTable dataTable = SettingsBasePage.settings_CompanyType_select_ForClient(this.CompanyID, this.companytype);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    dataRow["companytype"] = this.basecls.SpecialDecode(dataRow["companytype"].ToString());
                }
                this.ddl_type.DataSource = dataTable;
                this.ddl_type.DataTextField = "companytype";
                this.ddl_type.DataValueField = "id";
                this.ddl_type.DataBind();
                if (this.action != "edit")
                {
                    if ((!(this.hdnsystemname.Value == "fsg") || !(this.companytype.ToLower() == "prospect")) && (!(this.hdnsystemname.Value == "fsg") || !(this.postback == "estimate")))
                    {
                        this.ddl_type.SelectedValue = " None";
                    }
                    else
                    {
                        foreach (RadComboBoxItem item in this.ddl_type.Items)
                        {
                            CheckBox checkBox = (CheckBox)item.FindControl("chk1");
                            if (!("107" == item.Value) || !(checkBox.Text == "Retail customer"))
                            {
                                continue;
                            }
                            checkBox.Checked = true;
                            this.ddl_type.Text = item.Text;
                        }
                    }
                    DataTable dataTable1 = CompanyBasePage.Account_Number_Generate(Convert.ToInt64(this.CompanyID), "A");
                    foreach (DataRow row1 in dataTable1.Rows)
                    {
                        this.txt_accountno.Text = row1["lastcounter"].ToString();
                    }
                }
            }
            if (this.companytype != "")
            {
                if (this.companytype.ToLower().Trim() != "customer")
                {
                    this.lblCompanyType.Text = this.companytype;
                }
                else
                {
                    this.lblCompanyType.Text = this.objLangClass.GetLanguageConversion("Customer");
                }
            }
            this.hdn_companytype.Value = this.companytype.ToLower();
            if (this.postback == "estimate" || this.postback == "estimates")
            {
                this.rdProspect.Checked = true;
                this.lblCompanyType.Visible = false;
            }
            else
            {
                this.rdProspect.Visible = false;
                this.rdCustomer.Visible = false;
            }
            if (base.Request.QueryString["item"] != null && base.Request.QueryString["item"] == "Outwork")
            {
                this.lblCompanyType.Visible = true;
                this.rdProspect.Visible = false;
                this.rdCustomer.Visible = false;
                this.div_Description.Style.Add("padding", "0px 0px 0px 0px");
            }
            if ((!(this.hdnsystemname.Value == "fsg") || !(this.companytype.ToLower() == "prospect")) && (!(this.hdnsystemname.Value == "fsg") || !this.rdProspect.Checked))
            {
                this.lbl_desc.Text = this.objLangClass.GetLanguageConversion("Description");
                this.lbl_Deliveryphone.Text = this.objLangClass.GetLanguageConversion("Telephone");
                this.lbl_Referencedby.Text = this.objLangClass.GetLanguageConversion("Referred_By");
            }
            else
            {
                this.lbl_desc.Text = string.Concat(this.objLangClass.GetLanguageConversion("Description"), "<span style='color: red;'>&nbsp;*</span>");
                this.lbl_Deliveryphone.Text = string.Concat(this.objLangClass.GetLanguageConversion("Telephone"), "<span style='color: red;'>&nbsp;*</span>");
                this.lbl_Referencedby.Text = string.Concat(this.objLangClass.GetLanguageConversion("Referred_By"), "<span style='color: red;'>&nbsp;*</span>");
            }
            DataTable dataTable2 = SettingsBasePage.PaymentTerm_Details_Select((long)this.CompanyID);
            if (dataTable2.Rows.Count > 0)
            {
                foreach (DataRow dataRow1 in dataTable2.Rows)
                {
                    HiddenField hdnPaymentTerm = this.hdn_PaymentTerm;
                    object value = hdnPaymentTerm.Value;
                    object[] objArray = new object[] { value, dataRow1["Days"], "‡", dataRow1["PaymenttermID"], "»" };
                    hdnPaymentTerm.Value = string.Concat(objArray);
                }
            }
            DataTable dataTable3 = CompanyBasePage.company_client_select(this.CompanyID, this.ClientID, this.companytype);
            foreach (DataRow row2 in dataTable3.Rows)
            {
                this.DeliveryAddressID = Convert.ToInt64(row2["DeliveryAddressID"].ToString());
                this.InvoiceAddressID = Convert.ToInt64(row2["InvoiceAddressID"].ToString());
            }
            if (!base.IsPostBack)
            {
                this.txt_companyalias.Attributes.Add("onfocus", "javascript:GetClientAlias()");
                (new SettingsBasePage()).Bind_Account_Status(this.ddl_status, this.CompanyID, "None");
                string empty1 = string.Empty;
                foreach (DataRow dataRow2 in SettingsBasePage.settings_AccountStatus_SetDefault(this.CompanyID).Rows)
                {
                    empty1 = dataRow2["StatusTitle"].ToString();
                }
                if (empty1 != "")
                {
                    for (int i = 0; i < this.ddl_status.Items.Count; i++)
                    {
                        if (string.Compare(this.ddl_status.Items[i].Text, empty1, true) == 0)
                        {
                            this.ddl_status.SelectedIndex = i;
                        }
                    }
                }
                if (this.hdnsystemname.Value == "fsg" && this.companytype.ToLower() == "prospect" || this.hdnsystemname.Value == "fsg" && this.postback == "estimate")
                {
                    baseClass.SetDDLText(this.ddl_status, "Accounts Clear");
                }
                this.objcomp.company_country_select(this.ddl_Deliverycountry);
                this.Fill_Referencedby();
                SettingsBasePage.Bind_TaxRate(this.ddl_tax1, this.CompanyID, "None");
                SettingsBasePage.Bind_TaxRate(this.ddl_tax2, this.CompanyID, "None");
                SettingsBasePage.Bind_PaymentTermName(this.ddl_PaymentTerms, this.CompanyID, "None");
                string value1 = string.Empty;
                int num = 0;
                while (num < this.ddl_tax1.Items.Count)
                {
                    if (this.ddl_tax1.Items[num].Text.Equals("GST") || this.ddl_tax1.Items[num].Text.Equals("gst"))
                    {
                        value1 = this.ddl_tax1.Items[num].Value;
                        break;
                    }
                    else
                    {
                        num++;
                    }
                }
                this.ddl_tax1.SelectedValue = value1;
                DataTable dataTable4 = SettingsBasePage.settings_PaymentTerms_SetDefault(this.CompanyID);
                string str1 = string.Empty;
                foreach (DataRow row3 in dataTable4.Rows)
                {
                    str1 = row3["Name"].ToString();
                }
                for (int j = 0; j < this.ddl_PaymentTerms.Items.Count; j++)
                {
                    if (string.Compare(this.ddl_PaymentTerms.Items[j].Text, str1, true) == 0)
                    {
                        this.ddl_PaymentTerms.SelectedIndex = j;
                    }
                }
                this.objset.Bind_User(this.ddl_salesperson, this.CompanyID, "None");
                foreach (DataRow dataRow3 in SettingsBasePage.settings_companyprofile_select(this.CompanyID).Rows)
                {
                    this.ddl_Deliverycountry.SelectedIndex = this.ddl_Deliverycountry.Items.IndexOf(this.ddl_Deliverycountry.Items.FindByText(dataRow3["Country"].ToString()));
                    this.hdn_selectedcounter.Value = this.ddl_Deliverycountry.SelectedIndex.ToString();
                }
                TextBox txtAcopened = this.txt_acopened;
                commonClass _commonClass = this.comncls;
                DateTime now = DateTime.Now;
                txtAcopened.Text = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                this.txt_acopened.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                if (this.companytype.ToLower() != "supplier")
                {
                    this.div_Supplier.Style.Add("display", "none");
                    this.div_Carrier.Style.Add("display", "none");
                }
                else
                {
                    this.div_Supplier.Style.Add("display", "block");
                    this.div_Carrier.Style.Add("display", "block");
                    this.rdProspect.Checked = false;
                }
                if (this.action != "" && this.action == "edit")
                {
                    this.div_DeliveryAddress.Style.Add("display", "block");
                    this.AddressHeader.Style.Add("display", "block");
                    this.txt_Deliveryaddr1.Style.Add("display", "block");
                    this.txt_Deliveryaddr2.Style.Add("display", "block");
                    this.txt_Deliveryaddr3.Style.Add("display", "block");
                    this.txt_Deliveryaddr4.Style.Add("display", "block");
                    this.txt_Deliveryaddr5.Style.Add("display", "block");
                    this.lbl_Deliverycountry.Style.Add("display", "block");
                    this.lbl_Deliveryphone.Style.Add("display", "block");
                    this.lbl_Deliveryfax.Style.Add("display", "block");
                    this.divDeliverycountry.Style.Add("display", "block");
                    this.divDeliveryphone.Style.Add("display", "block");
                    this.divDeliveryfax.Style.Add("display", "block");
                    this.div_edit_changeDelivery.Style.Add("display", "block");
                    DataTable dataTable5 = CompanyBasePage.company_client_select(this.CompanyID, this.ClientID, this.companytype);
                    foreach (DataRow row4 in dataTable5.Rows)
                    {
                        this.div_create_identical_contact.Visible = false;
                        this.lblEditCompany.Visible = true;
                        this.lblAddCompany.Visible = false;
                        this.txt_companyname.Text = this.basecls.SpecialDecode(row4["ClientName"].ToString());
                        this.txt_companyalias.Text = this.basecls.SpecialDecode(row4["ClientAlias"].ToString());
                        this.hdncmpnyaddressid.Value = this.basecls.SpecialDecode(row4["companyaddressid"].ToString());
                        string str2 = this.basecls.SpecialDecode(row4["companytypeID"].ToString());
                        string[] strArrays = str2.ToString().Split(new char[] { ',' });
                        string empty2 = string.Empty;
                        for (int k = 0; k < (int)strArrays.Length; k++)
                        {
                            foreach (RadComboBoxItem radComboBoxItem in this.ddl_type.Items)
                            {
                                CheckBox checkBox1 = (CheckBox)radComboBoxItem.FindControl("chk1");
                                if (strArrays[k] != radComboBoxItem.Value)
                                {
                                    continue;
                                }
                                checkBox1.Checked = true;
                                empty2 = string.Concat(empty2, radComboBoxItem.Text, ", ");
                            }
                        }
                        if (empty2 != "")
                        {
                            this.ddl_type.Text = empty2.Remove(empty2.Length - 2);
                        }
                        else
                        {
                            this.ddl_type.SelectedValue = "None";
                        }
                        this.ddl_status.SelectedValue = this.basecls.SpecialDecode(row4["AccountStatus"].ToString());
                        this.txt_accountno.Text = this.basecls.SpecialDecode(row4["AccountNumber"].ToString());
                        this.txt_email.Text = this.basecls.SpecialDecode(row4["BusinessEmail"].ToString());
                        this.txt_creditlimit.Text = this.basecls.SpecialDecode(row4["CreditLimit"].ToString());
                        this.txt_creditref.Text = this.basecls.SpecialDecode(row4["CreditRef"].ToString());
                        this.ddl_tax1.SelectedValue = this.basecls.SpecialDecode(row4["Tax1"].ToString());
                        this.ddl_tax2.SelectedValue = this.basecls.SpecialDecode(row4["Tax2"].ToString());
                        this.txt_taxregno.Text = this.basecls.SpecialDecode(row4["TaxRegNo"].ToString());
                        this.ddl_PaymentTerms.SelectedValue = this.basecls.SpecialDecode(row4["PaymentTerms"].ToString());
                        this.txt_companyno.Text = this.basecls.SpecialDecode(row4["CompanyNumber"].ToString());
                        this.txt_profitmargin.Text = (this.basecls.SpecialDecode(row4["ProfitMargin"].ToString()) == "0" ? "" : this.comncls.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row4["ProfitMargin"].ToString()), 0, "", false, false, true));
                        this.txt_acopened.Text = (row4["AcOpeneddate"].ToString() == "01/01/1900" ? "" : this.comncls.Eprint_return_Date_Before_View(row4["AcOpeneddate"].ToString(), this.CompanyID, this.UserID, false));
                        this.txt_bankcode.Text = this.basecls.SpecialDecode(row4["BankCode"].ToString());
                        this.txt_bankacno.Text = this.basecls.SpecialDecode(row4["BankAccountNumber"].ToString());
                        this.txt_accountname.Text = this.basecls.SpecialDecode(row4["AccountName"].ToString());
                        this.ddl_salesperson.SelectedValue = row4["SalesPerson"].ToString();
                        this.txt_taxnumber.Text = this.basecls.SpecialDecode(row4["TaxNumber"].ToString());
                        this.txt_balance.Text = this.basecls.SpecialDecode(row4["Balance"].ToString());
                        this.txt_description.Text = this.basecls.SpecialDecode(row4["Description"].ToString());
                        this.txt_email.Text = this.basecls.SpecialDecode(row4["BusinessEmail"].ToString());
                        this.txt_url.Text = this.basecls.SpecialDecode(row4["WebSite"].ToString());
                        this.txt_Referencedby.Text = this.basecls.SpecialDecode(row4["ReferencedName"].ToString());
                        this.ddl_Referencedby.SelectedValue = this.basecls.SpecialDecode(row4["ReferencedBy"].ToString());
                        this.ddl_Referencedby.SelectedItem.Text = this.basecls.SpecialDecode(this.ddl_Referencedby.SelectedItem.Text);
                        chkTaxPrecedence.Checked = Convert.ToBoolean(row4["TaxPrecedence"].ToString());
                        if (row4["Country"].ToString() != "")
                        {
                            this.ddl_Deliverycountry.SelectedIndex = this.ddl_Deliverycountry.Items.IndexOf(this.ddl_Deliverycountry.Items.FindByText(row4["Country"].ToString()));
                        }
                        else
                        {
                            this.ddl_Deliverycountry.SelectedIndex = Convert.ToInt32(this.hdn_selectedcounter.Value);
                        }
                        this.txt_Deliveryaddr1.Text = this.basecls.SpecialDecode(row4["Address"].ToString());
                        this.txt_Deliveryaddr2.Text = this.basecls.SpecialDecode(row4["AddressLine2"].ToString());
                        this.txt_Deliveryaddr3.Text = this.basecls.SpecialDecode(row4["City"].ToString());
                        this.txt_Deliveryaddr4.Text = this.basecls.SpecialDecode(row4["State"].ToString());
                        this.txt_Deliveryaddr5.Text = this.basecls.SpecialDecode(row4["ZipCode"].ToString());
                        this.txt_Deliveryphone.Text = this.basecls.SpecialDecode(row4["Telephone"].ToString());
                        this.txt_Deliveryfax.Text = this.basecls.SpecialDecode(row4["EditFax"].ToString());
                        if (row4["RoyalityFree"].ToString().ToLower() != "true")
                        {
                            this.ChkRoyalityFree.Checked = false;
                        }
                        else
                        {
                            this.ChkRoyalityFree.Checked = true;
                        }
                        if (Convert.ToInt32(row4["IsCarrier"]) != 1)
                        {
                            this.chkcarrier.Checked = false;
                        }
                        else
                        {
                            this.chkcarrier.Checked = true;
                        }
                    }
                    int num1 = 0;
                    this.hdn_DeliveryaddressID.Value = this.DeliveryAddressID.ToString();
                    DataTable dataTable6 = CompanyBasePage.address_select_For_Edit(this.CompanyID, Convert.ToInt32(this.DeliveryAddressID), this.UserID);
                    foreach (DataRow dataRow4 in dataTable6.Rows)
                    {
                        num1++;
                        if (dataRow4["Address"].ToString() == "")
                        {
                            this.lbl_Deliveryaddr1Value.Text = "";
                        }
                        else
                        {
                            this.lbl_Deliveryaddr1Value.Text = this.basecls.SpecialDecode(dataRow4["Address"].ToString());
                        }
                        if (dataRow4["AddressLine2"].ToString() == "")
                        {
                            this.lbl_Deliveryaddr2Value.Text = "";
                        }
                        else
                        {
                            this.lbl_Deliveryaddr2Value.Text = this.basecls.SpecialDecode(dataRow4["AddressLine2"].ToString());
                        }
                        if (dataRow4["City"].ToString() == "")
                        {
                            this.lbl_Deliveryaddr3Value.Text = "";
                        }
                        else
                        {
                            this.lbl_Deliveryaddr3Value.Text = this.basecls.SpecialDecode(dataRow4["City"].ToString());
                        }
                        if (dataRow4["State"].ToString() == "")
                        {
                            this.lbl_Deliveryaddr4Value.Text = "";
                        }
                        else
                        {
                            this.lbl_Deliveryaddr4Value.Text = this.basecls.SpecialDecode(dataRow4["State"].ToString());
                        }
                        if (dataRow4["ZipCode"].ToString() == "")
                        {
                            this.lbl_Deliveryaddr5Value.Text = "";
                        }
                        else
                        {
                            this.lbl_Deliveryaddr5Value.Text = this.basecls.SpecialDecode(dataRow4["ZipCode"].ToString());
                        }
                        if (dataRow4["Country"].ToString() == "")
                        {
                            this.lbl_DeliverycountryValue.Text = "";
                        }
                        else
                        {
                            this.lbl_DeliverycountryValue.Text = this.basecls.SpecialDecode(dataRow4["Country"].ToString());
                        }
                        if (dataRow4["Telephone"].ToString() == "")
                        {
                            this.lbl_DeliveryphoneValue.Text = "";
                        }
                        else
                        {
                            this.lbl_DeliveryphoneValue.Text = string.Concat("P: ", this.basecls.SpecialDecode(dataRow4["Telephone"].ToString()));
                        }
                        if (dataRow4["Fax"].ToString() == "")
                        {
                            this.lbl_DeliveryfaxValue.Text = "";
                        }
                        else
                        {
                            this.lbl_DeliveryfaxValue.Text = string.Concat("F: ", this.basecls.SpecialDecode(dataRow4["Fax"].ToString()));
                        }
                    }
                    if (num1 == 0)
                    {
                        this.lnk_DeliveryEdit.Style.Add("display", "none");
                        this.lbl_DeliverySpliter.Style.Add("display", "none");
                    }
                    int num2 = 0;
                    this.hdn_InvoiceaddressID.Value = this.InvoiceAddressID.ToString();
                    DataTable dataTable7 = CompanyBasePage.address_select_For_Edit(this.CompanyID, Convert.ToInt32(this.InvoiceAddressID), this.UserID);
                    foreach (DataRow row5 in dataTable7.Rows)
                    {
                        num2++;
                        if (row5["Address"].ToString() == "")
                        {
                            this.lbl_Invoiceaddr1Value.Text = "";
                        }
                        else
                        {
                            this.lbl_Invoiceaddr1Value.Text = this.basecls.SpecialDecode(row5["Address"].ToString());
                        }
                        if (row5["AddressLine2"].ToString() == "")
                        {
                            this.lbl_Invoiceaddr2Value.Text = "";
                        }
                        else
                        {
                            this.lbl_Invoiceaddr2Value.Text = this.basecls.SpecialDecode(row5["AddressLine2"].ToString());
                        }
                        if (row5["City"].ToString() == "")
                        {
                            this.lbl_Invoiceaddr3Value.Text = "";
                        }
                        else
                        {
                            this.lbl_Invoiceaddr3Value.Text = this.basecls.SpecialDecode(row5["City"].ToString());
                        }
                        if (row5["State"].ToString() == "")
                        {
                            this.lbl_Invoiceaddr4Value.Text = "";
                        }
                        else
                        {
                            this.lbl_Invoiceaddr4Value.Text = this.basecls.SpecialDecode(row5["State"].ToString());
                        }
                        if (row5["ZipCode"].ToString() == "")
                        {
                            this.lbl_Invoiceaddr5Value.Text = "";
                        }
                        else
                        {
                            this.lbl_Invoiceaddr5Value.Text = this.basecls.SpecialDecode(row5["ZipCode"].ToString());
                        }
                        if (row5["Country"].ToString() == "")
                        {
                            this.lbl_InvoicecountryValue.Text = "";
                        }
                        else
                        {
                            this.lbl_InvoicecountryValue.Text = this.basecls.SpecialDecode(row5["Country"].ToString());
                        }
                        if (row5["Telephone"].ToString() == "")
                        {
                            this.lbl_InvoicephoneValue.Text = "";
                        }
                        else
                        {
                            this.lbl_InvoicephoneValue.Text = string.Concat("P: ", this.basecls.SpecialDecode(row5["Telephone"].ToString()));
                        }
                        if (row5["Fax"].ToString() == "")
                        {
                            this.lbl_InvoicefaxValue.Text = "";
                        }
                        else
                        {
                            this.lbl_InvoicefaxValue.Text = string.Concat("F: ", this.basecls.SpecialDecode(row5["Fax"].ToString()));
                        }
                    }
                    if (num2 == 0)
                    {
                        this.lnk_InvoiceEdit.Style.Add("display", "none");
                        this.lbl_InvoiceSpliter.Style.Add("display", "none");
                    }
                }
            }
            this.btncancel.Text = this.objLangClass.GetLanguageConversion("Cancel");
            this.btnsave.Text = this.objLangClass.GetLanguageConversion("Save");
            if (base.Request.Params["sender"] != null && base.Request.Params["sender"].ToLower() == "popup")
            {
                this.content.Attributes.Remove("class");
                this.ColourPanel.Style.Add("display", "none");
            }
            if (base.Request.Params["esttype"] != null && base.Request.Params["esttype"].ToLower() == "o")
            {
                this.content.Attributes.Remove("class");
                this.ColourPanel.Style.Add("display", "none");
            }
            if (base.Request.Params["item"] != null && base.Request.Params["item"].ToLower() == "outwork")
            {
                this.content.Attributes.Remove("class");
                this.ColourPanel.Style.Add("display", "none");
            }
        }
    }
}