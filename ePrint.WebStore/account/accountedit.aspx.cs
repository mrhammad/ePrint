using nmsCommon;
using nmsConnection;
using nmsEmail;
using nmsLanguage;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
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


namespace ePrint.WebStore.account
{
    public partial class accountedit : BaseClass, IRequiresSessionState
    {
        //protected System.Web.UI.ScriptManager sm1;

        //protected usercontrols_account_leftpanel account_panel1;

        //protected Label LblErrorMsg;

        //protected HtmlGenericControl DivLblErrorMsg;

        //protected Label Label2;

        //protected TextBox txt_CompanyName;

        //protected Label lblDepartment;

        //protected TextBox txtDepartment;

        //protected Label lbl_firstName;

        //protected TextBox txt_firstName;

        //protected CheckBox chk_changePwd;

        //protected Label lbl_currentPwd;

        //protected TextBox txt_currentPwd;

        //protected HiddenField hdnPassword;

        //protected Label lbl_newPwd;

        //protected TextBox txt_newPwd;

        //protected Label lbl_email;

        //protected TextBox txt_email;

        //protected Label lbl_lastName;

        //protected TextBox txt_lastName;

        //protected Label Label7;

        //protected TextBox txtApproverEmail;

        //protected HiddenField hdnApproverID;

        //protected HtmlGenericControl DivApproverEmail;

        //protected Label lblReqiEmail;

        //protected Label lbl_confirmPwd;

        //protected TextBox txt_confirmPwd;

        //protected Button btnSave;

        //protected HiddenField hdnValidation;

        private commonclass comm = new commonclass();

        public string strImagepath = BaseClass.imagePath();

        private storeEmail objEmail = new storeEmail();

        public languageClass objLanguage = new languageClass();

        public long StoreUserID;

        public int ClientID;

        public long CompanyID;

        public long AccountID;

        public long AddressID;

        public long DepartmentID;

        public string RewriteModule;

        public string Subject = string.Empty;

        public string EmailBodyApprover = string.Empty;

        public string strSitepath = string.Empty;

        public string FileExtension = string.Empty;

        public string type = string.Empty;

        public string IsHomePageVisible = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string approvalType = string.Empty;

        public string UserType = string.Empty;

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

        public accountedit()
        {
        }

        protected void OnClick_btnSave(object sender, EventArgs e)
        {
            if (this.Session["ApprovalSystem"] != null)
            {
                if (this.Session["ApprovalSystem"] != null)
                {
                    if (!this.chk_changePwd.Checked)
                    {
                        LoginBasePage.Create_StoreUser(this.StoreUserID, (long)0, this.txt_firstName.Text, this.txt_lastName.Text, base.SpecialEncode(this.txt_email.Text), this.txt_newPwd.Text, this.CompanyID, this.AccountID, "", this.txt_CompanyName.Text);
                    }
                    else
                    {
                        LoginBasePage.Create_StoreUser(this.StoreUserID, (long)0, this.txt_firstName.Text, this.txt_lastName.Text, base.SpecialEncode(this.txt_email.Text), this.txt_newPwd.Text.Trim(), this.CompanyID, this.AccountID, "yes", this.txt_CompanyName.Text);
                    }
                    this.Session["FirstName"] = this.txt_firstName.Text.Trim();
                    this.Session["LastName"] = this.txt_lastName.Text.Trim();
                }
                else
                {
                    this.approvalType = base.Return_ApprovalSystem_Settings("approvaltype");
                    if (base.Return_ApprovalSystem_Settings("editeduserapprove").ToLower().Trim() != "true")
                    {
                        if (!this.chk_changePwd.Checked)
                        {
                            LoginBasePage.Create_StoreUser(this.StoreUserID, (long)0, this.txt_firstName.Text, this.txt_lastName.Text, base.SpecialEncode(this.txt_email.Text), this.txt_newPwd.Text, this.CompanyID, this.AccountID, "", this.txt_CompanyName.Text);
                        }
                        else
                        {
                            LoginBasePage.Create_StoreUser(this.StoreUserID, (long)0, this.txt_firstName.Text, this.txt_lastName.Text, base.SpecialEncode(this.txt_email.Text), this.txt_newPwd.Text.Trim(), this.CompanyID, this.AccountID, "yes", this.txt_CompanyName.Text);
                        }
                        this.Session["FirstName"] = this.txt_firstName.Text.Trim();
                        this.Session["LastName"] = this.txt_lastName.Text.Trim();
                    }
                    else if (this.approvalType == "u" && this.UserType == "u" || this.approvalType == "u" && this.UserType == "m" || this.approvalType == "u" && this.UserType == "d")
                    {
                        if (!this.chk_changePwd.Checked)
                        {
                            LoginBasePage.Insert_StoreUser_temp(0, this.StoreUserID, base.SpecialEncode(this.txt_firstName.Text), base.SpecialEncode(this.txt_lastName.Text), base.SpecialEncode(this.txt_email.Text), this.hdnPassword.Value, this.AccountID, this.AddressID, this.txtApproverEmail.Text, this.approvalType, "p");
                            this.objEmail.B2BProfileApprovalDetails_Email(this.StoreUserID, Convert.ToInt32(this.CompanyID), this.AccountID, "B2B User Profile Modification", "approver", (long)0, this.txtApproverEmail.Text.Trim());
                        }
                        else
                        {
                            LoginBasePage.Insert_StoreUser_temp(0, this.StoreUserID, base.SpecialEncode(this.txt_firstName.Text), base.SpecialEncode(this.txt_lastName.Text), base.SpecialEncode(this.txt_email.Text), this.txt_newPwd.Text.Trim(), this.AccountID, this.AddressID, this.txtApproverEmail.Text, this.approvalType, "p");
                            this.objEmail.B2BProfileApprovalDetails_Email(this.StoreUserID, Convert.ToInt32(this.CompanyID), this.AccountID, "B2B User Profile Modification", "approver", (long)0, this.txtApproverEmail.Text.Trim());
                        }
                    }
                    else if ((!(this.approvalType == "a") || !(this.UserType == "u")) && (!(this.approvalType == "a") || !(this.UserType == "d")) && (!(this.approvalType == "da") || !(this.UserType == "u")))
                    {
                        if (!this.chk_changePwd.Checked)
                        {
                            LoginBasePage.Create_StoreUser(this.StoreUserID, (long)0, this.txt_firstName.Text, this.txt_lastName.Text, base.SpecialEncode(this.txt_email.Text), this.txt_newPwd.Text, this.CompanyID, this.AccountID, "", this.txt_CompanyName.Text);
                        }
                        else
                        {
                            LoginBasePage.Create_StoreUser(this.StoreUserID, (long)0, this.txt_firstName.Text, this.txt_lastName.Text, base.SpecialEncode(this.txt_email.Text), this.txt_newPwd.Text.Trim(), this.CompanyID, this.AccountID, "yes", this.txt_CompanyName.Text);
                        }
                        this.Session["FirstName"] = this.txt_firstName.Text.Trim();
                        this.Session["LastName"] = this.txt_lastName.Text.Trim();
                    }
                    else
                    {
                        string empty = string.Empty;
                        string str = string.Empty;
                        DataSet dataSet = new DataSet();
                        dataSet = LoginBasePage.ApproversEmail_Select(this.AccountID, this.DepartmentID);
                        DataTable dataTable = new DataTable();
                        dataTable = dataSet.Tables[0];
                        DataTable item = new DataTable();
                        item = dataSet.Tables[1];
                        if (this.approvalType == "a")
                        {
                            foreach (DataRow row in dataTable.Rows)
                            {
                                empty = row["email"].ToString();
                                str = string.Concat(row["contactID"].ToString(), "~", row["email"].ToString());
                            }
                        }
                        else if (this.approvalType == "da")
                        {
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                if (!(dataRow["email"].ToString() != "") || dataRow["email"].ToString() == null)
                                {
                                    continue;
                                }
                                empty = string.Concat(dataRow["email"].ToString(), ",");
                                str = string.Concat(dataRow["contactID"].ToString(), "~", dataRow["email"].ToString(), ",");
                            }
                            foreach (DataRow row1 in item.Rows)
                            {
                                empty = string.Concat(empty, row1["email"].ToString(), ",");
                                string[] strArrays = new string[] { str, row1["contactID"].ToString(), "~", row1["email"].ToString(), "," };
                                str = string.Concat(strArrays);
                            }
                        }
                        empty = empty.Remove(empty.Length - 1, 1);
                        str = str.Remove(str.Length - 1, 1);
                        if (!this.chk_changePwd.Checked)
                        {
                            LoginBasePage.Insert_StoreUser_temp(0, this.StoreUserID, base.SpecialEncode(this.txt_firstName.Text), base.SpecialEncode(this.txt_lastName.Text), base.SpecialEncode(this.txt_email.Text), this.hdnPassword.Value, this.AccountID, this.AddressID, empty, this.approvalType, "p");
                            string[] strArrays1 = str.Split(new char[] { ',' });
                            for (int i = 0; i < (int)strArrays1.Length; i++)
                            {
                                string str1 = strArrays1[i];
                                string[] strArrays2 = str1.Split(new char[] { '~' });
                                if (strArrays2[0].ToString() != "" && strArrays2[0].ToString() != null)
                                {
                                    this.objEmail.B2BProfileApprovalDetails_Email(this.StoreUserID, Convert.ToInt32(this.CompanyID), this.AccountID, "B2B User Profile Modification", "approver", Convert.ToInt64(strArrays2[0]), strArrays2[1].ToString());
                                }
                            }
                        }
                        else
                        {
                            LoginBasePage.Insert_StoreUser_temp(0, this.StoreUserID, base.SpecialEncode(this.txt_firstName.Text), base.SpecialEncode(this.txt_lastName.Text), base.SpecialEncode(this.txt_email.Text), this.txt_newPwd.Text.Trim(), this.AccountID, this.AddressID, empty, this.approvalType, "p");
                            string[] strArrays3 = str.Split(new char[] { ',' });
                            for (int j = 0; j < (int)strArrays3.Length; j++)
                            {
                                string str2 = strArrays3[j];
                                string[] strArrays4 = str2.Split(new char[] { '~' });
                                if (strArrays4[0].ToString() != "" && strArrays4[0].ToString() != null)
                                {
                                    this.objEmail.B2BProfileApprovalDetails_Email(this.StoreUserID, Convert.ToInt32(this.CompanyID), this.AccountID, "B2B User Profile Modification", "approver", Convert.ToInt64(strArrays4[0]), strArrays4[1].ToString());
                                }
                            }
                        }
                    }
                }
                if (ConnectionClass.RewriteModule.ToLower() == "on")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "account/account", ConnectionClass.FileExtension));
                    return;
                }
                base.Response.Redirect(string.Concat(this.strSitepath, "account/account.aspx"));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Label label = (Label)base.Master.FindControl("lblPathLink");
            string[] sitePath = new string[] { "<a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "account/account.aspx' >", this.objLanguage.GetLanguageConversion("My_Account"), "</a><span Class='floatLeft'>&nbsp;>>&nbsp;</span><a Class='floatLeft' href ='", BaseClass.SitePath, "account/accountedit.aspx' ></a>", this.objLanguage.GetLanguageConversion("Edit_Account") };
            label.Text = string.Concat(sitePath);
            this.chk_changePwd.Text = string.Concat("  ", this.objLanguage.GetLanguageConversion("Change_Password"));
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension;
            }
            if (base.Request.Params["type"] != null)
            {
                this.type = base.Request.Params["type"].ToString();
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt64(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                this.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            if (this.Session["StoreUserID"] == null)
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx"));
            }
            else
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            foreach (DataRow row in OrderBasePage.Get_IsApprovalProfile(this.StoreUserID).Rows)
            {
                if (this.Session["ApprovalSystem"] != null)
                {
                    this.DivLblErrorMsg.Visible = false;
                    this.btnSave.Visible = true;
                }
                else if (row["IsApproved"].ToString().ToLower() == "true" || row["Rejected"].ToString().ToLower() == "true")
                {
                    this.DivLblErrorMsg.Visible = false;
                    this.btnSave.Visible = true;
                }
                else
                {
                    this.DivLblErrorMsg.Visible = true;
                    this.btnSave.Visible = false;
                }
            }
            if (base.Request.Params["ID"] != null)
            {
                this.AddressID = Convert.ToInt64(base.Request.Params["ID"]);
            }
            if (this.Session["IsHomePageVisible"] != null && this.Session["IsHomePageVisible"].ToString() == "1")
            {
                this.IsHomePageVisible = "1";
            }
            if (this.Session["StoreUserID"] != null && this.Session["StoreUserID"] != null)
            {
                this.UserType = LoginBasePage.UserTypeCheck(Convert.ToInt64(this.Session["StoreUserID"]));
            }
            string str = base.Return_ApprovalRegistration_Settings("deptscreenname");
            if (str != "")
            {
                this.lblDepartment.Text = str;
            }
            else
            {
                this.lblDepartment.Text = this.objLanguage.GetLanguageConversion("Department_Name");
            }
            if (this.Session["ApprovalSystem"] != null)
            {
                if (this.Session["ApprovalSystem"] != null)
                {
                    this.DivApproverEmail.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.approvalType = base.Return_ApprovalSystem_Settings("approvaltype");
                    string str1 = base.Return_ApprovalSystem_Settings("editeduserapprove");
                    if (str1.ToLower().Trim() != "true")
                    {
                        this.DivApproverEmail.Attributes.Add("style", "display:none");
                    }
                    else if ((!(this.approvalType == "u") || !(this.UserType == "u")) && (!(this.approvalType == "u") || !(this.UserType == "m")) && (!(this.approvalType == "u") || !(this.UserType == "d")))
                    {
                        this.DivApproverEmail.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.DivApproverEmail.Attributes.Add("style", "display:block");
                        this.hdnValidation.Value = str1;
                        DataTable dataTable = LoginBasePage.StoreUser_select(this.StoreUserID);
                        if (base.Return_ApprovalSystem_Settings("lastapproverdefault").ToLower() != "false" && !base.IsPostBack && dataTable.Rows.Count > 0)
                        {
                            this.txtApproverEmail.Text = dataTable.Rows[0]["DesignatedApproverEmail"].ToString();
                        }
                    }
                }
            }
            base.Title = commonclass.pageTitle("My Account", Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.AccountID));
            if (!base.IsPostBack)
            {
                foreach (DataRow dataRow in LoginBasePage.StoreUser_select(this.StoreUserID).Rows)
                {
                    this.txt_firstName.Text = base.SpecialDecode(dataRow["FirstName"].ToString());
                    this.txt_lastName.Text = base.SpecialDecode(dataRow["LastName"].ToString());
                    this.txt_email.Text = base.SpecialDecode(dataRow["EmailID"].ToString());
                    this.txt_currentPwd.Attributes.Add("value", dataRow["Password"].ToString());
                    this.hdnPassword.Value = dataRow["Password"].ToString();
                    this.txt_currentPwd.ReadOnly = true;
                    this.txt_CompanyName.Text = base.SpecialDecode(dataRow["CompanyName"].ToString());
                    this.txt_CompanyName.ReadOnly = true;
                    this.txtDepartment.ReadOnly = true;
                }
            }
            if (this.type != "p")
            {
                this.txt_CompanyName.Focus();
            }
            else
            {
                this.txt_newPwd.Focus();
            }
            foreach (DataRow row1 in LoginBasePage.Select_DeptDetail_For_StoreUser(this.AccountID, this.StoreUserID).Rows)
            {
                this.DepartmentID = Convert.ToInt64(row1["DeptID"].ToString());
                if (base.IsPostBack)
                {
                    continue;
                }
                this.txtDepartment.Text = row1["DeptName"].ToString();
            }
        }
    }
}