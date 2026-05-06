using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Department;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using Sample.Web.UI.Compatibility;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.Departments
{
    public partial class deptartment_add : System.Web.UI.UserControl
    {
        private commonClass cmnClientContact = new commonClass();

        private DepartmentBaseClass objDept = new DepartmentBaseClass();

        private CompanyBasePage objcom = new CompanyBasePage();

        public languageClass objLanguage = new languageClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string wintype = string.Empty;

        public string companytype = string.Empty;

        public string pg = string.Empty;

        public string Pgtype = string.Empty;

        public string AddressType = string.Empty;

        public string mode = string.Empty;

        public string From = string.Empty;

        public string ParentPage = string.Empty;

        public string isfromAddressView = string.Empty;

        public string IsAddMode = string.Empty;

        public string type = string.Empty;

        public string item = string.Empty;

        public int ClientID;

        public int CompanyID;

        public int UserID;

        public long DeptID;

        public long checkDeptID;

        public long rtnDeptID;

        public int ContactID;

        public int AddressID;

        public int popuplevel;

        public int id;

        public int billingAddress_cnt;

        public int shippingAddress_cnt;

        public static string SalesPersonID;

        public static string IsEditOnlyHisRecords;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLangClass = new languageClass();

        public BaseClass objBase = new BaseClass();

        public string SecureDocPath = global.SecureDocPath();

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

        static deptartment_add()
        {
            deptartment_add.SalesPersonID = string.Empty;
            deptartment_add.IsEditOnlyHisRecords = string.Empty;
        }

        public deptartment_add()
        {
        }

        public void btn_NewDept_Onclick(object sender, EventArgs e)
        {
            HttpResponse response = base.Response;
            object[] deptID = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&mode=add&DeptID=", this.DeptID, "&ClientID=", this.ClientID, "&pg=", this.pg, "&companytype=", this.companytype };
            response.Redirect(string.Concat(deptID));
        }

        protected void btnadd_Onclick(object sender, EventArgs e)
        {
            int num = 0;
            string empty = string.Empty;
            this.AddressType = this.hdnAddressType.Value;
            if (this.hdnAddressID.Value == "")
            {
                this.AddressID = 0;
            }
            else
            {
                this.AddressID = Convert.ToInt32(this.hdnAddressID.Value);
            }
            if (this.rdbnotallow.Checked)
            {
                empty = "N";
            }
            else if (this.rdball.Checked)
            {
                empty = "A";
            }
            else if (this.rdbonlyselected.Checked)
            {
                empty = "S";
            }
            if (this.hdn_DeptID.Value == "")
            {
                this.DeptID = (long)0;
            }
            else
            {
                this.DeptID = (long)Convert.ToInt32(this.hdn_DeptID.Value);
            }
            try
            {
                Convert.ToInt32(this.hdnAddressID.Value);
            }
            catch
            {
                this.hdnAddressID.Value = "0";
            }
            try
            {
                Convert.ToInt32(this.hdnShippingAddressID.Value);
            }
            catch
            {
                this.hdnShippingAddressID.Value = "0";
            }
            int num1 = 0;
            num1 = (!(this.ddlContacts.SelectedValue.ToString() != "") || this.ddlContacts.SelectedValue.ToString() == null ? 0 : Convert.ToInt32(this.ddlContacts.SelectedValue.ToString()));
            int num2 = 0;
            if (this.ddlcostcenter.SelectedIndex != -1)
            {
                num2 = Convert.ToInt32(this.ddlcostcenter.SelectedItem.Value);
            }
            int num3 = 0;
            if (this.ddlInvoiceContact.SelectedIndex != -1)
            {
                num3 = Convert.ToInt32(this.ddlInvoiceContact.SelectedItem.Value);
            }
            if (this.chkdeptnotapproval.Checked)
            {
                num = 1;
            }
            string serverName = string.Empty;
            if (ConnectionClass.ServerName != null)
            {
                serverName = ConnectionClass.ServerName;
            }
            string fileName = this.ImageUpload.FileName;
            string value = string.Empty;
            string str = string.Empty;
            object[] secureDocPath = new object[] { this.SecureDocPath, "//", serverName, "//", this.CompanyID, "//DepartmentImages//" };
            string.Concat(secureDocPath);
            bool flag = false;
            if (!this.ImageUpload.HasFile)
            {
                value = this.hid_Actualfilename.Value;
                fileName = this.hid_Originalfilename.Value;
                string[] strArrays = value.ToString().Trim().Split(new char[] { '.' });
                string[] strArrays1 = value.ToString().Trim().Split(new char[] { '.' });
                if (fileName != "" && strArrays1[1].ToString().Trim().ToLower() == "pdf")
                {
                    flag = true;
                }
                if (value != "" && this.hid_IsProccessed.Value.ToString().ToLower().Trim() == "true")
                {
                    value = string.Concat(strArrays[0], ".png");
                }
                this.hid_IsProccessed.Value = "";
                this.hid_Originalfilename.Value = "";
                this.hid_Actualfilename.Value = "";
            }
            else
            {
                string[] strArrays2 = this.ImageUpload.FileName.ToString().Trim().Split(new char[] { '.' });
                string[] strArrays3 = new string[] { strArrays2[0], "_", null, null, null };
                Guid guid = Guid.NewGuid();
                strArrays3[2] = guid.ToString().Substring(0, 5);
                strArrays3[3] = ".";
                strArrays3[4] = strArrays2[1];
                value = string.Concat(strArrays3);
                if (strArrays2[1].ToString().Trim().ToLower() == "pdf")
                {
                    flag = true;
                }
                object[] objArray = new object[] { this.SecureDocPath, "//", serverName, "//", this.CompanyID, "//DepartmentImages" };
                if (!Directory.Exists(string.Concat(objArray)))
                {
                    object[] secureDocPath1 = new object[] { this.SecureDocPath, "//", serverName, "//", this.CompanyID, "//DepartmentImages" };
                    Directory.CreateDirectory(string.Concat(secureDocPath1));
                }
                FileUpload imageUpload = this.ImageUpload;
                object[] objArray1 = new object[] { this.SecureDocPath, "//", serverName, "//", this.CompanyID, "//DepartmentImages//", value };
                imageUpload.SaveAs(string.Concat(objArray1));
            }
            if (this.DeptID != (long)0)
            {
                this.rtnDeptID = DepartmentBaseClass.departmentInsert(this.DeptID, this.objBase.SpecialEncode(this.txtDeptName.Text.Trim()), this.ClientID, this.ContactID, this.UserID, Convert.ToInt32(this.hdnAddressID.Value), "A", DateTime.Now, DateTime.Now, this.CompanyID, Convert.ToInt64(this.hdnShippingAddressID.Value), num1, num2, empty, Convert.ToBoolean(num), this.objBase.SpecialEncode(this.txtc1.Text), this.objBase.SpecialEncode(this.txtc2.Text), this.objBase.SpecialEncode(this.txtc3.Text), this.objBase.SpecialEncode(this.txtc4.Text), this.objBase.SpecialEncode(this.txtc5.Text), this.objBase.SpecialEncode(this.txtc6.Text), this.objBase.SpecialEncode(this.txtc7.Text), this.objBase.SpecialEncode(this.txtc8.Text), this.objBase.SpecialEncode(this.txtc9.Text), this.objBase.SpecialEncode(this.txtc10.Text), this.objBase.SpecialEncode(this.txtc11.Text), this.objBase.SpecialEncode(this.txtc12.Text), this.objBase.SpecialEncode(this.txtc13.Text), this.objBase.SpecialEncode(this.txtc14.Text), this.objBase.SpecialEncode(this.txtc15.Text), (long)num3, fileName, value, flag, this.txtTerritory_Manager_Email.Text);
            }
            else
            {
                this.rtnDeptID = DepartmentBaseClass.departmentInsert(this.DeptID, this.objBase.SpecialEncode(this.txtDeptName.Text.Trim()), this.ClientID, this.ContactID, this.UserID, Convert.ToInt32(this.hdnAddressID.Value), "A", DateTime.Now, DateTime.Now, this.CompanyID, Convert.ToInt64(this.hdnShippingAddressID.Value), num1, num2, empty, Convert.ToBoolean(num), this.objBase.SpecialEncode(this.txtc1.Text), this.objBase.SpecialEncode(this.txtc2.Text), this.objBase.SpecialEncode(this.txtc3.Text), this.objBase.SpecialEncode(this.txtc4.Text), this.objBase.SpecialEncode(this.txtc5.Text), this.objBase.SpecialEncode(this.txtc6.Text), this.objBase.SpecialEncode(this.txtc7.Text), this.objBase.SpecialEncode(this.txtc8.Text), this.objBase.SpecialEncode(this.txtc9.Text), this.objBase.SpecialEncode(this.txtc10.Text), this.objBase.SpecialEncode(this.txtc11.Text), this.objBase.SpecialEncode(this.txtc12.Text), this.objBase.SpecialEncode(this.txtc13.Text), this.objBase.SpecialEncode(this.txtc14.Text), this.objBase.SpecialEncode(this.txtc15.Text), (long)num3, fileName, value, flag, this.txtTerritory_Manager_Email.Text);
            }
            if (this.rdbonlyselected.Checked && this.lstcostcenters.Items.Count > 0)
            {
                DepartmentBaseClass.departmentcostcentre_delete(Convert.ToInt64(this.rtnDeptID));
                for (int i = 0; i < this.lstcostcenters.Items.Count; i++)
                {
                    if (this.lstcostcenters.Items[i].Selected)
                    {
                        int num4 = Convert.ToInt32(this.lstcostcenters.Items[i].Value);
                        DepartmentBaseClass.departmentcostcentre_insert(Convert.ToInt32(this.rtnDeptID), Convert.ToInt32(num4));
                    }
                }
            }
            if (this.ParentPage == "editcontact")
            {
                HttpResponse response = base.Response;
                object[] clientID = new object[] { this.strSitepath, "contact/contact_add.aspx?action=edit&clientid=", this.ClientID, "&contactid=", this.ContactID, "&wintype=", this.wintype, "&type=", this.companytype, "&newdept=", this.rtnDeptID, "&pg=", this.pg, "&mode=", this.mode };
                response.Redirect(string.Concat(clientID));
                return;
            }
            if (this.ParentPage == "addcontact")
            {
                HttpResponse httpResponse = base.Response;
                object[] clientID1 = new object[] { this.strSitepath, "contact/contact_add.aspx?action=edit&clientid=", this.ClientID, "&type=", this.companytype, "&newdept=", this.rtnDeptID, "&pg=", this.pg, "&mode=", this.mode };
                httpResponse.Redirect(string.Concat(clientID1));
                return;
            }
            if (this.ParentPage == "newcontact")
            {
                HttpResponse response1 = base.Response;
                object[] clientID2 = new object[] { this.strSitepath, "contact/contact_add.aspx?clientid=", this.ClientID, "&type=", this.companytype, "&newdept=", this.rtnDeptID, "&pg=", this.pg, "&mode=", this.mode, "&item=", this.item, "&id=", this.id };
                response1.Redirect(string.Concat(clientID2));
                return;
            }
            if ((this.ParentPage.ToLower() == "depteditmode" || this.ParentPage.ToLower() == "depteditmodesh") && this.From.ToLower() == "addressselect" && this.pg.ToLower() != "estimate")
            {
                if (!base.Request.Browser.Type.ToUpper().Contains("IE"))
                {
                    this.pnlDept1.Visible = true;
                    return;
                }
                ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "GetRadWindow().BrowserWindow.location.reload();", true);
                return;
            }
            if (this.From.ToLower() == "estimate" || (this.From.ToLower() == "addressselect" || this.From == "") && this.pg.ToLower() == "estimate")
            {
                this.pnlDept_estimate.Visible = true;
                return;
            }
            if (this.From.ToLower() == "addressselect" && this.pg.ToLower() == "client")
            {
                this.pnlDept1.Visible = true;
                return;
            }
            if (this.From == "editcontact")
            {
                HttpResponse httpResponse1 = base.Response;
                object[] objArray2 = new object[] { this.strSitepath, "contact/contact_add.aspx?action=edit&clientid=", this.ClientID, "&contactid=", this.ContactID, "&wintype=crm&type=", this.companytype, "&newdept=", this.rtnDeptID, "&pg=", this.pg, "&mode=", this.mode };
                httpResponse1.Redirect(string.Concat(objArray2));
                return;
            }
            if (this.From == "addcontact")
            {
                HttpResponse response2 = base.Response;
                object[] clientID3 = new object[] { this.strSitepath, "contact/contact_add.aspx?action=edit&clientid=", this.ClientID, "&type=", this.companytype, "&newdept=", this.rtnDeptID, "&pg=", this.pg, "&mode=", this.mode };
                response2.Redirect(string.Concat(clientID3));
                return;
            }
            if (this.From == "newcontact" || this.From.ToLower() == "addressselect")
            {
                HttpResponse httpResponse2 = base.Response;
                object[] objArray3 = new object[] { this.strSitepath, "contact/contact_add.aspx?&clientid=", this.ClientID, "&type=", this.companytype, "&newdept=", this.rtnDeptID, "&pg=", this.pg, "&mode=", this.mode };
                httpResponse2.Redirect(string.Concat(objArray3));
                return;
            }
            if (this.From == "Contact")
            {
                if (!base.Request.Browser.Type.ToUpper().Contains("IE"))
                {
                    this.pnlDept1.Visible = true;
                    return;
                }
                ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "GetRadWindow().BrowserWindow.location.reload();", true);
                return;
            }
            base.Session["IsAdded"] = "yes";
            if (!base.Request.Browser.Type.ToUpper().Contains("IE"))
            {
                this.pnlDept1.Visible = true;
                return;
            }
            ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "GetRadWindow().BrowserWindow.location.reload();", true);
        }

        protected void btnCancel_Onclick(object sender, EventArgs e)
        {
            if (this.From == "newcontact" || this.From == "editcontact")
            {
                if (this.mode != "edit")
                {
                    HttpResponse response = base.Response;
                    object[] clientID = new object[] { this.strSitepath, "contact/contact_add.aspx?clientid=", this.ClientID, "&type=", this.companytype, "&pg=", this.pg, "&mode=", this.mode, "&id=", this.id, "&popuplevel=", this.popuplevel };
                    response.Redirect(string.Concat(clientID));
                    return;
                }
                HttpResponse httpResponse = base.Response;
                object[] objArray = new object[] { this.strSitepath, "contact/contact_add.aspx?action=edit&clientid=", this.ClientID, "&type=", this.companytype, "&pg=", this.pg, "&mode=", this.mode, "&contactid=", this.ContactID, "&popuplevel=", this.popuplevel, "&wintype=", this.wintype };
                httpResponse.Redirect(string.Concat(objArray));
                return;
            }
            if (this.pg.ToLower() == "purchase" && this.isfromAddressView == "yes")
            {
                this.isfromAddressView = "no";
                HttpResponse response1 = base.Response;
                object[] clientID1 = new object[] { this.strSitepath, "contact/contact_add.aspx?clientid=", this.ClientID, "&type=", this.companytype, "&pg=", this.pg, "&mode=", this.mode };
                response1.Redirect(string.Concat(clientID1));
                return;
            }
            if (this.From.ToLower() == "estimate")
            {
                HttpResponse httpResponse1 = base.Response;
                object[] objArray1 = new object[] { this.strSitepath, "common/common_popup.aspx?from=estimate&type=deptselect&clientid=", this.ClientID, "&pg=estimate&mode=view&companytype=customer" };
                httpResponse1.Redirect(string.Concat(objArray1));
                return;
            }
            if (this.popuplevel != 0)
            {
                if (this.mode == "edit")
                {
                    HttpResponse response2 = base.Response;
                    object[] clientID2 = new object[] { this.strSitepath, "contact/contact_add.aspx?action=edit&clientid=", this.ClientID, "&wintype=crm&type=", this.companytype, "&pg=", this.pg, "&mode=", this.mode, "&contactid=", this.ContactID, "&popuplevel=", this.popuplevel };
                    response2.Redirect(string.Concat(clientID2));
                    return;
                }
                HttpResponse httpResponse2 = base.Response;
                object[] objArray2 = new object[] { this.strSitepath, "contact/contact_add.aspx?clientid=", this.ClientID, "&type=", this.companytype, "&pg=", this.pg, "&mode=", this.mode, "&popuplevel=", this.popuplevel };
                httpResponse2.Redirect(string.Concat(objArray2));
            }
        }

        public void GetAllDeptDetails(int addressID, string AddLine1, string AddLine2, string City, string State, string ZipCode, string Country, string Telephone, string Fax, string addressLabel ,string AddressTo)
        {
            int num = 40;
            if (AddressTo.ToLower() == "billing")
            {
                //Set Address Label for Billing
                if (string.IsNullOrEmpty(addressLabel))
                {
                    this.lblAddressLabel_Inv.Text = "";
                    this.lblAddressLabel_Inv.Style.Add("display", "none");
                    //this.lblAddressLabel_Inv_Caption.Style.Add("display", "none");
                }
                else
                {
                    this.lblAddressLabel_Inv.Text = addressLabel;
                    this.lblAddressLabel_Inv.Style.Add("display", "block");
                    //this.lblAddressLabel_Inv_Caption.Style.Add("display", "block");
                }
                if (AddLine1 == "")
                {
                    this.lbl_DeptAddress1.Text = "";
                    this.lbl_DeptAddress1.Style.Add("display", "none");
                    this.div_DeptAddress1.Style.Add("display", "none");
                }
                else
                {
                    this.lbl_DeptAddress1.Text = (AddLine1.Length > num ? AddLine1.Substring(0, num) : AddLine1);
                    this.lbl_DeptAddress1.Style.Add("display", "block");
                    this.div_DeptAddress1.Style.Add("display", "block");
                }
                if (AddLine2 == "")
                {
                    this.lbl_DeptAddress2.Text = "";
                    this.lbl_DeptAddress2.Style.Add("display", "none");
                    this.div_DeptAddress2.Style.Add("display", "none");
                }
                else
                {
                    this.lbl_DeptAddress2.Text = (AddLine2.Length > num ? AddLine2.Substring(0, num) : AddLine2);
                    this.lbl_DeptAddress2.Style.Add("display", "block");
                    this.div_DeptAddress2.Style.Add("display", "block");
                }
                if (City == "")
                {
                    this.lbl_DeptAddress3.Text = "";
                    this.lbl_DeptAddress3.Style.Add("display", "none");
                    this.div_DeptAddress3.Style.Add("display", "none");
                }
                else
                {
                    this.lbl_DeptAddress3.Text = (City.Length > num ? City.Substring(0, num) : City);
                    this.lbl_DeptAddress3.Style.Add("display", "block");
                    this.div_DeptAddress3.Style.Add("display", "block");
                }
                if (State == "")
                {
                    this.lbl_DeptAddress4.Text = "";
                    this.lbl_DeptAddress4.Style.Add("display", "none");
                    this.div_DeptAddress4.Style.Add("display", "none");
                }
                else
                {
                    this.lbl_DeptAddress4.Text = (State.Length > num ? State.Substring(0, num) : State);
                    this.lbl_DeptAddress4.Style.Add("display", "block");
                    this.div_DeptAddress4.Style.Add("display", "block");
                }
                if (ZipCode == "")
                {
                    this.lbl_DeptAddress5.Text = "";
                    this.lbl_DeptAddress5.Style.Add("display", "none");
                    this.div_DeptAddress5.Style.Add("display", "none");
                }
                else
                {
                    this.lbl_DeptAddress5.Text = (ZipCode.Length > num ? ZipCode.Substring(0, num) : ZipCode);
                    this.lbl_DeptAddress5.Style.Add("display", "block");
                    this.div_DeptAddress5.Style.Add("display", "block");
                }
                if (Country == "")
                {
                    this.lbl_DeptCountry.Text = "";
                    this.lbl_DeptCountry.Style.Add("display", "none");
                    this.div_DeptCountry.Style.Add("display", "none");
                }
                else
                {
                    this.lbl_DeptCountry.Text = (Country.Length > num ? Country.Substring(0, num) : Country);
                    this.lbl_DeptCountry.Style.Add("display", "block");
                    this.div_DeptCountry.Style.Add("display", "block");
                }
                if (Telephone == "")
                {
                    this.lbl_DeptTelephone.Text = "";
                    this.lbl_DeptTelephone.Style.Add("display", "none");
                    this.div_DeptTelephone.Style.Add("display", "none");
                }
                else
                {
                    this.lbl_DeptTelephone.Text = "T: ";
                    Label lblDeptTelephone = this.lbl_DeptTelephone;
                    lblDeptTelephone.Text = string.Concat(lblDeptTelephone.Text, (Telephone.Length > num ? Telephone.Substring(0, num) : Telephone));
                    this.lbl_DeptTelephone.Style.Add("display", "block");
                    this.div_DeptTelephone.Style.Add("display", "block");
                }
                if (Fax == "")
                {
                    this.lbl_DeptFax.Text = "";
                    this.lbl_DeptFax.Style.Add("display", "none");
                    this.div_DeptFax.Style.Add("display", "none");
                }
                else
                {
                    this.lbl_DeptFax.Text = "F: ";
                    Label lblDeptFax = this.lbl_DeptFax;
                    lblDeptFax.Text = string.Concat(lblDeptFax.Text, (Fax.Length > num ? Fax.Substring(0, num) : Fax));
                    this.lbl_DeptFax.Style.Add("display", "block");
                    this.div_DeptFax.Style.Add("display", "block");
                }
            }
            if (AddressTo.ToLower() == "shipping")
            {
                //Set Address Label for Shipping/Invoice
                if (string.IsNullOrEmpty(addressLabel))
                {
                    this.lblAddressLabel.Text = "";
                    this.lblAddressLabel.Style.Add("display", "none"); 
                    //this.lblAddressLabelCaption.Style.Add("display", "none");
                }
                else
                {
                    this.lblAddressLabel.Text = addressLabel;
                    this.lblAddressLabel.Style.Add("display", "block");
                    //this.lblAddressLabelCaption.Style.Add("display", "block");
                }
                if (AddLine1 == "")
                {
                    this.lbl_DeptShippingAddress1.Text = "";
                    this.lbl_DeptShippingAddress1.Style.Add("display", "none");
                    this.div_DeptShippingAddress1.Style.Add("display", "none");
                }
                else
                {
                    this.lbl_DeptShippingAddress1.Text = (AddLine1.Length > num ? AddLine1.Substring(0, num) : AddLine1);
                    this.lbl_DeptShippingAddress1.Style.Add("display", "block");
                    this.div_DeptShippingAddress1.Style.Add("display", "block");
                }
                if (AddLine2 == "")
                {
                    this.lbl_DeptShippingAddress2.Text = "";
                    this.lbl_DeptShippingAddress2.Style.Add("display", "none");
                    this.div_DeptShippingAddress2.Style.Add("display", "none");
                }
                else
                {
                    this.lbl_DeptShippingAddress2.Text = (AddLine2.Length > num ? AddLine2.Substring(0, num) : AddLine2);
                    this.lbl_DeptShippingAddress2.Style.Add("display", "block");
                    this.div_DeptShippingAddress2.Style.Add("display", "block");
                }
                if (City == "")
                {
                    this.lbl_DeptShippingAddress3.Text = "";
                    this.lbl_DeptShippingAddress3.Style.Add("display", "none");
                    this.div_DeptShippingAddress3.Style.Add("display", "none");
                }
                else
                {
                    this.lbl_DeptShippingAddress3.Text = (City.Length > num ? City.Substring(0, num) : City);
                    this.lbl_DeptShippingAddress3.Style.Add("display", "block");
                    this.div_DeptShippingAddress3.Style.Add("display", "block");
                }
                if (State == "")
                {
                    this.lbl_DeptShippingAddress4.Text = "";
                    this.lbl_DeptShippingAddress4.Style.Add("display", "none");
                    this.div_DeptShippingAddress4.Style.Add("display", "none");
                }
                else
                {
                    this.lbl_DeptShippingAddress4.Text = (State.Length > num ? State.Substring(0, num) : State);
                    this.lbl_DeptShippingAddress4.Style.Add("display", "block");
                    this.div_DeptShippingAddress4.Style.Add("display", "block");
                }
                if (ZipCode == "")
                {
                    this.lbl_DeptShippingAddress5.Text = "";
                    this.lbl_DeptShippingAddress5.Style.Add("display", "none");
                    this.div_DeptShippingAddress5.Style.Add("display", "none");
                }
                else
                {
                    this.lbl_DeptShippingAddress5.Text = (ZipCode.Length > num ? ZipCode.Substring(0, num) : ZipCode);
                    this.lbl_DeptShippingAddress5.Style.Add("display", "block");
                    this.div_DeptShippingAddress5.Style.Add("display", "block");
                }
                if (Country == "")
                {
                    this.lbl_DeptShippingCountry.Text = "";
                    this.lbl_DeptShippingCountry.Style.Add("display", "none");
                    this.div_DeptShippingCountry.Style.Add("display", "none");
                }
                else
                {
                    this.lbl_DeptShippingCountry.Text = (Country.Length > num ? Country.Substring(0, num) : Country);
                    this.lbl_DeptShippingCountry.Style.Add("display", "block");
                    this.div_DeptShippingCountry.Style.Add("display", "block");
                }
                if (Telephone == "")
                {
                    this.lbl_DeptShippingTelephone.Text = "";
                    this.lbl_DeptShippingTelephone.Style.Add("display", "none");
                    this.div_DeptShippingTelephone.Style.Add("display", "none");
                }
                else
                {
                    this.lbl_DeptShippingTelephone.Text = "T: ";
                    Label lblDeptShippingTelephone = this.lbl_DeptShippingTelephone;
                    lblDeptShippingTelephone.Text = string.Concat(lblDeptShippingTelephone.Text, (Telephone.Length > num ? Telephone.Substring(0, num) : Telephone));
                    this.lbl_DeptShippingTelephone.Style.Add("display", "block");
                    this.div_DeptShippingTelephone.Style.Add("display", "block");
                }
                if (Fax != "")
                {
                    this.lbl_DeptShippingFax.Text = "F: ";
                    Label lblDeptShippingFax = this.lbl_DeptShippingFax;
                    lblDeptShippingFax.Text = string.Concat(lblDeptShippingFax.Text, (Fax.Length > num ? Fax.Substring(0, num) : Fax));
                    this.lbl_DeptShippingFax.Style.Add("display", "block");
                    this.div_DeptShippingFax.Style.Add("display", "block");
                    return;
                }
                this.lbl_DeptShippingFax.Text = "";
                this.lbl_DeptShippingFax.Style.Add("display", "none");
                this.div_DeptShippingFax.Style.Add("display", "none");
            }
        }

        public void getStoredData()
        {
            if ((this.From.ToLower() == "addressselect" || this.From.ToLower() == "" || this.From.ToLower() == "newcontact") && base.Session["DeptInvoice"] != null)
            {
                string empty = string.Empty;
                if (base.Request.Params["addressto"] != null)
                {
                    empty = base.Request.Params["addressto"].ToString();
                }
                if (base.Request.Params["addressID"] != null)
                {
                    if (empty.ToLower() == "billing")
                    {
                        this.hdnAddressID.Value = base.Request.Params["addressID"].ToString();
                    }
                    if (empty.ToLower() == "shipping")
                    {
                        this.hdnShippingAddressID.Value = base.Request.Params["addressID"].ToString();
                    }
                }
                DataTable item = (DataTable)base.Session["DeptInvoice"];
                if (empty.ToLower() == "billing")
                {
                    DataRow[] value = item.Select("AddressTo='billing'");
                    if ((int)value.Length > 0)
                    {
                        value[0]["AddressID"] = this.hdnAddressID.Value;
                    }
                }
                else if (empty.ToLower() == "shipping")
                {
                    DataRow[] dataRowArray = item.Select("AddressTo='shipping'");
                    if ((int)dataRowArray.Length > 0)
                    {
                        dataRowArray[0]["AddressID"] = this.hdnShippingAddressID.Value;
                    }
                }
                bool flag = true;
                foreach (DataRow row in ((DataTable)base.Session["DeptInvoice"]).Rows)
                {
                    if ((long)Convert.ToInt32(row["DeptID"]) != this.DeptID && this.DeptID > (long)0)
                    {
                        flag = false;
                    }
                    if (!flag)
                    {
                        continue;
                    }
                    this.DeptID = (long)Convert.ToInt32(row["DeptID"].ToString());
                    this.hdn_DeptID.Value = row["DeptID"].ToString();
                    this.txtDeptName.Text = this.objBase.SpecialDecode(row["DeptName"].ToString());
                    if (row["AddressTo"].ToString().ToLower() == "billing")
                    {
                        this.hdnAddressID.Value = row["Addressid"].ToString();
                    }
                    if (row["AddressTo"].ToString().ToLower() != "shipping")
                    {
                        continue;
                    }
                    this.hdnShippingAddressID.Value = row["Addressid"].ToString();
                }
                if (flag)
                {
                    if (this.hdnAddressID.Value == "")
                    {
                        this.hdnAddressID.Value = "0";
                    }
                    DataTable dataTable = CompanyBasePage.address_select_For_Edit(this.CompanyID, Convert.ToInt32(this.hdnAddressID.Value), this.UserID);
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        this.hdnAddressID.Value = dataRow["AddressID"].ToString();
                        deptartment_add billingAddressCnt = this;
                        billingAddressCnt.billingAddress_cnt = billingAddressCnt.billingAddress_cnt + 1;
                        this.GetAllDeptDetails(Convert.ToInt32(dataRow["AddressID"].ToString()), this.objBase.SpecialDecode(dataRow["Address"].ToString()), this.objBase.SpecialDecode(dataRow["AddressLine2"].ToString()), this.objBase.SpecialDecode(dataRow["City"].ToString()), this.objBase.SpecialDecode(dataRow["State"].ToString()), this.objBase.SpecialDecode(dataRow["ZipCode"].ToString()), this.objBase.SpecialDecode(dataRow["Country"].ToString()), this.objBase.SpecialDecode(dataRow["telephone"].ToString()), this.objBase.SpecialDecode(dataRow["Fax"].ToString()), Convert.ToString(dataRow["AddressLabel"]), "billing");
                    }
                    if (this.hdnShippingAddressID.Value == "")
                    {
                        this.hdnShippingAddressID.Value = "0";
                    }
                    DataTable dataTable1 = CompanyBasePage.address_select_For_Edit(this.CompanyID, Convert.ToInt32(this.hdnShippingAddressID.Value), this.UserID);
                    foreach (DataRow row1 in dataTable1.Rows)
                    {
                        this.hdnShippingAddressID.Value = row1["AddressID"].ToString();
                        deptartment_add shippingAddressCnt = this;
                        shippingAddressCnt.shippingAddress_cnt = shippingAddressCnt.shippingAddress_cnt + 1;
                        this.GetAllDeptDetails(Convert.ToInt32(row1["AddressID"].ToString()), this.objBase.SpecialDecode(row1["Address"].ToString()), this.objBase.SpecialDecode(row1["AddressLine2"].ToString()), this.objBase.SpecialDecode(row1["City"].ToString()), this.objBase.SpecialDecode(row1["State"].ToString()), this.objBase.SpecialDecode(row1["ZipCode"].ToString()), this.objBase.SpecialDecode(row1["Country"].ToString()), this.objBase.SpecialDecode(row1["Telephone"].ToString()), this.objBase.SpecialDecode(row1["Fax"].ToString()), Convert.ToString(row1["AddressLabel"]), "shipping");
                    }
                }
            }
            base.Session["DeptInvoice"] = null;
        }

        protected void lbl_Change_OnClick(object sender, EventArgs e)
        {
            base.Session["DeptID"] = this.hdn_DeptID.Value;
            this.StoreOldData();
            if (this.mode == "add")
            {
                if (this.ParentPage == "editcontact" || this.ParentPage == "newcontact")
                {
                    HttpResponse response = base.Response;
                    object[] clientID = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=view&clientid=", this.ClientID, "&ContactID=", this.ContactID, "&pg=", this.pg, "&pagename=Dept&from=depteditmode&addressid=", this.hdnAddressID.Value, "&parentpage=", this.ParentPage, "&popuplevel=", this.popuplevel, "&item=", this.item, "&id=", this.id, "&companytype=", this.companytype };
                    response.Redirect(string.Concat(clientID));
                }
                else
                {
                    HttpResponse httpResponse = base.Response;
                    object[] objArray = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=view&clientid=", this.ClientID, "&pg=", this.pg, "&pagename=Dept&from=deptaddmode&addressid=", this.hdnAddressID.Value, "&companytype=", this.companytype };
                    httpResponse.Redirect(string.Concat(objArray));
                }
            }
            if (this.mode == "edit")
            {
                if (this.ParentPage == "editcontact" || this.ParentPage == "newcontact")
                {
                    HttpResponse response1 = base.Response;
                    object[] clientID1 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=view&clientid=", this.ClientID, "&ContactID=", this.ContactID, "&pg=", this.pg, "&pagename=Dept&from=deptaddmode&addressid=", this.hdnAddressID.Value, "&parentpage=", this.ParentPage, "&popuplevel=", this.popuplevel, "&wintype=", this.wintype, "&companytype=", this.companytype };
                    response1.Redirect(string.Concat(clientID1));
                    return;
                }
                HttpResponse httpResponse1 = base.Response;
                object[] objArray1 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=view&clientid=", this.ClientID, "&pg=", this.pg, "&pagename=Dept&from=depteditmode&addressid=", this.hdnAddressID.Value, "&companytype=", this.companytype };
                httpResponse1.Redirect(string.Concat(objArray1));
            }
        }

        protected void lbl_ShippingChange_OnClick(object sender, EventArgs e)
        {
            base.Session["DeptID"] = this.hdn_DeptID.Value;
            this.StoreOldData();
            if (this.mode == "add")
            {
                if (this.ParentPage == "editcontact" || this.ParentPage == "newcontact")
                {
                    HttpResponse response = base.Response;
                    object[] clientID = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=view&clientid=", this.ClientID, "&ContactID=", this.ContactID, "&pg=", this.pg, "&pagename=Deptsh&from=deptaddmode&addressid=", this.hdnShippingAddressID.Value, "&parentpage=", this.ParentPage, "&popuplevel=", this.popuplevel, "&item=", this.item, "&id=", this.id, "&companytype=", this.companytype };
                    response.Redirect(string.Concat(clientID));
                }
                else
                {
                    HttpResponse httpResponse = base.Response;
                    object[] objArray = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=view&clientid=", this.ClientID, "&pg=", this.pg, "&pagename=Deptsh&from=deptaddmode&addressid=", this.hdnShippingAddressID.Value, "&companytype=", this.companytype };
                    httpResponse.Redirect(string.Concat(objArray));
                }
            }
            if (this.mode == "edit")
            {
                if (this.ParentPage == "editcontact" || this.ParentPage == "newcontact")
                {
                    HttpResponse response1 = base.Response;
                    object[] clientID1 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=view&clientid=", this.ClientID, "&ContactID=", this.ContactID, "&pg=", this.pg, "&pagename=Deptsh&from=depteditmode&addressid=", this.hdnShippingAddressID.Value, "&parentpage=", this.ParentPage, "&popuplevel=", this.popuplevel, "&wintype=", this.wintype, "&companytype=", this.companytype };
                    response1.Redirect(string.Concat(clientID1));
                    return;
                }
                HttpResponse httpResponse1 = base.Response;
                object[] objArray1 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=view&clientid=", this.ClientID, "&pg=", this.pg, "&pagename=Deptsh&from=depteditmode&addressid=", this.hdnShippingAddressID.Value, "&companytype=", this.companytype };
                httpResponse1.Redirect(string.Concat(objArray1));
            }
        }

        protected void lnk_Edit_OnClick(object sender, EventArgs e)
        {
            this.StoreOldData();
            if (this.mode == "add")
            {
                if (this.ParentPage == "editcontact" || this.ParentPage == "newcontact")
                {
                    HttpResponse response = base.Response;
                    object[] clientID = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=edit&clientid=", this.ClientID, "&ContactID=", this.ContactID, "&pg=", this.pg, "&pagename=deptaddmode&addressid=", this.hdnAddressID.Value, "&parentpage=", this.ParentPage, "&popuplevel=", this.popuplevel, "&item=", this.item, "&id=", this.id, "&companytype=", this.companytype };
                    response.Redirect(string.Concat(clientID));
                }
                else
                {
                    HttpResponse httpResponse = base.Response;
                    object[] objArray = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=edit&clientid=", this.ClientID, "&pg=", this.pg, "&pagename=deptaddmode&addressid=", this.hdnAddressID.Value, "&companytype=", this.companytype };
                    httpResponse.Redirect(string.Concat(objArray));
                }
            }
            if (this.mode == "edit")
            {
                if (this.ParentPage == "editcontact" || this.ParentPage == "newcontact")
                {
                    HttpResponse response1 = base.Response;
                    object[] clientID1 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=edit&clientid=", this.ClientID, "&ContactID=", this.ContactID, "&pg=", this.pg, "&pagename=depteditmode&addressid=", this.hdnAddressID.Value, "&parentpage=", this.ParentPage, "&popuplevel=", this.popuplevel, "&wintype=", this.wintype, "&companytype=", this.companytype };
                    response1.Redirect(string.Concat(clientID1));
                    return;
                }
                HttpResponse httpResponse1 = base.Response;
                object[] objArray1 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=edit&clientid=", this.ClientID, "&pg=", this.pg, "&pagename=depteditmode&addressid=", this.hdnAddressID.Value, "&companytype=", this.companytype };
                httpResponse1.Redirect(string.Concat(objArray1));
            }
        }

        protected void lnk_ShippingEdit_OnClick(object sender, EventArgs e)
        {
            this.StoreOldData();
            if (this.mode == "add")
            {
                if (this.ParentPage == "editcontact" || this.ParentPage == "newcontact")
                {
                    HttpResponse response = base.Response;
                    object[] clientID = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=edit&clientid=", this.ClientID, "&ContactID=", this.ContactID, "&pg=", this.pg, "&pagename=deptaddmodesh&addressid=", this.hdnShippingAddressID.Value, "&parentpage=", this.ParentPage, "&popuplevel=", this.popuplevel, "&item=", this.item, "&id=", this.id, "&companytype=", this.companytype };
                    response.Redirect(string.Concat(clientID));
                }
                else
                {
                    HttpResponse httpResponse = base.Response;
                    object[] objArray = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=edit&clientid=", this.ClientID, "&pg=", this.pg, "&pagename=deptaddmodesh&addressid=", this.hdnShippingAddressID.Value, "&companytype=", this.companytype };
                    httpResponse.Redirect(string.Concat(objArray));
                }
            }
            if (this.mode == "edit")
            {
                if (this.ParentPage == "editcontact" || this.ParentPage == "newcontact")
                {
                    HttpResponse response1 = base.Response;
                    object[] clientID1 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=edit&clientid=", this.ClientID, "&ContactID=", this.ContactID, "&pg=", this.pg, "&pagename=depteditmodesh&addressid=", this.hdnShippingAddressID.Value, "&parentpage=", this.ParentPage, "&popuplevel=", this.popuplevel, "&wintype=", this.wintype, "&companytype=", this.companytype };
                    response1.Redirect(string.Concat(clientID1));
                    return;
                }
                HttpResponse httpResponse1 = base.Response;
                object[] objArray1 = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=edit&clientid=", this.ClientID, "&pg=", this.pg, "&pagename=depteditmodesh&addressid=", this.hdnShippingAddressID.Value, "&companytype=", this.companytype };
                httpResponse1.Redirect(string.Concat(objArray1));
            }
        }

        public void Loadddlcostcenter()
        {
            string str;
            DataTable dataTable = DepartmentBaseClass.costcenter_getdetails(this.CompanyID, this.ClientID);
            DataTable dataTable1 = DepartmentBaseClass.costcenter_getdefaultcenter(this.ClientID);
            if (dataTable.Rows.Count > 0)
            {
                dataTable.Columns.Add("CombinedName");
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string str1 = this.objBase.SpecialDecode(dataTable.Rows[i]["CostCentreCode"].ToString());
                    string str2 = this.objBase.SpecialDecode(dataTable.Rows[i]["CostCentreName"].ToString());
                    if (str1 != "")
                    {
                        str = (str2 != "" ? string.Concat(str1, " - ", str2) : str1);
                    }
                    else
                    {
                        str = str2;
                    }
                    dataTable.Rows[i]["CombinedName"] = str;
                }
                this.ddlcostcenter.DataSource = dataTable;
                this.ddlcostcenter.DataValueField = "CostCentreID";
                this.ddlcostcenter.DataTextField = "CombinedName";
                this.ddlcostcenter.DataBind();
                if (dataTable1.Rows.Count != 0)
                {
                    this.setddlval(this.ddlcostcenter, Convert.ToInt32(dataTable1.Rows[0]["CostCentreID"]));
                }
            }
            this.lstcostcenters.DataValueField = "CostCentreID";
            this.lstcostcenters.DataTextField = "CombinedName";
            this.lstcostcenters.DataSource = dataTable;
            this.lstcostcenters.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.rdbnotallow.Text = this.objLangClass.GetLanguageConversion("Dont_allow_users_to_change_the_default_cost_centre");
            this.rdball.Text = this.objLangClass.GetLanguageConversion("Users_can_select_from_all_cost_centres");
            this.rdbonlyselected.Text = this.objLangClass.GetLanguageConversion("Users_can_see_only_selected");
            this.Label1.Text = this.objLangClass.GetLanguageConversion("Department_Default_Contact_and_Approver");
            this.btncancel.Text = this.objLangClass.GetLanguageConversion("Cancel");
            this.btnadd.Text = this.objLangClass.GetLanguageConversion("Save");
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            base.Request.Url.ToString();
            if (base.Request.Params["pg"] != null)
            {
                this.pg = base.Request.Params["pg"].ToString();
                this.Pgtype = base.Request.Params["pg"].ToString();
            }
            if (base.Request.Params["ClientID"] != null)
            {
                this.ClientID = Convert.ToInt32(base.Request.Params["ClientID"].ToString());
            }
            if (base.Request.Params["ContactID"] != null)
            {
                this.ContactID = Convert.ToInt32(base.Request.Params["ContactID"].ToString());
            }
            if (base.Request.Params["companytype"] != null)
            {
                this.companytype = base.Request.Params["companytype"].ToString();
            }
            if (this.companytype.ToLower() != "supplier")
            {
                this.Label2.Text = this.objLangClass.GetLanguageConversion("Invoice_Contact");
            }
            else
            {
                this.Label2.Text = this.objLangClass.GetLanguageConversion("Purchase_Order_Contact");
                this.Costcenter.Visible = false;
            }
            if (base.Request.Params["mode"] != null)
            {
                this.mode = base.Request.Params["mode"].ToString();
            }
            if (base.Request.Params["DeptID"] != null)
            {
                this.DeptID = Convert.ToInt64(base.Request.Params["DeptID"].ToString());
                this.hdn_DeptID.Value = base.Request.Params["DeptID"].ToString();
                base.Session["DeptID"] = base.Request.Params["DeptID"].ToString();
            }
            if (base.Request.Params["parentpage"] != null)
            {
                this.ParentPage = base.Request.Params["parentpage"].ToString();
            }
            if (base.Request.Params["isfromAddressView"] != null)
            {
                this.isfromAddressView = base.Request.Params["isfromAddressView"].ToString().ToLower().Trim();
                if (this.isfromAddressView == "yes")
                {
                    this.div_cancel.Style.Add("display", "block");
                }
            }
            if (base.Request.Params["From"] != null)
            {
                this.From = base.Request.Params["From"].ToString();
                if (this.From.ToLower() == "editcontact" || this.From.ToLower() == "newcontact" || this.From.ToLower() == "addressSelect" || this.From.ToLower() == "estimate")
                {
                    this.div_cancel.Style.Add("display", "block");
                }
            }
            if (base.Request.Params["IsAddMode"] != null)
            {
                this.IsAddMode = base.Request.Params["IsAddMode"].ToString().ToLower().Trim();
            }
            if (base.Request.Params["type"] != null)
            {
                this.type = base.Request.Params["type"].ToString().ToLower().Trim();
            }
            if (base.Request.Params["item"] != null)
            {
                this.item = base.Request.Params["item"].ToString().ToLower().Trim();
            }
            if (base.Request.Params["id"] != null)
            {
                this.id = Convert.ToInt32(base.Request.Params["id"]);
            }
            if (base.Request.Params["popuplevel"] != null)
            {
                this.popuplevel = Convert.ToInt32(base.Request.Params["popuplevel"]);
                if (this.popuplevel == 2)
                {
                    this.div_cancel.Style.Add("display", "block");
                }
            }
            if (base.Request.Params["wintype"] != null)
            {
                this.wintype = base.Request.Params["wintype"].ToString().ToLower();
            }
            if (!Convert.ToBoolean(SettingsBasePage.settings_regionalsettings_select(this.CompanyID).Rows[0]["IsDisplayCostCentre"]) || !(this.companytype.ToLower() != "supplier"))
            {
                this.div_costcentrefields.Style.Add("display", "none");
            }
            else
            {
                this.div_costcentrefields.Style.Add("display", "block");
                if (!base.IsPostBack)
                {
                    this.Loadddlcostcenter();
                }
            }
            this.txtDeptName.Focus();
            this.txt_DeptDefaultContact.Attributes.Add("autocomplete", "off");
            if (!base.IsPostBack)
            {
                if (this.IsAddMode == "yes")
                {
                    base.Session["DeptInvoice"] = null;
                }
                AttributeCollection attributes = this.txt_DeptDefaultContact.Attributes;
                object[] companyID = new object[] { "javascript:displayContact(this,'customer','", this.CompanyID, "','1',event,'", this.ClientID, "');" };
                attributes.Add("onkeyup", string.Concat(companyID));
                AttributeCollection attributeCollection = this.txt_DeptDefaultContact.Attributes;
                object[] objArray = new object[] { "javascript:displayContact(this,'customer','", this.CompanyID, "','1',event,'", this.ClientID, "');" };
                attributeCollection.Add("onclick", string.Concat(objArray));
                foreach (DataRow row in DepartmentBaseClass.client_contacts_select(this.ClientID, this.CompanyID, "yes").Rows)
                {
                    if (!Convert.ToBoolean(row["DefaultContact"]))
                    {
                        continue;
                    }
                    this.txt_DeptDefaultContact.Text = row["ContactName"].ToString();
                    if (row["ContactID"] == null)
                    {
                        this.ContactID = 0;
                    }
                    else
                    {
                        this.ContactID = Convert.ToInt32(row["ContactID"].ToString());
                    }
                    this.hdn_DefaultContactID.Value = this.ContactID.ToString();
                }
                DataSet dataSet = DepartmentBaseClass.client_contacts_selectAll(this.ClientID, this.CompanyID);
                DataTable item = dataSet.Tables[0];
                foreach (DataRow dataRow in item.Rows)
                {
                    if (dataRow.Table.Columns["ContactName"] == null)
                    {
                        continue;
                    }
                    dataRow["ContactName"] = this.objBase.SpecialDecode(dataRow["ContactName"].ToString());
                }
                this.ddlContacts.DataSource = item;
                this.ddlContacts.DataTextField = "ContactName";
                this.ddlContacts.DataValueField = "ContactID";
                this.ddlContacts.DataBind();
                this.ddlContacts.Items.Insert(0, "--Select--");
                this.ddlContacts.Items[0].Text = "--Select--";
                this.ddlContacts.Items[0].Value = "0";
                this.ddlInvoiceContact.DataSource = item;
                this.ddlInvoiceContact.DataTextField = "ContactName";
                this.ddlInvoiceContact.DataValueField = "ContactID";
                this.ddlInvoiceContact.DataBind();
                this.ddlInvoiceContact.Items.Insert(0, "--Select--");
                this.ddlInvoiceContact.Items[0].Text = "--Select--";
                this.ddlInvoiceContact.Items[0].Value = "0";
                if (base.Session["DeptID"] == null)
                {
                    this.mode = "add";
                }
                else if (base.Session["DeptID"].ToString().Trim().Length == 0 || base.Session["DeptID"].ToString().Trim() == "0")
                {
                    this.mode = "add";
                }
                if (this.mode == "add")
                {
                    try
                    {
                        DataTable dataTable = DepartmentBaseClass.department_getAllDetails(this.CompanyID, this.UserID, this.ClientID, (long)Convert.ToInt32(base.Session["DeptID"]));
                        if (dataTable.Rows.Count > 0)
                        {
                            foreach (DataRow row1 in dataTable.Rows)
                            {
                                if (Convert.ToInt32(row1["CostCentreID"]) == 0)
                                {
                                    continue;
                                }
                                this.setddlval(this.ddlcostcenter, Convert.ToInt32(row1["CostCentreID"]));
                            }
                        }
                    }
                    catch
                    {
                    }
                    DataTable dataTable1 = CompanyBasePage.company_client_select(this.CompanyID, this.ClientID, this.companytype);
                    foreach (DataRow dataRow1 in dataTable1.Rows)
                    {
                        if (dataRow1["companytype"].ToString().ToLower() != "customer")
                        {
                            this.DivApprover.Visible = false;
                        }
                        else
                        {
                            this.DivApprover.Visible = true;
                            DataTable dataTable2 = SettingsBasePage.Check_IsApprovalFeaturesOn(Convert.ToInt32(base.Session["companyID"].ToString()));
                            foreach (DataRow row2 in dataTable2.Rows)
                            {
                                if (row2["IsApprovalFeaturesOn"].ToString().ToLower() != "false")
                                {
                                    this.DivApprover.Visible = true;
                                }
                                else
                                {
                                    this.DivApprover.Visible = false;
                                }
                            }
                        }
                        this.AddressType = "A";
                        this.hdnAddressType.Value = "A";
                        DataSet deptAddressDetails = CompanyBasePage.GetDeptAddressDetails(this.CompanyID, Convert.ToInt32(dataRow1["DeptID"].ToString()));
                        foreach (DataRow dataRow2 in deptAddressDetails.Tables[0].Rows)
                        {
                            this.AddressID = Convert.ToInt32(dataRow2["InvoiceAddressID"].ToString());
                            this.hdnAddressID.Value = dataRow2["InvoiceAddressID"].ToString();
                            this.GetAllDeptDetails(Convert.ToInt32(dataRow2["InvoiceAddressID"].ToString()), this.objBase.SpecialDecode(dataRow2["Address"].ToString()), this.objBase.SpecialDecode(dataRow2["AddressLine2"].ToString()), this.objBase.SpecialDecode(dataRow2["City"].ToString()), this.objBase.SpecialDecode(dataRow2["State"].ToString()), this.objBase.SpecialDecode(dataRow2["ZipCode"].ToString()), this.objBase.SpecialDecode(dataRow2["Country"].ToString()), this.objBase.SpecialDecode(dataRow2["Telephone"].ToString()), this.objBase.SpecialDecode(dataRow2["Fax"].ToString()), Convert.ToString(dataRow2["AddressLabel"]) , "billing");


                            deptartment_add billingAddressCnt = this;
                            billingAddressCnt.billingAddress_cnt = billingAddressCnt.billingAddress_cnt + 1;
                        }
                        foreach (DataRow row3 in deptAddressDetails.Tables[1].Rows)
                        {
                            this.hdnShippingAddressID.Value = row3["DeliveryAddressID"].ToString();
                            this.GetAllDeptDetails(Convert.ToInt32(row3["DeliveryAddressID"].ToString()), this.objBase.SpecialDecode(row3["Address"].ToString()), this.objBase.SpecialDecode(row3["AddressLine2"].ToString()), this.objBase.SpecialDecode(row3["City"].ToString()), this.objBase.SpecialDecode(row3["State"].ToString()), this.objBase.SpecialDecode(row3["ZipCode"].ToString()), this.objBase.SpecialDecode(row3["Country"].ToString()), this.objBase.SpecialDecode(row3["Telephone"].ToString()), this.objBase.SpecialDecode(row3["Fax"].ToString()), Convert.ToString(row3["AddressLabel"]), "shipping");

                            deptartment_add shippingAddressCnt = this;
                            shippingAddressCnt.shippingAddress_cnt = shippingAddressCnt.shippingAddress_cnt + 1;
                        }
                    }
                    if (this.IsAddMode != "yes")
                    {
                        this.getStoredData();
                    }
                    if (this.billingAddress_cnt == 0)
                    {
                        this.lnk_Edit.Style.Add("display", "none");
                        this.lbl_Spliter.Style.Add("display", "none");
                    }
                    if (this.shippingAddress_cnt == 0)
                    {
                        this.lnk_ShippingEdit.Style.Add("display", "none");
                        this.lbl_ShippingSpliter.Style.Add("display", "none");
                    }
                }
                else if (this.mode == "edit")
                {
                    if (base.Request.Params["DeptID"] == null)
                    {
                        if (base.Session["DeptID"] != null)
                        {
                            var depid = base.Session["DeptID"].ToString();
                            this.DeptID = Convert.ToInt64(depid.ToString());
                            this.hdn_DeptID.Value = depid.ToString();
                            base.Session["DeptID"] = depid.ToString();
                        }
                    }

                    deptartment_add.IsEditOnlyHisRecords = this.objBase.ReturnRoles_Privileges_Others("editrecords");
                    DataTable dataTable3 = CompanyBasePage.company_client_select(this.CompanyID, this.ClientID, this.companytype);
                    foreach (DataRow dataRow3 in dataTable3.Rows)
                    {
                        deptartment_add.SalesPersonID = dataRow3["SalesPerson"].ToString();
                    }
                    if (deptartment_add.IsEditOnlyHisRecords.ToLower() == "his" && base.Session["UserID"].ToString() != deptartment_add.SalesPersonID)
                    {
                        this.btnadd.Visible = false;
                    }
                    foreach (DataRow row4 in dataTable3.Rows)
                    {
                        if (row4["companytype"].ToString().ToLower() != "customer")
                        {
                            this.DivApprover.Visible = false;
                        }
                        else
                        {
                            this.DivApprover.Visible = true;
                            DataTable dataTable4 = SettingsBasePage.Check_IsApprovalFeaturesOn(Convert.ToInt32(base.Session["companyID"].ToString()));
                            foreach (DataRow dataRow4 in dataTable4.Rows)
                            {
                                if (dataRow4["IsApprovalFeaturesOn"].ToString().ToLower() != "false")
                                {
                                    this.DivApprover.Visible = true;
                                }
                                else
                                {
                                    this.DivApprover.Visible = false;
                                }
                            }
                        }
                    }
                    DataTable dataTable5 = DepartmentBaseClass.department_getAllDetails(this.CompanyID, this.UserID, this.ClientID, (long)Convert.ToInt32(base.Session["DeptID"]));
                    foreach (DataRow row5 in dataTable5.Rows)
                    {
                        this.txtDeptName.Text = this.objBase.SpecialDecode(row5["DeptName"].ToString());
                        this.txt_DeptDefaultContact.Text = this.objBase.SpecialDecode(row5["ContactName"].ToString());
                        this.AddressID = Convert.ToInt32(row5["AddressID"].ToString());
                        this.hdnAddressID.Value = row5["AddressID"].ToString();
                        this.hdn_DefaultContactID.Value = row5["DefaultContactID"].ToString();
                        this.hdnShippingAddressID.Value = row5["DeliveryAddressID"].ToString();
                        if (row5["DefaultContactID"] == null)
                        {
                            this.ContactID = 0;
                        }
                        else
                        {
                            this.ContactID = Convert.ToInt32(row5["DefaultContactID"].ToString());
                        }
                        this.hdn_DefaultContactID.Value = this.ContactID.ToString();
                        if (!(row5["InvoiceAddress"].ToString().Trim() == "") || !(row5["Address"].ToString().Trim() == "") || !(row5["AddressLine2"].ToString().Trim() == "") || !(row5["City"].ToString().Trim() == "") || !(row5["State"].ToString().Trim() == "") || !(row5["ZipCode"].ToString().Trim() == "") || !(row5["Country"].ToString().Trim() == "") || !(row5["Telephone"].ToString().Trim() == "") || !(row5["Fax"].ToString().Trim() == ""))
                        {
                            this.GetAllDeptDetails(this.AddressID, this.objBase.SpecialDecode(row5["Address"].ToString()), this.objBase.SpecialDecode(row5["AddressLine2"].ToString()), this.objBase.SpecialDecode(row5["City"].ToString()), this.objBase.SpecialDecode(row5["State"].ToString()), this.objBase.SpecialDecode(row5["ZipCode"].ToString()), this.objBase.SpecialDecode(row5["Country"].ToString()), this.objBase.SpecialDecode(row5["Telephone"].ToString()), this.objBase.SpecialDecode(row5["Fax"].ToString()), Convert.ToString(row5["InvoiceAddressLabel"]), "Billing");
                            deptartment_add usercontrolDepartmentsDeptartmentAdd = this;
                            usercontrolDepartmentsDeptartmentAdd.billingAddress_cnt = usercontrolDepartmentsDeptartmentAdd.billingAddress_cnt + 1;
                        }
                        if (!(row5["DeliveryAddress1"].ToString().Trim() == "") || !(row5["DeliveryAddress"].ToString().Trim() == "") || !(row5["DeliveryAddressLine2"].ToString().Trim() == "") || !(row5["DeliveryCity"].ToString().Trim() == "") || !(row5["DeliveryState"].ToString().Trim() == "") || !(row5["DeliveryZipCode"].ToString().Trim() == "") || !(row5["DeliveryCountry"].ToString().Trim() == "") || !(row5["DeliveryTelephone"].ToString().Trim() == "") || !(row5["DeliveryFax"].ToString().Trim() == ""))
                        {
                            this.GetAllDeptDetails(this.AddressID, this.objBase.SpecialDecode(row5["DeliveryAddress"].ToString()), this.objBase.SpecialDecode(row5["DeliveryAddressLine2"].ToString()), this.objBase.SpecialDecode(row5["DeliveryCity"].ToString()), this.objBase.SpecialDecode(row5["DeliveryState"].ToString()), this.objBase.SpecialDecode(row5["DeliveryZipCode"].ToString()), this.objBase.SpecialDecode(row5["DeliveryCountry"].ToString()), this.objBase.SpecialDecode(row5["DeliveryTelephone"].ToString()), this.objBase.SpecialDecode(row5["DeliveryFax"].ToString()), Convert.ToString(row5["AddressLabel"]), "Shipping");
                            deptartment_add shippingAddressCnt1 = this;
                            shippingAddressCnt1.shippingAddress_cnt = shippingAddressCnt1.shippingAddress_cnt + 1;
                        }
                        if (row5["DeptApproverID"].ToString() != "" && row5["DeptApproverID"].ToString() != null)
                        {
                            this.objBase.SetDDLValue(this.ddlContacts, row5["DeptApproverID"].ToString());
                        }
                        if (row5["InvoiceContactID"].ToString() != "" && row5["InvoiceContactID"].ToString() != null)
                        {
                            this.objBase.SetDDLValue(this.ddlInvoiceContact, row5["InvoiceContactID"].ToString());
                        }
                        if (Convert.ToInt32(row5["CostCentreID"]) != 0)
                        {
                            this.setddlval(this.ddlcostcenter, Convert.ToInt32(row5["CostCentreID"]));
                        }
                        if (row5["OtherCostCentre"].ToString() != "")
                        {
                            if (row5["OtherCostCentre"].ToString() == "N")
                            {
                                this.rdbnotallow.Checked = true;
                            }
                            else if (row5["OtherCostCentre"].ToString() == "A")
                            {
                                this.rdball.Checked = true;
                            }
                            else if (row5["OtherCostCentre"].ToString() == "S")
                            {
                                this.rdbonlyselected.Checked = true;
                            }
                        }
                        if (row5["IsApprovalNotRequired"].ToString().ToLower() != "true")
                        {
                            this.chkdeptnotapproval.Checked = false;
                        }
                        else
                        {
                            this.chkdeptnotapproval.Checked = true;
                        }
                        this.txtc1.Text = this.objBase.SpecialDecode(row5["CustomField1"].ToString());
                        this.txtc2.Text = this.objBase.SpecialDecode(row5["CustomField2"].ToString());
                        this.txtc3.Text = this.objBase.SpecialDecode(row5["CustomField3"].ToString());
                        this.txtc4.Text = this.objBase.SpecialDecode(row5["CustomField4"].ToString());
                        this.txtc5.Text = this.objBase.SpecialDecode(row5["CustomField5"].ToString());
                        this.txtc6.Text = this.objBase.SpecialDecode(row5["CustomField6"].ToString());
                        this.txtc7.Text = this.objBase.SpecialDecode(row5["CustomField7"].ToString());
                        this.txtc8.Text = this.objBase.SpecialDecode(row5["CustomField8"].ToString());
                        this.txtc9.Text = this.objBase.SpecialDecode(row5["CustomField9"].ToString());
                        this.txtc10.Text = this.objBase.SpecialDecode(row5["CustomField10"].ToString());
                        this.txtc11.Text = this.objBase.SpecialDecode(row5["CustomField11"].ToString());
                        this.txtc12.Text = this.objBase.SpecialDecode(row5["CustomField12"].ToString());
                        this.txtc13.Text = this.objBase.SpecialDecode(row5["CustomField13"].ToString());
                        this.txtc14.Text = this.objBase.SpecialDecode(row5["CustomField14"].ToString());
                        this.txtc15.Text = this.objBase.SpecialDecode(row5["CustomField15"].ToString());
                        if (row5["ActualFileName"].ToString() != "")
                        {
                            this.hid_Actualfilename.Value = row5["ActualFileName"].ToString();
                            this.hid_Originalfilename.Value = row5["OriginalFileName"].ToString();
                            this.hid_IsProccessed.Value = row5["IsProcessed"].ToString();
                            this.hid_ContactImage.Value = row5["OriginalFileName"].ToString();
                            this.ImageUpload.Attributes.Add("style", "display:none");
                            this.ContactImage.Attributes.Add("style", "display:block");
                            this.ContactImage.Attributes.Add("style", "margin-top:22px;");
                            QueryString queryString = new QueryString()
						{
							{ "doctype", "DeptImg" }
						};
                            Label label = this.lblContactImage;
                            string[] strArrays = new string[] { "<a href='", this.strSitepath, "DocManager.ashx", queryString.ToString().Trim(), "&filename=", row5["ActualFileName"].ToString(), "'style='margin-right:20px;'target='_blank'>", row5["OriginalFileName"].ToString(), "</a> <img src='../images/erase.png' onclick=RemoveImage(); title='Remove'>" };
                            label.Text = string.Concat(strArrays);
                            this.lblContactImage.ToolTip = row5["OriginalFileName"].ToString();
                        }
                        foreach (DataRow dataRow5 in DepartmentBaseClass.departmentcostcentre_select(Convert.ToInt32(this.DeptID)).Rows)
                        {
                            for (int i = 0; i < this.lstcostcenters.Items.Count; i++)
                            {
                                if (this.lstcostcenters.Items[i].Value == dataRow5["CostCentreID"].ToString())
                                {
                                    this.lstcostcenters.Items[i].Selected = true;
                                }
                            }
                        }
                        this.txtTerritory_Manager_Email.Text = this.objBase.SpecialDecode(row5["TerritoryManagerEmail"].ToString());
                    }
                    if (base.Session["DeptInvoice"] != null)
                    {
                        this.getStoredData();
                    }
                    if (this.billingAddress_cnt == 0)
                    {
                        this.lnk_Edit.Style.Add("display", "none");
                        this.lbl_Spliter.Style.Add("display", "none");
                    }
                    if (this.shippingAddress_cnt == 0)
                    {
                        this.lnk_ShippingEdit.Style.Add("display", "none");
                        this.lbl_ShippingSpliter.Style.Add("display", "none");
                    }
                }
            }
            if (Convert.ToInt32(WebstoreBasePage.IsApprovalFeaturesOn_Select((long)this.CompanyID)) != 1 || !(this.companytype.ToLower() != "supplier"))
            {
                this.div_deptapproval.Style.Add("display", "none");
            }
            else
            {
                this.div_deptapproval.Style.Add("display", "block"); 
            }
            this.lbl_ShippingChange.Text = this.objLangClass.GetLanguageConversion("Change_New_Address");
            this.lnk_Change.Text = this.objLangClass.GetLanguageConversion("Change_New_Address");
            this.btnadd.Text = this.objLangClass.GetLanguageConversion("Save");
            string empty = string.Empty;
            if (this.objBase.ReturnRoles_Privileges_ForGrid("clients", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                this.div_add.Visible = true;
                this.DivChangeNewAddress.Visible = true;
                this.DivChangeAddress.Visible = true;
                this.DivEdit.Visible = true;
                this.Divlnk_ShippingEdit.Visible = true;
                if (deptartment_add.IsEditOnlyHisRecords.ToLower() == "his" && base.Session["UserID"].ToString() != deptartment_add.SalesPersonID)
                {
                    this.div_changeShipping.Visible = false;
                    this.DivEditHis.Visible = false;
                }
            }
            else
            {
                this.div_add.Visible = false;
                this.DivChangeNewAddress.Visible = false;
                this.DivChangeAddress.Visible = false;
                this.DivEdit.Visible = false;
                this.Divlnk_ShippingEdit.Visible = false;
                this.div_changeShipping.Visible = false;
            }
            DataTable dataTable6 = new DataTable();
            dataTable6 = DepartmentBaseClass.DepartmentCustomFields_ScreenName_Select((long)this.CompanyID);
            int num = 1;
            foreach (DataRow row6 in dataTable6.Rows)
            {
                Label label1 = (Label)this.FindControl(string.Concat("lblcustom", num));
                label1.Text = this.objBase.SpecialDecode(row6["ScreenName"].ToString());
                num++;
            }
            if (!DepartmentBaseClass.CheckApproveEnable((long)this.ClientID))
            {
                this.Label1.Text = this.objLangClass.GetLanguageConversion("Department_Default_Contact_and_Approver");
            }
            if (ConnectionClass.IsTerritoryManagerEmail)
            {
                this.div_Territory_Manager_Email.Style.Add("display", "block");
            }
        }

        public void setddlval(DropDownList ddl, int value)
        {
            ListItem listItem = ddl.Items.FindByValue(value.ToString());
            ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
        }

        public void StoreOldData()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("DeptID", typeof(int));
            dataTable.Columns.Add("DeptName", typeof(string));
            dataTable.Columns.Add("AddressID", typeof(string));
            dataTable.Columns.Add("AddressTo", typeof(string));
            if (this.hdn_DeptID.Value == "")
            {
                this.hdn_DeptID.Value = "0";
            }
            object[] num = new object[] { Convert.ToInt32(this.hdn_DeptID.Value), this.txtDeptName.Text, this.hdnAddressID.Value, "billing" };
            dataTable.Rows.Add(num);
            object[] value = new object[] { this.hdn_DeptID.Value, this.txtDeptName.Text, this.hdnShippingAddressID.Value, "shipping" };
            dataTable.Rows.Add(value);
            base.Session["DeptInvoice"] = dataTable;
        }
    }
}