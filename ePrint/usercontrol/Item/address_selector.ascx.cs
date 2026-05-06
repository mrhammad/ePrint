using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Department;
using Printcenter.UI.Estimates;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;



namespace ePrint.usercontrol.Item
{
    public partial class address_selector : UsercontrolBasePage
    {
        private CompanyBasePage comnyobj = new CompanyBasePage();

        private commonClass comncls = new commonClass();

        public static BaseClass objBase;

        private languageClass objLanguage = new languageClass();

        private DataTable dtAllAddSelector = new DataTable();

        public string ImgPath = global.imagePath();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string mode = string.Empty;

        public string pg = string.Empty;

        public string type = string.Empty;

        public string wintype = string.Empty;

        public string companytype = "Customer";

        public string clickvalfromsplitaddress = string.Empty;

        public string checkdivfromsplit = "";

        public string pagenameDept = string.Empty;

        public string pagename = string.Empty;

        public string pageFrom = string.Empty;

        public string fromsplit = string.Empty;

        public string redirectTo = string.Empty;

        public string ParentPage = string.Empty;

        public string action = string.Empty;

        public string AddressTo = string.Empty;

        public string addresstype = string.Empty;

        public string Country = string.Empty;

        public string ContactAddress = string.Empty;

        public string DeliveryAddress = string.Empty;

        public string IsDel = "no";

        public string item = string.Empty;

        public string isDefaultPostBox = "false";

        public string isHideAddress = "N";

        public string controlid = string.Empty;

        public static string SalesPersonID;

        public static string IsEditOnlyHisRecords;

        public static int Filtering;

        public int companyid;

        public int userid;

        public int clientid;

        public int addressid;

        public int totalrec;

        public int pagesize = 25;

        public int rtn;

        public long EstimateID;

        public long retAddressID;

        public int ContactID;

        public int popuplevel;

        public int SetDefaultAddressID;

        public int cntDelete;

        public int cntDefault;

        public int id;

        public int NoOfAddress;

        public string RequiredAddress = string.Empty;

        public string DefaultCompany = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLangClass = new languageClass();

        public string DeliveryAddressTypeforPurchase = "A";

        private DataTable dtsearch = new DataTable();

        //public string WhereCondition = "";
        public static string WhereCondition = "";

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

        static address_selector()
        {
            address_selector.objBase = new BaseClass();
            address_selector.SalesPersonID = string.Empty;
            address_selector.IsEditOnlyHisRecords = string.Empty;
            address_selector.Filtering = 0;
        }

        public address_selector()
        {
        }

        protected void btnadd_OnClick(object sender, EventArgs e)
        {
            this.Country = (this.ddlcountry.SelectedItem.Text == "--- Select ---" ? "" : this.ddlcountry.SelectedItem.Text);
            if (base.Request.Params["addressid"] != null)
            {
                this.addressid = Convert.ToInt32(base.Request.Params["addressid"].ToString());
            }
            bool @checked = this.chkpostbox.Checked;
            this.isDefaultPostBox = @checked.ToString().ToLower();
            if (!this.chkhideaddress.Checked)
            {
                this.isHideAddress = "N";
            }
            else
            {
                this.isHideAddress = "Y";
            }
            if (this.mode != "edit")
            {
                CompanyBasePage companyBasePage = this.comnyobj;
                int num = this.companyid;
                int num1 = this.userid;
                int num2 = Convert.ToInt32(this.hid_ClientID.Value);
                string str = address_selector.objBase.SpecialEncode(this.txtaddress.Text.Trim());
                string str1 = address_selector.objBase.SpecialEncode(this.txt_city.Text.Trim());
                string str2 = address_selector.objBase.SpecialEncode(this.txt_suburb.Text.Trim());
                string str3 = address_selector.objBase.SpecialEncode(this.Country);
                string str4 = address_selector.objBase.SpecialEncode(this.txttelephone.Text.Trim());
                string str5 = address_selector.objBase.SpecialEncode(this.txtfax.Text.Trim());
                string str6 = address_selector.objBase.SpecialEncode(this.txt_postCode.Text.Trim());
                string str7 = address_selector.objBase.SpecialEncode(this.txtref.Text.Trim());
                string str8 = address_selector.objBase.SpecialEncode(this.txtemail.Text.Trim());
                bool flag = Convert.ToBoolean(this.chkemail.Checked);
                bool flag1 = Convert.ToBoolean(this.chkdelivery.Checked);
                bool flag2 = Convert.ToBoolean(this.chkbilling.Checked);
                DateTime now = DateTime.Now;
                this.rtn = companyBasePage.address_insert(num, num1, num2, str, str1, str2, str3, str4, str5, str6, str7, str8, flag, flag1, flag2, now.ToString(), Convert.ToBoolean(this.chkpostbox.Checked), address_selector.objBase.SpecialEncode(this.txt_AddressLabel.Text.Trim()), address_selector.objBase.SpecialEncode(this.txt_address2.Text.Trim()), address_selector.objBase.SpecialEncode(this.txtURL.Text.Trim()), this.isHideAddress);
            }
            else if (this.pg.ToLower() == "client" || this.pg.ToLower() == "contact" || this.pg.ToLower() == "estimate" || this.pg.ToLower() == "estimates" || this.pg.ToLower() == "deliverynote" || this.pg.ToLower() == "purchase")
            {
                this.comnyobj.address_update(this.companyid, this.userid, Convert.ToInt32(this.hid_ClientID.Value), this.addressid, address_selector.objBase.SpecialEncode(this.txtaddress.Text.Trim()), address_selector.objBase.SpecialEncode(this.txt_city.Text.Trim()), address_selector.objBase.SpecialEncode(this.txt_suburb.Text.Trim()), address_selector.objBase.SpecialEncode(this.Country), address_selector.objBase.SpecialEncode(this.txttelephone.Text.Trim()), address_selector.objBase.SpecialEncode(this.txtfax.Text.Trim()), address_selector.objBase.SpecialEncode(this.txt_postCode.Text.Trim()), address_selector.objBase.SpecialEncode(this.txtref.Text.Trim()), address_selector.objBase.SpecialEncode(this.txtemail.Text.Trim()), Convert.ToBoolean(this.chkemail.Checked), Convert.ToBoolean(this.chkdelivery.Checked), Convert.ToBoolean(this.chkbilling.Checked), Convert.ToBoolean(this.chkpostbox.Checked), address_selector.objBase.SpecialEncode(this.txt_AddressLabel.Text.Trim()), address_selector.objBase.SpecialEncode(this.txt_address2.Text.Trim()), address_selector.objBase.SpecialEncode(this.txtURL.Text.Trim()), this.isHideAddress);
            }
            this.hdnDeliveryToCompanyID.Value = this.hid_ClientID.Value;
            this.DefaultCompany = address_selector.objBase.SpecialEncode(this.txtName.Text);
            this.gridAddressSelector(this.companyid, this.clientid, this.hdnClearFilter.Value);
            if (base.Request.Params["mode"] != null)
            {
                if (base.Request.Params["mode"].ToString().ToLower() == "view")
                {
                    if (this.pagename.ToLower() == "contact" || this.pagename.ToLower() == "contactsh" || this.pagename.ToLower() == "dept" || this.pagename.ToLower() == "deptsh")
                    {
                        if (this.ParentPage != "newcontact" && this.ParentPage != "editcontact")
                        {
                            if (this.pagename.ToLower() != "deptsh")
                            {
                                HttpResponse response = base.Response;
                                object[] objArray = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&addressto=billing&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.rtn, "&parentpage=", this.redirectTo };
                                response.Redirect(string.Concat(objArray));
                            }
                            else
                            {
                                HttpResponse httpResponse = base.Response;
                                object[] objArray1 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&addressto=shipping&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.rtn, "&parentpage=", this.redirectTo };
                                httpResponse.Redirect(string.Concat(objArray1));
                            }
                        }
                        else if (this.pagename.ToLower() != "deptsh")
                        {
                            HttpResponse response1 = base.Response;
                            object[] contactID = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&addressto=billing&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&ContactID=", this.ContactID, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.rtn, "&parentpage=", this.ParentPage, "&item=", this.item, "&id=", this.id, "&wintype=", this.wintype };
                            response1.Redirect(string.Concat(contactID));
                        }
                        else
                        {
                            HttpResponse httpResponse1 = base.Response;
                            object[] contactID1 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&addressto=shipping&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&ContactID=", this.ContactID, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.rtn, "&parentpage=", this.ParentPage, "&item=", this.item, "&id=", this.id, "&wintype=", this.wintype };
                            httpResponse1.Redirect(string.Concat(contactID1));
                        }
                    }
                    if (this.pagename.ToLower() == "contactaddress")
                    {
                        if (this.action == "edit")
                        {
                            HttpResponse response2 = base.Response;
                            object[] contactID2 = new object[] { this.strSitepath, "contact/contact_add.aspx?clientid=", this.clientid, "&type=", this.pg, "&action=edit&contactaddressid=", this.rtn, "&contactid=", this.ContactID, "&wintype=", this.wintype, "&pg=", this.pg };
                            response2.Redirect(string.Concat(contactID2));
                        }
                        else if (this.pg != "estimate")
                        {
                            HttpResponse httpResponse2 = base.Response;
                            object[] objArray2 = new object[] { this.strSitepath, "contact/contact_add.aspx?clientid=", this.clientid, "&type=", this.pg, "&action=edit&contactaddressid=", this.rtn, "&contactid=", this.ContactID, "&pg=", this.pg, "&item=", this.item, "&id=", this.id, "&mode=add" };
                            httpResponse2.Redirect(string.Concat(objArray2));
                        }
                        else
                        {
                            HttpResponse response3 = base.Response;
                            object[] contactID3 = new object[] { this.strSitepath, "contact/contact_add.aspx?clientid=", this.clientid, "&pg=", this.pg, "&type=", this.pg, "&contactaddressid=", this.rtn, "&contactid=", this.ContactID, "&pagename=ContactAddress&mode=add" };
                            response3.Redirect(string.Concat(contactID3));
                        }
                    }
                }
                if (base.Request.Params["mode"].ToString().ToLower() == "add" || base.Request.Params["mode"].ToString().ToLower() == "edit")
                {
                    if (base.Request.Params["from"] != null)
                    {
                        if (base.Request.Params["from"].ToString().ToLower() == "dept" || base.Request.Params["from"].ToString().ToLower() == "deptsh" || base.Request.Params["from"].ToString().ToLower() == "clientchange")
                        {
                            this.pnl_Dept_Contact.Visible = true;
                        }
                        if (base.Request.Params["from"].ToString().ToLower() == "contacteditmode_edit")
                        {
                            if (this.wintype.ToLower() == "main")
                            {
                                if (!base.Request.Browser.Type.ToUpper().Contains("IE"))
                                {
                                    this.pnlSendAddressDetails.Visible = true;
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "GetRadWindow().BrowserWindow.location.reload();", true);
                                }
                            }
                            else if (base.Request.Params["mode"].ToString().ToLower() != "edit")
                            {
                                HttpResponse httpResponse3 = base.Response;
                                object[] objArray3 = new object[] { this.strSitepath, "contact/contact_add.aspx?&clientid=", this.clientid, "&type=", this.companytype, "&contactaddressid=", this.rtn, "&ContactID=", this.ContactID, "&pg=", this.pg };
                                httpResponse3.Redirect(string.Concat(objArray3));
                            }
                            else
                            {
                                HttpResponse response4 = base.Response;
                                object[] contactID4 = new object[] { this.strSitepath, "contact/contact_add.aspx?action=edit&clientid=", this.clientid, "&type=", this.companytype, "&addressid=", this.addressid, "&ContactID=", this.ContactID, "&pg=", this.pg };
                                response4.Redirect(string.Concat(contactID4));
                            }
                        }
                    }
                    else if (this.pagenameDept.ToLower() == "clientedit" || this.pagename.ToLower() == "contactedit" || this.pagename.ToLower() == "contacteditsh")
                    {
                        if (!base.Request.Browser.Type.ToUpper().Contains("IE"))
                        {
                            this.pnlSendAddressDetails.Visible = true;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "GetRadWindow().BrowserWindow.location.reload();", true);
                        }
                    }
                    else if (this.pagename.ToLower() == "deptaddmode")
                    {
                        if (this.ParentPage == "editcontact" || this.ParentPage == "newcontact")
                        {
                            HttpResponse httpResponse4 = base.Response;
                            object[] parentPage = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=billing&parentpage=", this.ParentPage, "&clientid=", this.clientid, "&mode=add&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ContactID=", this.ContactID, "&popuplevel=", this.popuplevel, "&item=", this.item, "&id=", this.id };
                            httpResponse4.Redirect(string.Concat(parentPage));
                        }
                        else
                        {
                            HttpResponse response5 = base.Response;
                            object[] objArray4 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=billing&clientid=", this.clientid, "&mode=add&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid };
                            response5.Redirect(string.Concat(objArray4));
                        }
                    }
                    else if (this.pagename.ToLower() == "depteditmode")
                    {
                        if (this.ParentPage == "editcontact" || this.ParentPage == "newcontact")
                        {
                            HttpResponse httpResponse5 = base.Response;
                            object[] parentPage1 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=billing&parentpage=", this.ParentPage, "&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ContactID=", this.ContactID };
                            httpResponse5.Redirect(string.Concat(parentPage1));
                        }
                        else
                        {
                            HttpResponse response6 = base.Response;
                            object[] objArray5 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=billing&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ParentPage=", this.pagename };
                            response6.Redirect(string.Concat(objArray5));
                        }
                    }
                    else if (this.pagename.ToLower() == "deptaddmodesh")
                    {
                        if (this.ParentPage == "editcontact" || this.ParentPage == "newcontact")
                        {
                            HttpResponse httpResponse6 = base.Response;
                            object[] parentPage2 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=newcontact&addressto=shipping&parentpage=", this.ParentPage, "&clientid=", this.clientid, "&mode=add&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ContactID=", this.ContactID, "&popuplevel=", this.popuplevel, "&item=", this.item, "&id=", this.id };
                            httpResponse6.Redirect(string.Concat(parentPage2));
                        }
                        else
                        {
                            HttpResponse response7 = base.Response;
                            object[] objArray6 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=shipping&clientid=", this.clientid, "&mode=add&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid };
                            response7.Redirect(string.Concat(objArray6));
                        }
                    }
                    else if (this.pagename.ToLower() != "depteditmodesh")
                    {
                        base.Session["AddAddress"] = "AddAddress";
                        if (!base.Request.Browser.Type.ToUpper().Contains("IE"))
                        {
                            this.pnlSendAddressDetails.Visible = true;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "GetRadWindow().BrowserWindow.location.reload();", true);
                        }
                    }
                    else if (this.ParentPage == "editcontact" || this.ParentPage == "newcontact")
                    {
                        HttpResponse httpResponse7 = base.Response;
                        object[] parentPage3 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=newcontact&addressto=shipping&parentpage=", this.ParentPage, "&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ContactID=", this.ContactID, "&wintype=", this.wintype };
                        httpResponse7.Redirect(string.Concat(parentPage3));
                    }
                    else
                    {
                        HttpResponse response8 = base.Response;
                        object[] objArray7 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=shipping&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ParentPage=", this.pagename };
                        response8.Redirect(string.Concat(objArray7));
                    }
                }
            }
            if (this.pagename.ToLower() == "" && this.pg.ToLower() == "estimate")
            {
                string[] strArrays = new string[] { address_selector.objBase.SpecialEncode(this.txtaddress.Text.Trim()), " ", address_selector.objBase.SpecialEncode(this.txt_address2.Text.Trim()), " ", address_selector.objBase.SpecialEncode(this.txt_city.Text.Trim()), " ", address_selector.objBase.SpecialEncode(this.txt_suburb.Text.Trim()), " ", address_selector.objBase.SpecialEncode(this.txt_postCode.Text.Trim()), " ", this.Country };
                this.ContactAddress = string.Concat(strArrays);
                this.pnl_ContactAddress.Visible = true;
            }
            if (this.pagename.ToLower() == "" && this.pg.ToLower() == "deliverynote")
            {
                string[] strArrays1 = new string[] { address_selector.objBase.SpecialEncode(this.txtaddress.Text.Trim()), " ", address_selector.objBase.SpecialEncode(this.txt_address2.Text.Trim()), " ", address_selector.objBase.SpecialEncode(this.txt_city.Text.Trim()), " ", address_selector.objBase.SpecialEncode(this.txt_suburb.Text.Trim()), " ", address_selector.objBase.SpecialEncode(this.txt_postCode.Text.Trim()), " ", this.Country };
                this.DeliveryAddress = string.Concat(strArrays1);
                this.Pnl_DeliveryNote.Visible = true;
            }
            if (this.pagename.ToLower() == "" && this.pg.ToLower() == "purchase")
            {
                string[] strArrays2 = new string[] { address_selector.objBase.SpecialEncode(this.txtaddress.Text.Trim()), " ", address_selector.objBase.SpecialEncode(this.txt_address2.Text.Trim()), " ", address_selector.objBase.SpecialEncode(this.txt_city.Text.Trim()), " ", address_selector.objBase.SpecialEncode(this.txt_suburb.Text.Trim()), " ", address_selector.objBase.SpecialEncode(this.txt_postCode.Text.Trim()), " ", this.Country };
                this.DeliveryAddress = string.Concat(strArrays2);
                this.Pnl_purchase.Visible = true;
            }
            if (this.pg.ToLower() == "job")
            {
                string[] strArrays3 = new string[] { address_selector.objBase.SpecialEncode(this.txtaddress.Text.Trim()), " ", address_selector.objBase.SpecialEncode(this.txt_address2.Text.Trim()), " ", address_selector.objBase.SpecialEncode(this.txt_city.Text.Trim()), " ", address_selector.objBase.SpecialEncode(this.txt_suburb.Text.Trim()), " ", address_selector.objBase.SpecialEncode(this.txt_postCode.Text.Trim()), " ", this.Country };
                this.DeliveryAddress = string.Concat(strArrays3);
                this.Pnl_job.Visible = true;
            }
            if (this.wintype == "popup")
            {
                QueryString queryString = new QueryString()
            {
                { "clientid", this.clientid.ToString() },
                { "isnew", "2" },
                { "bypass", "1" },
                { "type", this.companytype }
            };
                string str9 = string.Concat(this.strSitepath, "client/client_detail.aspx");
                QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                str9 = string.Concat(str9, queryString1.ToString());
                base.Response.Write(string.Concat("<script language='javascript' type='text/javascript'>window.close();parent.window.close();parent.parent.window.location.href='", str9, "';</script>"));
            }
            if (base.Request.Params["frm"] != null && base.Request.Params["frm"].ToString().ToLower() == "viewall")
            {
                if (this.type != "" && this.type.ToLower().Trim() == "deliveryaddress")
                {
                    HttpResponse httpResponse8 = base.Response;
                    object[] objArray8 = new object[] { this.strSitepath, "common/common_popup.aspx?type=deliveryaddress&mode=view&clientid=", this.clientid, "&pg=", this.pg };
                    httpResponse8.Redirect(string.Concat(objArray8));
                    return;
                }
                if (base.Request.Params["fromsplit"] != null)
                {
                    HttpResponse response9 = base.Response;
                    object[] estimateID = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=view&clientid=", this.clientid, "&pg=", this.pg, "&clickval=", this.clickvalfromsplitaddress, "&fromsplit=yes&Estid=", this.EstimateID, "&IsDel=", this.IsDel };
                    response9.Redirect(string.Concat(estimateID));
                    return;
                }
                HttpResponse httpResponse9 = base.Response;
                object[] objArray9 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=view&clientid=", this.clientid, "&pg=", this.pg };
                httpResponse9.Redirect(string.Concat(objArray9));
            }
        }

        protected void btnSaveAs_OnClick(object sender, EventArgs e)
        {
            string empty = string.Empty;
            empty = (this.ddlcountry.SelectedItem.Text == "--- Select ---" ? "" : this.ddlcountry.SelectedItem.Text);
            if (!this.chkhideaddress.Checked)
            {
                this.isHideAddress = "N";
            }
            else
            {
                this.isHideAddress = "Y";
            }
            long num = (long)0;
            long num1 = (long)this.clientid;
            string str = address_selector.objBase.SpecialEncode(this.txtaddress.Text.Trim());
            string str1 = address_selector.objBase.SpecialEncode(this.txt_city.Text.Trim());
            string str2 = address_selector.objBase.SpecialEncode(this.txt_suburb.Text.Trim());
            string str3 = address_selector.objBase.SpecialEncode(this.txt_postCode.Text.Trim());
            string str4 = address_selector.objBase.SpecialEncode(empty);
            string str5 = address_selector.objBase.SpecialEncode(this.txttelephone.Text.Trim());
            string str6 = address_selector.objBase.SpecialEncode(this.txtfax.Text.Trim());
            string str7 = address_selector.objBase.SpecialEncode(this.txtURL.Text.Trim());
            int num2 = this.userid;
            DateTime now = DateTime.Now;
            this.retAddressID = CompanyBasePage.CompanyDefaultAddress_InsertUpdate(num, num1, str, str1, str2, str3, str4, str5, str6, str7, num2, now.ToString(), address_selector.objBase.SpecialEncode(this.txt_AddressLabel.Text.Trim()), address_selector.objBase.SpecialEncode(this.txt_address2.Text.Trim()), address_selector.objBase.SpecialEncode(this.txtemail.Text.Trim()), this.isHideAddress);
            if (this.chkpostbox.Checked)
            {
                CompanyBasePage.SetDefaultAddressID(Convert.ToInt32(this.clientid), Convert.ToInt32(this.retAddressID));
            }
            this.addressid = Convert.ToInt32(this.retAddressID);
            if (this.pagename.ToLower() == "deptaddmode")
            {
                if (this.ParentPage == "editcontact" || this.ParentPage == "newcontact")
                {
                    HttpResponse response = base.Response;
                    object[] parentPage = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=billing&parentpage=", this.ParentPage, "&clientid=", this.clientid, "&mode=add&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ContactID=", this.ContactID, "&item=", this.item, "&id=", this.id };
                    response.Redirect(string.Concat(parentPage));
                }
                else
                {
                    HttpResponse httpResponse = base.Response;
                    object[] objArray = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=billing&clientid=", this.clientid, "&mode=add&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid };
                    httpResponse.Redirect(string.Concat(objArray));
                }
            }
            else if (this.pagename.ToLower() == "depteditmode")
            {
                if (this.ParentPage == "editcontact" || this.ParentPage == "newcontact")
                {
                    HttpResponse response1 = base.Response;
                    object[] parentPage1 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=billing&parentpage=", this.ParentPage, "&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ContactID=", this.ContactID };
                    response1.Redirect(string.Concat(parentPage1));
                }
                else
                {
                    HttpResponse httpResponse1 = base.Response;
                    object[] objArray1 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=billing&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ParentPage=", this.pagename };
                    httpResponse1.Redirect(string.Concat(objArray1));
                }
            }
            else if (this.pagename.ToLower() == "deptaddmodesh")
            {
                if (this.ParentPage == "editcontact" || this.ParentPage == "newcontact")
                {
                    HttpResponse response2 = base.Response;
                    object[] parentPage2 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=newcontact&addressto=shipping&parentpage=", this.ParentPage, "&clientid=", this.clientid, "&mode=add&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ContactID=", this.ContactID, "&item=", this.item, "&id=", this.id };
                    response2.Redirect(string.Concat(parentPage2));
                }
                else
                {
                    HttpResponse httpResponse2 = base.Response;
                    object[] objArray2 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=shipping&clientid=", this.clientid, "&mode=add&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid };
                    httpResponse2.Redirect(string.Concat(objArray2));
                }
            }
            else if (this.pagename.ToLower() == "depteditmodesh")
            {
                if (this.ParentPage == "editcontact" || this.ParentPage == "newcontact")
                {
                    HttpResponse response3 = base.Response;
                    object[] parentPage3 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=newcontact&addressto=shipping&parentpage=", this.ParentPage, "&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ContactID=", this.ContactID, "&popuplevel=", this.popuplevel, "&wintype=", this.wintype };
                    response3.Redirect(string.Concat(parentPage3));
                }
                else
                {
                    HttpResponse httpResponse3 = base.Response;
                    object[] objArray3 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=shipping&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ParentPage=", this.pagename };
                    httpResponse3.Redirect(string.Concat(objArray3));
                }
            }
            else if (base.Request.Params["from"] == null)
            {
                base.Session["AddAddress"] = "AddAddress";
            }
            else if (base.Request.Params["from"].ToString().ToLower() == "contacteditmode_edit")
            {
                if (this.action.ToLower() != "edit")
                {
                    HttpResponse response4 = base.Response;
                    object[] contactID = new object[] { this.strSitepath, "contact/contact_add.aspx?clientid=", this.clientid, "&type=", this.companytype, "&contactaddressid=", this.retAddressID, "&contactid=", this.ContactID };
                    response4.Redirect(string.Concat(contactID));
                }
                else
                {
                    HttpResponse httpResponse4 = base.Response;
                    object[] contactID1 = new object[] { this.strSitepath, "contact/contact_add.aspx?clientid=", this.clientid, "&type=", this.companytype, "&action=edit&contactaddressid=", this.retAddressID, "&contactid=", this.ContactID };
                    httpResponse4.Redirect(string.Concat(contactID1));
                }
            }
            if (!base.Request.Browser.Type.ToUpper().Contains("IE"))
            {
                this.pnlSendAddressDetails.Visible = true;
                return;
            }
            ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "GetRadWindow().BrowserWindow.location.reload();", true);
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            WhereCondition = "";
            this.Session["search_CustAddress"] = null;

            this.hdnClearFilter.Value = "no";
            foreach (GridColumn column in this.RadGrid_AddressSelector.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.RadGrid_AddressSelector.MasterTableView.FilterExpression = string.Empty;
            this.RadGrid_AddressSelector.Rebind();
        }

        public void gridAddressSelector(int CompanyID, int ClientID, string isFilter)
        {
            this.dtAllAddSelector = DepartmentBaseClass.address_select(ClientID, CompanyID, isFilter);
            this.RadGrid_AddressSelector.DataSource = this.dtAllAddSelector;
            this.RadGrid_AddressSelector.DataBind();
        }

        private void GridStateLoad()
        {
            this.comncls.GridStateLoadNew("Address", "AddressSelector", this.RadGrid_AddressSelector, "no");
        }

        private void GridStateSave()
        {
            this.comncls.GridStateSaveNew("Address", "AddressSelector", this.RadGrid_AddressSelector);
        }

        protected void OnClick_btncancel(object sender, EventArgs e)
        {
            if (this.pagename.ToLower() == "deptaddmode")
            {
                if (!(this.ParentPage == "editcontact") && !(this.ParentPage == "newcontact"))
                {
                    HttpResponse response = base.Response;
                    object[] objArray = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=billing&clientid=", this.clientid, "&mode=add&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid };
                    response.Redirect(string.Concat(objArray));
                    return;
                }
                HttpResponse httpResponse = base.Response;
                object[] parentPage = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=billing&parentpage=", this.ParentPage, "&clientid=", this.clientid, "&mode=add&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ContactID=", this.ContactID };
                httpResponse.Redirect(string.Concat(parentPage));
                return;
            }
            if (this.pagename.ToLower() == "depteditmode")
            {
                if (!(this.ParentPage == "editcontact") && !(this.ParentPage == "newcontact"))
                {
                    HttpResponse response1 = base.Response;
                    object[] objArray1 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=billing&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ParentPage=", this.pagename };
                    response1.Redirect(string.Concat(objArray1));
                    return;
                }
                HttpResponse httpResponse1 = base.Response;
                object[] parentPage1 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=billing&parentpage=", this.ParentPage, "&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ContactID=", this.ContactID, "&popuplevel=", this.popuplevel };
                httpResponse1.Redirect(string.Concat(parentPage1));
                return;
            }
            if (this.pagename.ToLower() == "deptaddmodesh")
            {
                if (!(this.ParentPage == "editcontact") && !(this.ParentPage == "newcontact"))
                {
                    HttpResponse response2 = base.Response;
                    object[] objArray2 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=shipping&clientid=", this.clientid, "&mode=add&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid };
                    response2.Redirect(string.Concat(objArray2));
                    return;
                }
                HttpResponse httpResponse2 = base.Response;
                object[] parentPage2 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=newcontact&addressto=shipping&parentpage=", this.ParentPage, "&clientid=", this.clientid, "&mode=add&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ContactID=", this.ContactID };
                httpResponse2.Redirect(string.Concat(parentPage2));
                return;
            }
            if (this.pagename.ToLower() != "depteditmodesh")
            {
                if (base.Request.Params["from"] == null)
                {
                    if (base.Request.Browser.Type.ToUpper().Contains("IE"))
                    {
                        ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "GetRadWindow().BrowserWindow.location.reload();", true);
                        return;
                    }
                    this.pnlSendAddressDetails.Visible = true;
                }
                else if (base.Request.Params["from"].ToString().ToLower() == "contacteditmode_edit")
                {
                    if (this.action.ToLower() == "edit")
                    {
                        HttpResponse response3 = base.Response;
                        object[] contactID = new object[] { this.strSitepath, "contact/contact_add.aspx?clientid=", this.clientid, "&type=", this.companytype, "&action=edit&contactaddressid=", this.retAddressID, "&contactid=", this.ContactID };
                        response3.Redirect(string.Concat(contactID));
                        return;
                    }
                    HttpResponse httpResponse3 = base.Response;
                    object[] contactID1 = new object[] { this.strSitepath, "contact/contact_add.aspx?clientid=", this.clientid, "&type=", this.companytype, "&contactaddressid=", this.retAddressID, "&contactid=", this.ContactID };
                    httpResponse3.Redirect(string.Concat(contactID1));
                    return;
                }
                return;
            }
            if (!(this.ParentPage == "editcontact") && !(this.ParentPage == "newcontact"))
            {
                HttpResponse response4 = base.Response;
                object[] objArray3 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=shipping&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ParentPage=", this.pagename };
                response4.Redirect(string.Concat(objArray3));
                return;
            }
            HttpResponse httpResponse4 = base.Response;
            object[] parentPage3 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=newcontact&addressto=shipping&parentpage=", this.ParentPage, "&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ContactID=", this.ContactID };
            httpResponse4.Redirect(string.Concat(parentPage3));
        }

        protected void OnClick_btncancel_addressSelector(object sender, EventArgs e)
        {
            if (base.Request.Params["mode"] != null)
            {
                if (base.Request.Params["mode"].ToString().ToLower() == "view")
                {
                    if (this.pagename.ToLower() == "contact" || this.pagename.ToLower() == "contactsh" || this.pagename.ToLower() == "dept" || this.pagename.ToLower() == "deptsh")
                    {
                        if (this.ParentPage != "newcontact" && this.ParentPage != "editcontact")
                        {
                            base.Session["DeptInvoice"] = null;
                            if (this.pagename.ToLower() != "deptsh")
                            {
                                HttpResponse response = base.Response;
                                object[] objArray = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&addressto=billing&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.rtn, "&parentpage=", this.redirectTo };
                                response.Redirect(string.Concat(objArray));
                            }
                            else
                            {
                                HttpResponse httpResponse = base.Response;
                                object[] objArray1 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&addressto=shipping&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.rtn, "&parentpage=", this.redirectTo };
                                httpResponse.Redirect(string.Concat(objArray1));
                            }
                        }
                        else if (this.pg.ToLower() != "invoice")
                        {
                            if (this.pagename.ToLower() != "deptsh")
                            {
                                HttpResponse response1 = base.Response;
                                object[] parentPage = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=billing&parentpage=", this.ParentPage, "&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ContactID=", this.ContactID, "&popuplevel=", this.popuplevel };
                                response1.Redirect(string.Concat(parentPage));
                            }
                            else
                            {
                                HttpResponse httpResponse1 = base.Response;
                                object[] parentPage1 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=newcontact&addressto=shipping&parentpage=", this.ParentPage, "&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ContactID=", this.ContactID };
                                httpResponse1.Redirect(string.Concat(parentPage1));
                            }
                        }
                        else if (this.pagename.ToLower() == "deptsh")
                        {
                            if (this.ParentPage == "editcontact" || this.ParentPage == "newcontact")
                            {
                                HttpResponse response2 = base.Response;
                                object[] parentPage2 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=newcontact&addressto=shipping&parentpage=", this.ParentPage, "&clientid=", this.clientid, "&mode=add&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ContactID=", this.ContactID };
                                response2.Redirect(string.Concat(parentPage2));
                            }
                            else
                            {
                                HttpResponse httpResponse2 = base.Response;
                                object[] objArray2 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=shipping&clientid=", this.clientid, "&mode=add&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid };
                                httpResponse2.Redirect(string.Concat(objArray2));
                            }
                        }
                        else if (this.ParentPage == "editcontact" || this.ParentPage == "newcontact")
                        {
                            HttpResponse response3 = base.Response;
                            object[] parentPage3 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=newcontact&addressto=shipping&parentpage=", this.ParentPage, "&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ContactID=", this.ContactID };
                            response3.Redirect(string.Concat(parentPage3));
                        }
                        else
                        {
                            HttpResponse httpResponse3 = base.Response;
                            object[] objArray3 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=shipping&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ParentPage=", this.pagename };
                            httpResponse3.Redirect(string.Concat(objArray3));
                        }
                    }
                    if (this.pagename.ToLower() == "contactaddress")
                    {
                        if (this.action == "edit")
                        {
                            HttpResponse response4 = base.Response;
                            object[] contactID = new object[] { this.strSitepath, "contact/contact_add.aspx?clientid=", this.clientid, "&type=", this.pg, "&action=edit&contactaddressid=", this.rtn, "&contactid=", this.ContactID, "&wintype=", this.wintype };
                            response4.Redirect(string.Concat(contactID));
                        }
                        else if (this.pg != "estimate")
                        {
                            HttpResponse httpResponse4 = base.Response;
                            object[] contactID1 = new object[] { this.strSitepath, "contact/contact_add.aspx?clientid=", this.clientid, "&type=", this.pg, "&contactaddressid=", this.rtn, "&contactid=", this.ContactID, "&pg=", this.pg };
                            httpResponse4.Redirect(string.Concat(contactID1));
                        }
                        else
                        {
                            HttpResponse response5 = base.Response;
                            object[] contactID2 = new object[] { this.strSitepath, "contact/contact_add.aspx?clientid=", this.clientid, "&pg=", this.pg, "&type=", this.pg, "&contactaddressid=", this.rtn, "&contactid=", this.ContactID, "&pagename=ContactAddress&mode=add" };
                            response5.Redirect(string.Concat(contactID2));
                        }
                    }
                }
                if (base.Request.Params["mode"].ToString().ToLower() == "add" || base.Request.Params["mode"].ToString().ToLower() == "edit")
                {
                    if (base.Request.Params["from"] == null)
                    {
                        if (this.pagenameDept.ToLower() == "clientedit" || this.pagename.ToLower() == "contactedit" || this.pagename.ToLower() == "contacteditsh")
                        {
                            if (!base.Request.Browser.Type.ToUpper().Contains("IE"))
                            {
                                this.pnlSendAddressDetails.Visible = true;
                                return;
                            }
                            ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "GetRadWindow().BrowserWindow.location.reload();", true);
                            return;
                        }
                        if (this.pagename.ToLower() == "deptaddmode")
                        {
                            if (!(this.ParentPage == "editcontact") && !(this.ParentPage == "newcontact"))
                            {
                                HttpResponse httpResponse5 = base.Response;
                                object[] objArray4 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=billing&clientid=", this.clientid, "&mode=add&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid };
                                httpResponse5.Redirect(string.Concat(objArray4));
                                return;
                            }
                            HttpResponse response6 = base.Response;
                            object[] parentPage4 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=billing&parentpage=", this.ParentPage, "&clientid=", this.clientid, "&mode=add&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ContactID=", this.ContactID, "&popuplevel=", this.popuplevel };
                            response6.Redirect(string.Concat(parentPage4));
                            return;
                        }
                        if (this.pagename.ToLower() == "depteditmode")
                        {
                            if (!(this.ParentPage == "editcontact") && !(this.ParentPage == "newcontact"))
                            {
                                HttpResponse httpResponse6 = base.Response;
                                object[] objArray5 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=billing&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ParentPage=", this.pagename };
                                httpResponse6.Redirect(string.Concat(objArray5));
                                return;
                            }
                            HttpResponse response7 = base.Response;
                            object[] parentPage5 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=billing&parentpage=", this.ParentPage, "&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ContactID=", this.ContactID };
                            response7.Redirect(string.Concat(parentPage5));
                            return;
                        }
                        if (this.pagename.ToLower() == "deptaddmodesh")
                        {
                            if (!(this.ParentPage == "editcontact") && !(this.ParentPage == "newcontact"))
                            {
                                HttpResponse httpResponse7 = base.Response;
                                object[] objArray6 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=shipping&clientid=", this.clientid, "&mode=add&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid };
                                httpResponse7.Redirect(string.Concat(objArray6));
                                return;
                            }
                            HttpResponse response8 = base.Response;
                            object[] parentPage6 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=newcontact&addressto=shipping&parentpage=", this.ParentPage, "&clientid=", this.clientid, "&mode=add&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ContactID=", this.ContactID, "&popuplevel=", this.popuplevel };
                            response8.Redirect(string.Concat(parentPage6));
                            return;
                        }
                        if (this.pagename.ToLower() == "depteditmodesh")
                        {
                            if (!(this.ParentPage == "editcontact") && !(this.ParentPage == "newcontact"))
                            {
                                HttpResponse httpResponse8 = base.Response;
                                object[] objArray7 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=shipping&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ParentPage=", this.pagename };
                                httpResponse8.Redirect(string.Concat(objArray7));
                                return;
                            }
                            HttpResponse response9 = base.Response;
                            object[] parentPage7 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&from=newcontact&addressto=shipping&parentpage=", this.ParentPage, "&clientid=", this.clientid, "&mode=edit&pg=", this.pg, "&companytype=", this.companytype, "&Pgtype=", this.pg, "&addressID=", this.addressid, "&ContactID=", this.ContactID };
                            response9.Redirect(string.Concat(parentPage7));
                            return;
                        }
                        if (base.Request.Browser.Type.ToUpper().Contains("IE"))
                        {
                            ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "GetRadWindow().BrowserWindow.location.reload();", true);
                            return;
                        }
                        this.pnlSendAddressDetails.Visible = true;
                    }
                    else
                    {
                        if (base.Request.Params["from"].ToString().ToLower() == "dept" || base.Request.Params["from"].ToString().ToLower() == "deptsh" || base.Request.Params["from"].ToString().ToLower() == "clientchange")
                        {
                            this.pnl_Dept_Contact.Visible = true;
                        }
                        if (base.Request.Params["from"].ToString().ToLower() == "contacteditmode_edit")
                        {
                            if (this.wintype.ToLower() == "main")
                            {
                                if (!base.Request.Browser.Type.ToUpper().Contains("IE"))
                                {
                                    this.pnlSendAddressDetails.Visible = true;
                                    return;
                                }
                                ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "GetRadWindow().BrowserWindow.location.reload();", true);
                                return;
                            }
                            if (base.Request.Params["mode"].ToString().ToLower() == "edit")
                            {
                                HttpResponse httpResponse9 = base.Response;
                                object[] contactID3 = new object[] { this.strSitepath, "contact/contact_add.aspx?action=edit&clientid=", this.clientid, "&type=", this.companytype, "&addressid=", this.addressid, "&ContactID=", this.ContactID, "&pg=", this.pg };
                                httpResponse9.Redirect(string.Concat(contactID3));
                                return;
                            }
                            HttpResponse response10 = base.Response;
                            object[] contactID4 = new object[] { this.strSitepath, "contact/contact_add.aspx?&clientid=", this.clientid, "&type=", this.companytype, "&contactaddressid=", this.rtn, "&ContactID=", this.ContactID, "&pg=", this.pg };
                            response10.Redirect(string.Concat(contactID4));
                            return;
                        }
                    }
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.RadGrid_AddressSelector.FilterMenu;
            for (int i = filterMenu.Items.Count - 1; i >= 0; i--)
            {
                if (filterMenu.Items[i].Text == "Custom")
                {
                    filterMenu.Items[i].Text = "Custom-Text (ThisWeek)";
                }
                if (filterMenu.Items[i].Text.ToLower() == "isempty")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notisempty")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "isnull")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notisnull")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "between")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notbetween")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "nofilter")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("NoFilter");
                }
                if (filterMenu.Items[i].Text.ToLower() == "contains")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("Contains");
                }
                if (filterMenu.Items[i].Text.ToLower() == "doesnotcontain")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("DoesNotContain");
                }
                if (filterMenu.Items[i].Text.ToLower() == "startswith")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("StartsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "endswith")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("EndsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "equalto")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.GridStateSave();
            this.txtaddress.Focus();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.RadGrid_AddressSelector.Columns[0].HeaderText = this.objLangClass.GetLanguageConversion("Company_Name").ToString();
            this.RadGrid_AddressSelector.Columns[1].HeaderText = this.objLangClass.GetLanguageConversion("Address_Label").ToString();
            this.RadGrid_AddressSelector.Columns[2].HeaderText = this.objLangClass.GetLanguageConversion("Address").ToString();
            this.RadGrid_AddressSelector.Columns[3].HeaderText = this.objLangClass.GetLanguageConversion("Telephone").ToString();
            BaseClass baseClass = new BaseClass();
            this.companyid = Convert.ToInt32(base.Session["companyid"].ToString());
            this.userid = Convert.ToInt32(base.Session["userid"].ToString());
            this.txtaddress.Focus();
            foreach (DataRow row in this.comnyobj.Clientaddresslabels(this.companyid).Rows)
            {
                if (row["addresslkey"].ToString().ToLower() == "address1")
                {
                    if (row["addressvalue"].ToString() == "")
                    {
                        this.lbl_Address1.Text = this.objLangClass.GetLanguageConversion("Address1");
                    }
                    else
                    {
                        this.lbl_Address1.Text = row["addressvalue"].ToString();
                    }
                    if (row["isRequired"].ToString().ToLower() == "true")
                    {
                        this.lbl_Address1.Text = string.Concat(this.lbl_Address1.Text, "<span style='color: red;'>&nbsp;*</span>");
                        this.RequiredAddress = string.Concat(this.RequiredAddress, "1,");
                    }
                }
                if (row["addresslkey"].ToString().ToLower() == "address2")
                {
                    if (row["addressvalue"].ToString() == "")
                    {
                        this.lbl_Address2.Text = this.objLangClass.GetLanguageConversion("Address2");
                    }
                    else
                    {
                        this.lbl_Address2.Text = row["addressvalue"].ToString();
                    }
                    if (row["isRequired"].ToString().ToLower() == "true")
                    {
                        this.lbl_Address2.Text = string.Concat(this.lbl_Address2.Text, "<span style='color: red;'>&nbsp;*</span>");
                        this.RequiredAddress = string.Concat(this.RequiredAddress, "2,");
                    }
                }
                if (row["addresslkey"].ToString().ToLower() == "address3")
                {
                    if (row["addressvalue"].ToString() == "")
                    {
                        this.lbl_Address3.Text = this.objLangClass.GetLanguageConversion("Address3");
                    }
                    else
                    {
                        this.lbl_Address3.Text = row["addressvalue"].ToString();
                    }
                    if (row["isRequired"].ToString().ToLower() == "true")
                    {
                        this.lbl_Address3.Text = string.Concat(this.lbl_Address3.Text, "<span style='color: red;'>&nbsp;*</span>");
                        this.RequiredAddress = string.Concat(this.RequiredAddress, "3,");
                    }
                }
                if (row["addresslkey"].ToString().ToLower() == "address4")
                {
                    if (row["addressvalue"].ToString() == "")
                    {
                        this.lbl_Address4.Text = this.objLangClass.GetLanguageConversion("Address4");
                    }
                    else
                    {
                        this.lbl_Address4.Text = row["addressvalue"].ToString();
                    }
                    if (row["isRequired"].ToString().ToLower() == "true")
                    {
                        this.lbl_Address4.Text = string.Concat(this.lbl_Address4.Text, "<span style='color: red;'>&nbsp;*</span>");
                        this.RequiredAddress = string.Concat(this.RequiredAddress, "4,");
                    }
                }
                if (row["addresslkey"].ToString().ToLower() != "address5")
                {
                    continue;
                }
                if (row["addressvalue"].ToString() == "")
                {
                    this.lbl_Address5.Text = this.objLangClass.GetLanguageConversion("Address5");
                }
                else
                {
                    this.lbl_Address5.Text = row["addressvalue"].ToString();
                }
                if (row["isRequired"].ToString().ToLower() != "true")
                {
                    continue;
                }
                this.lbl_Address5.Text = string.Concat(this.lbl_Address5.Text, "<span style='color: red;'>&nbsp;*</span>");
                this.RequiredAddress = string.Concat(this.RequiredAddress, "5,");
            }
            if (base.Request.Params["type"] != null)
            {
                this.type = base.Request.Params["type"].ToString().ToLower();
            }
            if (base.Request.QueryString["action"] != null)
            {
                this.action = base.Request.QueryString["action"].ToString();
            }
            if (base.Request.QueryString["mode"] != null)
            {
                this.mode = base.Request.QueryString["mode"].ToString();
            }
            if (base.Request.QueryString["pg"] != null)
            {
                this.pg = base.Request.QueryString["pg"].ToString();
            }
            if (base.Request.QueryString["addresstype"] != null)
            {
                this.addresstype = base.Request.QueryString["addresstype"].ToString();
            }
            if (base.Request.QueryString["pagename"] != null)
            {
                this.pagenameDept = base.Request.QueryString["pagename"].ToString();
                this.pagename = base.Request.QueryString["pagename"].ToString();
            }
            if (base.Request.QueryString["pagenameDept"] != null)
            {
                this.pagenameDept = base.Request.QueryString["pagenameDept"].ToString();
            }
            if (base.Request.Params["clientid"] != null)
            {
                this.clientid = Convert.ToInt32(base.Request.Params["clientid"]);
            }
            if (base.Request.Params["Estid"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["Estid"]);
            }
            if (base.Request.Params["fromsplit"] != null)
            {
                this.checkdivfromsplit = base.Request.Params["fromsplit"].ToString();
            }
            if (base.Request.Params["clickval"] != null)
            {
                this.clickvalfromsplitaddress = base.Request.Params["clickval"].ToString();
            }
            if (base.Request.Params["IsDel"] != null)
            {
                this.IsDel = base.Request.Params["IsDel"].ToString();
            }
            if (base.Request.Params["wintype"] != null)
            {
                this.wintype = base.Request.Params["wintype"].ToString();
            }
            if (base.Request.Params["companytype"] != null)
            {
                this.companytype = base.Request.Params["companytype"].ToString();
            }
            if (base.Request.Params["frm"] != null)
            {
                this.pageFrom = base.Request.Params["frm"].ToString();
            }
            if (base.Request.Params["fromsplit"] != null)
            {
                this.fromsplit = base.Request.Params["fromsplit"].ToString();
            }
            if (base.Request.Params["from"] != null)
            {
                this.redirectTo = base.Request.Params["from"].ToString();
            }
            if (base.Request.Params["parentpage"] != null)
            {
                this.ParentPage = base.Request.Params["parentpage"].ToString();
            }
            if (base.Request.Params["ContactID"] != null)
            {
                this.ContactID = Convert.ToInt32(base.Request.Params["ContactID"].ToString());
            }
            if (base.Request.Params["addressto"] != null)
            {
                this.AddressTo = base.Request.Params["addressto"].ToString();
            }
            if (base.Request.Params["controlid"] != null)
            {
                this.controlid = base.Request.Params["controlid"].ToString();
            }
            if (this.companytype.ToString() != null && this.companytype.ToString().ToLower().Trim() == "supplier")
            {
                this.chkbilling.Text = "This is the default PO address.";
            }
            if (base.Request.Params["item"] != null)
            {
                this.item = base.Request.Params["item"].ToString().ToLower().Trim();
            }
            if (base.Request.Params["id"] != null)
            {
                this.id = Convert.ToInt32(base.Request.Params["id"]);
            }
            if (base.Request.Params["isViewAllCompanyAddress"] != null)
            {
                this.hdnisViewAllCompanyAddress.Value = base.Request.Params["isViewAllCompanyAddress"].ToString();
            }
            if (base.Request.Params["popuplevel"] != null)
            {
                this.popuplevel = Convert.ToInt32(base.Request.Params["popuplevel"]);
            }
            string str = "-1";
            if (base.Request.Params["DeliveryToID"] != null)
            {
                str = base.Request.Params["DeliveryToID"].ToString();
            }
            if (this.addresstype.Trim().ToLower() == "delivery" && this.pg.Trim().ToLower() == "purchase")
            {
                if (str == "0")
                {
                    this.hdnClearFilter.Value = "no";
                }
                this.DeliveryAddressTypeforPurchase = "C";
            }
            if (Convert.ToInt32(str) > 0)
            {
                this.clientid = Convert.ToInt32(str);
            }
            if (this.companytype == "customer")
            {
                this.DivHideAddress.Attributes.Add("style", "display:block");
            }
            this.txtName.Focus();
            this.txtName.Attributes.Add("autocomplete", "off");
            if (ConnectionClass.DeliveryNote == null)
            {
                this.div_delivery.Visible = false;
            }
            else
            {
                this.div_delivery.Visible = true;
            }
            if (this.pagename.ToLower() == "dept" || this.pagename.ToLower() == "deptsh")
            {
                this.btncancel_addressSelector.Style.Add("display", "block");
            }
            if (this.redirectTo.ToLower() == "contacteditmode_edit" || this.redirectTo.ToLower() == "contacteditmode_ch")
            {
                this.btncancel_addressSelector.Style.Add("display", "block");
            }
            if (this.pg.ToLower() == "client" || this.hdnisViewAllCompanyAddress.Value.Trim().ToLower() != "yes")
            {
                this.RadGrid_AddressSelector.MasterTableView.Columns[0].Visible = false;
            }
            else if ((this.pg.ToLower() == "estimate" || this.pg.ToLower() == "purchase" || this.pg.ToLower() == "deliverynote") && this.hdnisViewAllCompanyAddress.Value.Trim().ToLower() == "yes")
            {
                this.RadGrid_AddressSelector.MasterTableView.Columns[0].Visible = true;
            }
            if (!base.IsPostBack)
            {
                this.comnyobj.company_country_select(this.ddlcountry);
                if (this.mode.ToLower() == "add" || this.mode.ToLower() == "view" || this.mode.ToLower() == "edit")
                {
                    foreach (DataRow dataRow in SettingsBasePage.settings_companyprofile_select(this.companyid).Rows)
                    {
                        for (int i = 0; i < this.ddlcountry.Items.Count; i++)
                        {
                            if (this.ddlcountry.Items[i].Text == dataRow["Country"].ToString())
                            {
                                this.ddlcountry.SelectedIndex = i;
                            }
                        }
                    }
                }
                AttributeCollection attributes = this.txtName.Attributes;
                object[] value = new object[] { "javascript:displayClient(this,'customer','", this.companyid, "','1',event,'", this.hdnisViewAllCompanyAddress.Value, "');" };
                attributes.Add("onkeyup", string.Concat(value));
                AttributeCollection attributeCollection = this.txtName.Attributes;
                object[] objArray = new object[] { "javascript:displayClient(this,'customer','", this.companyid, "','1',event,'", this.hdnisViewAllCompanyAddress.Value, "'); " };
                attributeCollection.Add("onclick", string.Concat(objArray));
                this.GridStateLoad();
            }
            if (this.pg.ToLower() == "client")
            {
                this.div_CompanyName.Style.Add("display", "none");
                this.div_note.Style.Add("display", "none");
            }
            else if (this.hdnisViewAllCompanyAddress.Value.Trim().ToLower() != "yes")
            {
                this.div_CompanyName.Style.Add("display", "none");
                this.div_note.Style.Add("display", "none");
            }
            else
            {
                this.div_CompanyName.Style.Add("display", "Block");
                this.div_note.Style.Add("display", "Block");
            }
            if (this.type.ToLower() == "moreaddress" && this.mode.ToLower() == "add")
            {
                this.btnSaveAs.Style.Add("display", "none");
                this.div_add.Style.Add("display", "block");
                this.div_RadGrid_AddressSelector.Style.Add("display", "none");
            }
            
            if (this.pg.ToLower() == "client" || this.pg.ToLower() == "jobs" || this.pg.ToLower() == "invoice" || this.pg.ToLower() == "estimates" || this.mode.ToLower() == "edit" && (this.pg.ToLower() == "estimate" || this.pg.ToLower() == "estimates" || this.pg.ToLower() == "deliverynote" || this.pg.ToLower() == "purchase" || this.pg.ToLower() == "jobs" || this.pg.ToLower() == "invoice") || this.pg.ToLower() == "contact" && this.pagename.ToLower() == "contactedit" || this.pagename.ToLower() == "contacteditsh")
            {
                if (this.pagenameDept.ToLower() == "dept" || this.pagenameDept.ToLower() == "deptsh" || this.pagenameDept.ToLower() == "clientchange" || this.pagenameDept.ToLower() == "contactaddress")
                {
                    this.div_add.Style.Add("display", "none");
                    this.div_RadGrid_AddressSelector.Style.Add("display", "block");
                }
                else if (!(this.type.ToLower() == "moreaddress") || !(this.mode.ToLower() == "add"))
                {
                    this.lbl_Note.Visible = true;
                    this.btnSaveAs.Style.Add("display", "block");
                    this.btnadd.Text = this.objLangClass.GetLanguageConversion("Update");
                    this.btnadd.Style.Add("width", "49px");
                    this.btnadd.Style.Add("padding-left", "4px");
                    this.div_add.Style.Add("display", "block");
                    this.div_RadGrid_AddressSelector.Style.Add("display", "none");
                }
                else
                {
                    this.btnSaveAs.Style.Add("display", "none");
                }
                if (this.mode.ToLower() == "edit")
                {
                    this.lbl_Note.Visible = true;
                    if (base.Request.Params["addressid"] != null)
                    {
                        this.addressid = Convert.ToInt32(base.Request.Params["addressid"].ToString());
                        this.comnyobj.address_select(this.companyid, this.userid, Convert.ToInt32(base.Request.Params["addressid"]), this.txtaddress, this.txt_city, this.txt_suburb, this.ddlcountry, this.txttelephone, this.txtfax, this.txt_postCode, this.txtref, this.txtemail, this.chkemail, this.chkdelivery, this.chkbilling, this.chkpostbox, this.txt_AddressLabel, this.txt_address2, this.txtURL, this.chkhideaddress);
                    }
                    if (this.pagenameDept.ToLower() == "clientedit" || this.pagename.ToLower() == "contactedit" || this.pagename.ToLower() == "contacteditsh" || this.pagename.ToLower() == "deptedit" || this.pagename.ToLower() == "depteditsh")
                    {
                        this.btnSaveAs.Style.Add("display", "block");
                    }
                }
                if (this.mode.ToLower() == "add" && base.Request.Params["addressid"] != null)
                {
                    this.addressid = Convert.ToInt32(base.Request.Params["addressid"].ToString());
                    this.comnyobj.address_select(this.companyid, this.userid, Convert.ToInt32(base.Request.Params["addressid"]), this.txtaddress, this.txt_city, this.txt_suburb, this.ddlcountry, this.txttelephone, this.txtfax, this.txt_postCode, this.txtref, this.txtemail, this.chkemail, this.chkdelivery, this.chkbilling, this.chkpostbox, this.txt_AddressLabel, this.txt_address2, this.txtURL, this.chkhideaddress);
                }
                if (this.mode.ToLower() == "view" && base.Request.Params["addressid"] != null)
                {
                    this.addressid = Convert.ToInt32(base.Request.Params["addressid"].ToString());
                    this.comnyobj.address_select(this.companyid, this.userid, Convert.ToInt32(base.Request.Params["addressid"]), this.txtaddress, this.txt_city, this.txt_suburb, this.ddlcountry, this.txttelephone, this.txtfax, this.txt_postCode, this.txtref, this.txtemail, this.chkemail, this.chkdelivery, this.chkbilling, this.chkpostbox, this.txt_AddressLabel, this.txt_address2, this.txtURL, this.chkhideaddress);
                }
            }
            foreach (DataRow row1 in EstimateBasePage.Estimate_Select_By_EstimateID(this.companyid, this.EstimateID).Rows)
            {
                address_selector.SalesPersonID = row1["SalesPerson"].ToString();
            }
            long estimateID = this.EstimateID;
            long num = (long)0;
            string empty = string.Empty;
            address_selector.IsEditOnlyHisRecords = baseClass.ReturnRoles_Privileges_Others("editrecords");
            if (baseClass.ReturnRoles_Privileges_ForGrid("clients", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
            {
                this.Divbtnadd.Visible = false;
                this.DivSaveAs.Visible = false;
            }
            else if (address_selector.IsEditOnlyHisRecords.ToLower() == "his" && base.Session["UserID"].ToString() != address_selector.SalesPersonID)
            {
                this.Divbtnadd.Visible = false;
                this.DivSaveAs.Visible = false;
            }
            this.btncancel_address.Text = this.objLangClass.GetLanguageConversion("Cancel");
            this.btnSaveAs.Text = this.objLangClass.GetLanguageConversion("Save_As_New_Address");
            this.btncancel_addressSelector.Text = this.objLangClass.GetLanguageConversion("Cancel");
            if (!base.IsPostBack)
            {
                this.RadGrid_AddressSelector.Rebind();
            }
        }

        protected void RadGrid_AddressSelector_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataSet dataSet = new DataSet();
            //dataSet = DepartmentBaseClass.AddressAndCompanyname_select(this.clientid, this.companyid, this.hdnClearFilter.Value, this.RadGrid_AddressSelector.PageSize, this.RadGrid_AddressSelector.CurrentPageIndex + 1, "");
            //dataSet = DepartmentBaseClass.AddressAndCompanyname_select(this.clientid, this.companyid, this.hdnClearFilter.Value, this.RadGrid_AddressSelector.PageSize, this.RadGrid_AddressSelector.CurrentPageIndex, "");
            //  if (Session["data"] != null)
            if (address_selector.WhereCondition != "")
            {
                // dataSet = (DataSet)Session["data"];
                dataSet = DepartmentBaseClass.AddressAndCompanyname_select(this.clientid, this.companyid, this.hdnClearFilter.Value, this.RadGrid_AddressSelector.PageSize, this.RadGrid_AddressSelector.CurrentPageIndex, address_selector.WhereCondition);
            }
            else
            {
                dataSet = DepartmentBaseClass.AddressAndCompanyname_select(this.clientid, this.companyid, this.hdnClearFilter.Value, this.RadGrid_AddressSelector.PageSize, this.RadGrid_AddressSelector.CurrentPageIndex, "");
            }
            //else
            //{
            //   // Session["data"]
            //    //    dataSet= DepartmentBaseClass.AddressAndCompanyname_select(this.clientid, this.companyid, this.hdnClearFilter.Value, this.RadGrid_AddressSelector.PageSize, this.RadGrid_AddressSelector.CurrentPageIndex, "");
            //   // dataSet = (DataSet)Session["data"];
            //}

            if (dataSet == null || dataSet.Tables.Count <= 0)
            {
                this.txtName.Text = "Deleted Customer";
                this.hid_ClientID.Value = this.clientid.ToString();
            }
            else
            {
                this.dtAllAddSelector = dataSet.Tables[0];
                this.NoOfAddress = this.dtAllAddSelector.Rows.Count;
                if (!base.IsPostBack && this.hdnClearFilter.Value.Trim().ToLower() == "yes")
                {
                    string empty = string.Empty;
                    string str = string.Empty;
                    if (this.dtAllAddSelector.Rows.Count <= 0)
                    {
                        empty = address_selector.objBase.SpecialDecode(dataSet.Tables[1].Rows[0]["CompanyName"].ToString());
                        str = dataSet.Tables[1].Rows[0]["ClientID"].ToString();
                    }
                    else
                    {
                        empty = address_selector.objBase.SpecialDecode(this.dtAllAddSelector.Rows[0]["CompanyName"].ToString());
                        str = this.dtAllAddSelector.Rows[0]["ClientID"].ToString();
                    }
                    if (this.RadGrid_AddressSelector.MasterTableView.Columns[0].HeaderText.ToLower() == "company name")
                    {
                        this.RadGrid_AddressSelector.MasterTableView.Columns[0].CurrentFilterFunction = GridKnownFunction.Contains;
                        this.RadGrid_AddressSelector.MasterTableView.Columns[0].CurrentFilterValue = empty;
                        if (empty == "")
                        {
                            this.txtName.Text = "Deleted Customer";
                            this.hid_ClientID.Value = this.clientid.ToString();
                        }
                        else
                        {
                            this.txtName.Text = empty;
                            this.DefaultCompany = empty;
                            this.hid_ClientID.Value = str;
                            this.hid_CustName_old.Value = empty;
                        }
                    }
                }
            }

            // test code

            // end test code
            this.RadGrid_AddressSelector.AllowCustomPaging = true;
            this.RadGrid_AddressSelector.DataSource = this.dtAllAddSelector;
            this.RadGrid_AddressSelector.VirtualItemCount = Convert.ToInt32(dataSet.Tables[2].Rows[0][0].ToString());
        }

        protected void RadGrid_AddressSelector_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
            {
                Label label = (Label)e.Item.FindControl("lbl_Telephone");
                label.Style.Add("style", "cursor:pointer;cursor:hand;");
                Label label1 = (Label)e.Item.FindControl("lbl_AddressLabel");
                label1.Style.Add("style", "cursor:pointer;cursor:hand;");
                Label text = (Label)e.Item.FindControl("lbl_CompanyName");
                text.Style.Add("style", "cursor:pointer;cursor:hand;");
                Label label2 = (Label)e.Item.FindControl("lnkAddress");
                label2.Style.Add("style", "cursor:pointer;cursor:hand;");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_AddressID");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdn_Address");
                HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("hdn_City");
                HiddenField hiddenField3 = (HiddenField)e.Item.FindControl("hdn_Suburb");
                HiddenField hiddenField4 = (HiddenField)e.Item.FindControl("hdn_PostCode");
                HiddenField hiddenField5 = (HiddenField)e.Item.FindControl("hdn_Country");
                HiddenField hiddenField6 = (HiddenField)e.Item.FindControl("hdn_Telephone");
                HiddenField hiddenField7 = (HiddenField)e.Item.FindControl("hdn_Fax");
                HiddenField hiddenField8 = (HiddenField)e.Item.FindControl("hdn_Email");
                HiddenField hiddenField9 = (HiddenField)e.Item.FindControl("hdn_AddressLabel");
                HiddenField hiddenField10 = (HiddenField)e.Item.FindControl("hdn_AddressLine2");
                HiddenField hiddenField11 = (HiddenField)e.Item.FindControl("hdn_URL");
                HiddenField hiddenField12 = (HiddenField)e.Item.FindControl("hdn_CompanyName");
                HiddenField hiddenField13 = (HiddenField)e.Item.FindControl("hdn_CompanyID");
                HiddenField hiddenField14 = (HiddenField)e.Item.FindControl("hdn_IsDefaultPostBox");
                text.Text = address_selector.objBase.SpecialDecode(hiddenField12.Value);
                text.ToolTip = text.Text;
                //string[] value = new string[] { hiddenField1.Value, " ", hiddenField10.Value, " ", hiddenField2.Value, " ", hiddenField3.Value, " ", hiddenField4.Value, " ", hiddenField5.Value };

                // Below both lines are commented for ticket # 49638
                //string[] value = new string[] { hiddenField1.Value, " ", hiddenField10.Value };
                //string str = string.Concat(value);

                string str = hiddenField1.Value;

                label2.Text = address_selector.objBase.SpecialDecode(str);
                label2.ToolTip = address_selector.objBase.SpecialDecode(str);
                if (this.type.ToLower() != "deliveryaddress" && this.type.ToLower() != "customer" && (this.type.ToLower() != "moreaddress" || this.addresstype.ToLower() != "contact") && (this.type.ToLower() != "moreaddress" || this.addresstype.ToLower() != "delivery") && (this.type.ToLower() != "moreaddress" || this.pagename.ToLower() != "contactaddress"))
                {
                    this.div_note.Visible = false;
                    GridDataItem item = (GridDataItem)e.Item;
                    AttributeCollection attributes = item.Attributes;
                    string[] strArrays = new string[] { "javascript:OpenAddEditPage('", hiddenField.Value, "','", str, "','','", str, "','", this.DeliveryAddressTypeforPurchase, "','", this.clickvalfromsplitaddress, "','", address_selector.objBase.SpecialEncode(hiddenField12.Value), "','", hiddenField13.Value, "');javascript:SelAddress('", hiddenField.Value, "','", str, "','", hiddenField1.Value, "','", hiddenField2.Value, "','", hiddenField3.Value, "','", hiddenField4.Value, "','", hiddenField5.Value, "','", hiddenField6.Value, "','", hiddenField7.Value, "','A','", this.clickvalfromsplitaddress, "','", hiddenField8.Value, "','", hiddenField10.Value, "','", hiddenField11.Value, "','", this.IsDel, "' )" };
                    attributes.Add("onclick", string.Concat(strArrays));
                    item.Attributes.CssStyle.Add("style", "cursor:pointer;cursor:hand;");
                }
                else if (hiddenField14.Value != "False")
                {
                    GridDataItem gridDataItem = (GridDataItem)e.Item;
                    gridDataItem.BackColor = ColorTranslator.FromHtml("#838383");
                    gridDataItem.Attributes.Add("onclick", "javascript:alert('Note: Post Box address cannot be used as Contact/Delivery Address')");
                    gridDataItem.Attributes.CssStyle.Add("style", "cursor:pointer;cursor:hand;");
                }
                else
                {
                    GridDataItem item1 = (GridDataItem)e.Item;
                    AttributeCollection attributeCollection = item1.Attributes;
                    string[] value1 = new string[] { "javascript:OpenAddEditPage('", hiddenField.Value, "','", str, "','','", str, "','", this.DeliveryAddressTypeforPurchase, "','", this.clickvalfromsplitaddress, "','", address_selector.objBase.SpecialEncode(hiddenField12.Value), "','", hiddenField13.Value, "');javascript:SelAddress('", hiddenField.Value, "','", str, "','", hiddenField1.Value, "','", hiddenField2.Value, "','", hiddenField3.Value, "','", hiddenField4.Value, "','", hiddenField5.Value, "','", hiddenField6.Value, "','", hiddenField7.Value, "','A','", this.clickvalfromsplitaddress, "','", hiddenField8.Value, "','", hiddenField10.Value, "','", hiddenField11.Value, "','", this.IsDel, "' )" };
                    attributeCollection.Add("onclick", string.Concat(value1));
                    item1.Attributes.CssStyle.Add("style", "cursor:pointer;cursor:hand;");
                }
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.RadGrid_AddressSelector.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.RadGrid_AddressSelector.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void RadGrid_AddressSelector_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                e.Canceled = true;
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;

                if (this.Session["search_CustAddress"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                //if (this.Session["search_CustAddress"] != null)
                //{
                //    this.dtsearch = (DataTable)this.Session["search_CustAddress"];
                //}
                DataRow[] dataRowArray = this.dtsearch.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                if ((int)dataRowArray.Length <= 0)
                {
                    object[] second = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                    this.dtsearch.Rows.Add(second);

                }
                else
                {
                    this.dtsearch.Rows.Remove(dataRowArray[0]);
                    if (commandArgument.First.ToString().ToLower() != "nofilter")
                    {
                        object[] objArray = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                        this.dtsearch.Rows.Add(objArray);
                    }

                }
                //  this.Session["search_CustAddress"] = this.dtsearch;


                //WhereCondition = this.FilterFunction(this.dtsearch);
                // test code
                if (address_selector.WhereCondition != "")
                {
                    address_selector.WhereCondition = "";
                }
                // end test code 
                address_selector.WhereCondition = this.FilterFunction(this.dtsearch);
                DataSet dataSet = new DataSet();
                //dataSet = DepartmentBaseClass.AddressAndCompanyname_select(this.clientid, this.companyid, this.hdnClearFilter.Value, this.RadGrid_AddressSelector.PageSize, this.RadGrid_AddressSelector.CurrentPageIndex + 1, WhereCondition);
                // dataSet = DepartmentBaseClass.AddressAndCompanyname_select(this.clientid, this.companyid, this.hdnClearFilter.Value, this.RadGrid_AddressSelector.PageSize, this.RadGrid_AddressSelector.CurrentPageIndex, WhereCondition);
                // Session["data"] = DepartmentBaseClass.AddressAndCompanyname_select(this.clientid, this.companyid, this.hdnClearFilter.Value, this.RadGrid_AddressSelector.PageSize, this.RadGrid_AddressSelector.CurrentPageIndex, address_selector.WhereCondition);
                dataSet = DepartmentBaseClass.AddressAndCompanyname_select(this.clientid, this.companyid, this.hdnClearFilter.Value, this.RadGrid_AddressSelector.PageSize, this.RadGrid_AddressSelector.CurrentPageIndex, address_selector.WhereCondition);
                // dataSet = (DataSet)Session["data"];
                this.RadGrid_AddressSelector.AllowCustomPaging = true;
                this.RadGrid_AddressSelector.DataSource = dataSet.Tables[0];
                this.RadGrid_AddressSelector.VirtualItemCount = Convert.ToInt32(dataSet.Tables[2].Rows[0][0].ToString());
                this.RadGrid_AddressSelector.Rebind();

            }

        }

        public string FilterFunction(DataTable dtsearch)
        {
            int num = 0;
            string empty = string.Empty;
            string str = string.Empty;

            foreach (DataRow dataRow in dtsearch.Rows)
            {
                if (dataRow["filter"].ToString().ToLower() != "nofilter" && WhereCondition != "")
                {
                    WhereCondition = string.Concat(WhereCondition, " and ");
                }
                else
                {
                    WhereCondition = string.Concat(WhereCondition, " where ");
                }
                string lower = dataRow["filter"].ToString().ToLower();
                string str1 = lower;
                if (lower == null)
                {
                    continue;
                }

                var dictionary = new Dictionary<string, int>(16)
                             {
                                    { "startswith", 0 },
                                    { "endswith", 1 },
                                    { "equalto", 2 },
                                    { "notequalto", 3 },
                                    { "contains", 4 },
                                    { "doesnotcontain", 5 },
                                    { "greaterthan", 6 },
                                    { "lessthan", 7 },
                                    { "greaterthanorequalto", 8 },
                                    { "lessthanorequalto", 9 },
                                    { "isempty", 10 },
                                    { "notisempty", 11 },
                                    { "isnull", 12 },
                                    { "notisnull", 13 },
                                    { "between", 14 },
                                    { "notbetween", 15 }
                             };

                dictionary.TryGetValue(str1, out num);

                switch (num)
                {
                    case 0:
                        {
                            string whereCondition = WhereCondition;
                            string[] strArrays = new string[] { whereCondition, " ", dataRow["ColumnName"].ToString(), " like '", address_selector.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "%'" };
                            WhereCondition = string.Concat(strArrays);
                            continue;
                        }
                    case 1:
                        {
                            string whereCondition1 = WhereCondition;
                            string[] strArrays1 = new string[] { whereCondition1, " ", dataRow["ColumnName"].ToString(), " like '%", address_selector.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "'" };
                            WhereCondition = string.Concat(strArrays1);
                            continue;
                        }
                    case 2:
                        {
                            string whereCondition2 = WhereCondition;
                            string[] str2 = new string[] { whereCondition2, " ", dataRow["ColumnName"].ToString(), " = '", address_selector.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "'" };
                            WhereCondition = string.Concat(str2);
                            continue;
                        }
                    case 3:
                        {
                            string whereCondition3 = WhereCondition;
                            string[] strArrays2 = new string[] { whereCondition3, " ", dataRow["ColumnName"].ToString(), " != '", address_selector.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "'" };
                            WhereCondition = string.Concat(strArrays2);
                            continue;
                        }
                    case 4:
                        {
                            string str3 = WhereCondition;
                            string[] strArrays3 = new string[] { str3, " ", dataRow["ColumnName"].ToString(), " like '%", address_selector.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "%'" };
                            WhereCondition = string.Concat(strArrays3);
                            continue;
                        }
                    case 5:
                        {
                            string whereCondition4 = WhereCondition;
                            string[] str4 = new string[] { whereCondition4, " ", dataRow["ColumnName"].ToString(), " not like '%", address_selector.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "%'" };
                            WhereCondition = string.Concat(str4);
                            continue;
                        }
                    case 6:
                        {
                            string whereCondition5 = WhereCondition;
                            string[] strArrays4 = new string[] { whereCondition5, " ", dataRow["ColumnName"].ToString(), " > '%", address_selector.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "%'" };
                            WhereCondition = string.Concat(strArrays4);
                            continue;
                        }
                    case 7:
                        {
                            string str5 = WhereCondition;
                            string[] strArrays5 = new string[] { str5, " ", dataRow["ColumnName"].ToString(), " < '%", address_selector.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "%'" };
                            WhereCondition = string.Concat(strArrays5);
                            continue;
                        }
                    case 8:
                        {
                            string whereCondition6 = WhereCondition;
                            string[] str6 = new string[] { whereCondition6, " ", dataRow["ColumnName"].ToString(), " >= '%", address_selector.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "%'" };
                            WhereCondition = string.Concat(str6);
                            continue;
                        }
                    case 9:
                        {
                            string whereCondition7 = WhereCondition;
                            string[] strArrays6 = new string[] { whereCondition7, " ", dataRow["ColumnName"].ToString(), " <= '%", address_selector.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "%'" };
                            WhereCondition = string.Concat(strArrays6);
                            continue;
                        }
                    case 10:
                        {
                            WhereCondition = string.Concat(WhereCondition, " ", dataRow["ColumnName"].ToString(), " = ''");
                            continue;
                        }
                    case 11:
                        {
                            WhereCondition = string.Concat(WhereCondition, " ", dataRow["ColumnName"].ToString(), " != ''");
                            continue;
                        }
                    case 12:
                        {
                            WhereCondition = string.Concat(WhereCondition, " ", dataRow["ColumnName"].ToString(), " is null");
                            continue;
                        }
                    case 13:
                        {
                            WhereCondition = string.Concat(WhereCondition, " ", dataRow["ColumnName"].ToString(), " is not null");
                            continue;
                        }
                    case 14:
                        {
                            string str7 = WhereCondition;
                            string[] strArrays7 = new string[] { str7, " ", dataRow["ColumnName"].ToString(), " between '", address_selector.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "' and '", address_selector.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "'" };
                            WhereCondition = string.Concat(strArrays7);
                            continue;
                        }
                    case 15:
                        {
                            string whereCondition8 = WhereCondition;
                            string[] str8 = new string[] { whereCondition8, " ", dataRow["ColumnName"].ToString(), " not between '", address_selector.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "' and '", address_selector.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "'" };
                            WhereCondition = string.Concat(str8);
                            continue;
                        }
                    default:
                        {
                            continue;
                        }
                }
            }
            return WhereCondition;
        }
    }
}