using nmsCommon;
using nmsConnection;
using nmsEmail;
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
using Telerik.Web.UI;

namespace ePrint.WebStore
{
    public partial class userprofileapproval : BaseClass, IRequiresSessionState
    {

        public string strImagepath = BaseClass.imagePath();

        public long StoreUserID;

        public long AddressID;

        public long AccountID;

        public long ContactID;

        public long CompanyID;

        public long ApproverUserID;

        public string Subject = string.Empty;

        public string approvalType = string.Empty;

        public string RequirePassword = string.Empty;

        public string strSitepath = string.Empty;

        public string EmailBodyUser = string.Empty;

        public string AccountName = string.Empty;

        public string ProfileEditType = string.Empty;

        private storeEmail objEmail = new storeEmail();

        public bool DefaultShip;

        public bool DefaultBill;

        public long Client_ID;

        public long user_ID;

        public languageClass objLanguage = new languageClass();

        public string deptScreenName = string.Empty;

        public string pwd = string.Empty;

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

        public userprofileapproval()
        {
        }

        protected void btnApproved_Click(object sender, EventArgs e)
        {
            long num = (long)0;
            if (this.Session["ApprovalSystem"] != null && this.Session["ApprovalSystem"].ToString() == "on")
            {
                this.RequirePassword = (new BaseClass()).Return_ApprovalSystem_Settings("requirepwd");
                if (this.approvalType != "u")
                {
                    if (this.RequirePassword != "True")
                    {
                        if (this.ProfileEditType.ToString().ToLower() != "p")
                        {
                            LoginBasePage.Update_Address_Detail(this.AddressID, this.lblBillAddress2.Text, this.lblHomeAddress.Text, this.lblFax.Text, this.lblTelephone.Text, this.lblCountry.Text, this.lblAddress4.Text, this.lblBillAddress2.Text, this.lblBillAddress1.Text, this.lblAddress5.Text, Convert.ToInt64(this.Session["RegisterPendingUserID"].ToString()), this.StoreUserID, this.DefaultShip, this.DefaultBill, this.Client_ID, base.SpecialEncode(this.lblApproverEmail.Text));
                        }
                        else
                        {
                            LoginBasePage.Update_Login_Detail(Convert.ToInt64(this.Session["RegisterPendingUserID"].ToString()), this.lblFirstname.Text, this.lbllastName.Text, this.lblEmailAddress.Text, this.pwd, this.StoreUserID, base.SpecialEncode(this.lblApproverEmail.Text));
                        }
                        this.objEmail.B2BProfileApprovalDetails_Email(Convert.ToInt64(this.Session["RegisterPendingUserID"].ToString()), Convert.ToInt32(this.CompanyID), this.AccountID, "B2B User Profile Modified Approved", "Customer", this.StoreUserID, this.lblEmailAddress.Text);
                        LoginBasePage.Delete_Address_FromTempTable_ForApproval(Convert.ToInt64(this.Session["RegisterPendingUserID"].ToString()));
                        this.UserDetailPanel.Attributes.Add("style", "display:none;");
                        base.Response.Redirect(string.Concat(this.strSitepath, "approvalpending.aspx?userID=", this.Session["RegisterPendingUserID"].ToString()));
                        this.RadWindow2.Visible = false;
                        return;
                    }
                    if (LoginBasePage.ExistanceOfPassword(this.StoreUserID, this.txtApproverPassword.Text) == (long)0)
                    {
                        this.lblReqiPassword.Visible = true;
                        this.RadWindow2.Visible = false;
                        return;
                    }
                    if (this.ProfileEditType.ToString().ToLower() != "p")
                    {
                        LoginBasePage.Update_Address_Detail(this.AddressID, this.lblBillAddress2.Text, this.lblHomeAddress.Text, this.lblFax.Text, this.lblTelephone.Text, this.lblCountry.Text, this.lblAddress4.Text, this.lblBillAddress2.Text, this.lblBillAddress1.Text, this.lblAddress5.Text, Convert.ToInt64(this.Session["RegisterPendingUserID"].ToString()), this.StoreUserID, this.DefaultShip, this.DefaultBill, this.Client_ID, base.SpecialEncode(this.lblApproverEmail.Text));
                    }
                    else
                    {
                        LoginBasePage.Update_Login_Detail(Convert.ToInt64(this.Session["RegisterPendingUserID"].ToString()), this.lblFirstname.Text, this.lbllastName.Text, this.lblEmailAddress.Text, this.pwd, this.StoreUserID, base.SpecialEncode(this.lblApproverEmail.Text));
                    }
                    this.objEmail.B2BProfileApprovalDetails_Email(Convert.ToInt64(this.Session["RegisterPendingUserID"].ToString()), Convert.ToInt32(this.CompanyID), this.AccountID, "B2B User Profile Modified Approved", "Customer", this.StoreUserID, this.lblEmailAddress.Text);
                    LoginBasePage.Delete_Address_FromTempTable_ForApproval(Convert.ToInt64(this.Session["RegisterPendingUserID"].ToString()));
                    this.UserDetailPanel.Attributes.Add("style", "display:none;");
                    base.Response.Redirect(string.Concat(this.strSitepath, "approvalpending.aspx?userID=", this.Session["RegisterPendingUserID"].ToString()));
                    this.RadWindow2.Visible = false;
                    return;
                }
                if (this.ProfileEditType.ToString().ToLower() != "p")
                {
                    LoginBasePage.Update_Address_Detail(this.AddressID, this.lblBillAddress2.Text, this.lblHomeAddress.Text, this.lblFax.Text, this.lblTelephone.Text, this.lblCountry.Text, this.lblAddress4.Text, this.lblBillAddress2.Text, this.lblBillAddress1.Text, this.lblAddress5.Text, Convert.ToInt64(this.Session["RegisterPendingUserID"].ToString()), (long)0, this.DefaultShip, this.DefaultBill, this.Client_ID, base.SpecialEncode(this.lblApproverEmail.Text));
                }
                else
                {
                    LoginBasePage.Update_Login_Detail(Convert.ToInt64(this.Session["RegisterPendingUserID"].ToString()), this.lblFirstname.Text, this.lbllastName.Text, this.lblEmailAddress.Text, this.pwd, (long)0, base.SpecialEncode(this.lblApproverEmail.Text));
                }
                this.objEmail.B2BProfileApprovalDetails_Email(Convert.ToInt64(this.Session["RegisterPendingUserID"].ToString()), Convert.ToInt32(this.CompanyID), this.AccountID, "B2B User Profile Modified Approved", "Customer", (long)0, this.lblEmailAddress.Text);
                LoginBasePage.Delete_Address_FromTempTable_ForApproval(Convert.ToInt64(this.Session["RegisterPendingUserID"].ToString()));
                this.RadWindow2.Visible = false;
                this.btnApproved.Visible = false;
                this.btnDisapproved.Visible = false;
            }
        }

        protected void btnDisapproved_Click(object sender, EventArgs e)
        {
            this.RadWindow2.Visible = false;
            this.lblReqiPassword.Visible = false;
            if (this.Session["ApprovalSystem"] != null && this.Session["ApprovalSystem"].ToString() == "on")
            {
                if (this.approvalType != "u")
                {
                    if (this.RequirePassword != "True")
                    {
                        this.RadWindow2.Visible = true;
                        return;
                    }
                    if (LoginBasePage.ExistanceOfPassword(this.StoreUserID, this.txtApproverPassword.Text) == (long)0)
                    {
                        this.lblReqiPassword.Visible = true;
                        return;
                    }
                    this.txtDisApproved.Text = "";
                    this.RadWindow2.Visible = true;
                    return;
                }
                this.RadWindow2.Visible = true;
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (this.Session["ApprovalSystem"] != null && this.Session["ApprovalSystem"].ToString() == "on")
            {
                this.RequirePassword = (new BaseClass()).Return_ApprovalSystem_Settings("requirepwd");
                if (this.approvalType != "u")
                {
                    if (this.RequirePassword != "True")
                    {
                        LoginBasePage.Insert_Edit_Address_RejectReason_For_Approval(Convert.ToInt64(this.Session["RegisterPendingUserID"].ToString()), this.txtDisApproved.Text, this.StoreUserID);
                        this.objEmail.B2BProfileApprovalDetails_Email(Convert.ToInt64(this.Session["RegisterPendingUserID"].ToString()), Convert.ToInt32(this.CompanyID), this.AccountID, "B2B User Profile Modified Rejected", "Customer", this.StoreUserID, this.lblEmailAddress.Text);
                        this.RadWindow2.Visible = false;
                        this.UserDetailPanel.Attributes.Add("style", "display:none;");
                        base.Response.Redirect(string.Concat(this.strSitepath, "approvalpending.aspx?userID=", this.Session["RegisterPendingUserID"].ToString()));
                        return;
                    }
                    if (LoginBasePage.ExistanceOfPassword(this.StoreUserID, this.txtApproverPassword.Text) == (long)0)
                    {
                        this.lblReqiPassword.Visible = true;
                        return;
                    }
                    LoginBasePage.Insert_Edit_Address_RejectReason_For_Approval(Convert.ToInt64(this.Session["RegisterPendingUserID"].ToString()), this.txtDisApproved.Text, this.StoreUserID);
                    this.objEmail.B2BProfileApprovalDetails_Email(Convert.ToInt64(this.Session["RegisterPendingUserID"].ToString()), Convert.ToInt32(this.CompanyID), this.AccountID, "B2B User Profile Modified Rejected", "Customer", this.StoreUserID, this.lblEmailAddress.Text);
                    this.RadWindow2.Visible = false;
                    this.UserDetailPanel.Attributes.Add("style", "display:none;");
                    base.Response.Redirect(string.Concat(this.strSitepath, "approvalpending.aspx?userID=", this.Session["RegisterPendingUserID"].ToString()));
                    return;
                }
                LoginBasePage.Insert_Edit_Address_RejectReason_For_Approval(Convert.ToInt64(this.Session["RegisterPendingUserID"].ToString()), this.txtDisApproved.Text, (long)0);
                this.objEmail.B2BProfileApprovalDetails_Email(Convert.ToInt64(this.Session["RegisterPendingUserID"].ToString()), Convert.ToInt32(this.CompanyID), this.AccountID, "B2B User Profile Modified Rejected", "Customer", (long)0, this.lblEmailAddress.Text);
                this.RadWindow2.Visible = false;
                this.btnApproved.Visible = false;
                this.btnDisapproved.Visible = false;
            }
        }

        public void GetUserDetail_ForApproval()
        {
            try
            {
                DataTable dataTable = LoginBasePage.Select_UserDetail_For_Approval(Convert.ToInt64(this.Session["RegisterPendingUserID"].ToString()));
                foreach (DataRow row in dataTable.Rows)
                {
                    this.AddressID = Convert.ToInt64(row["AddressID"].ToString());
                    this.lblApproverEmail.Text = base.SpecialDecode(row["DesignatedApprovedEmail"].ToString());
                    this.AccountID = Convert.ToInt64(row["AccountID"].ToString());
                    this.ProfileEditType = row["PersonalProfileEditType"].ToString();
                    this.CompanyID = Convert.ToInt64(row["CompanyID"].ToString());
                    this.pwd = base.SpecialDecode(row["Password"].ToString());
                    string str = new string('*', row["Password"].ToString().Length);
                    if (this.ProfileEditType.ToString().ToLower() == "p")
                    {
                        this.lblFirstname.Text = base.SpecialDecode(row["FirstName"].ToString());
                        this.lbllastName.Text = base.SpecialDecode(row["Lastname"].ToString());
                        this.lblPassword.Text = str;
                        this.lblEmailAddress.Text = base.SpecialDecode(row["EmailID"].ToString());
                        this.lblHomeAddress.Text = base.SpecialDecode(row["AddressLabel"].ToString());
                    }
                    if (this.ProfileEditType.ToString().ToLower() != "a")
                    {
                        continue;
                    }
                    this.lblFax.Text = base.SpecialDecode(row["Fax"].ToString());
                    this.lblTelephone.Text = base.SpecialDecode(row["Telephone"].ToString());
                    this.lblCountry.Text = base.SpecialDecode(row["Country"].ToString());
                    this.lblBillAddress1.Text = base.SpecialDecode(row["Address1"].ToString());
                    this.lblBillAddress2.Text = base.SpecialDecode(row["Address2"].ToString());
                    this.lblAddress3.Text = base.SpecialDecode(row["Address3"].ToString());
                    this.lblAddress4.Text = base.SpecialDecode(row["Address4"].ToString());
                    this.lblAddress5.Text = base.SpecialDecode(row["Address5"].ToString());
                    this.DefaultBill = Convert.ToBoolean(row["IsDefaultBilling"].ToString());
                    this.DefaultShip = Convert.ToBoolean(row["IsDefaultShipping"].ToString());
                    this.Client_ID = Convert.ToInt64(row["ClientID"].ToString());
                    this.lblEmailAddress.Text = base.SpecialDecode(row["EmailID"].ToString());
                }
            }
            catch
            {
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblDis.Text = this.objLanguage.GetLanguageConversion("Reject_Reason");
            this.btnOk.Text = this.objLanguage.GetLanguageConversion("OK");
            BaseClass baseClass = new BaseClass();
            this.deptScreenName = baseClass.Return_ApprovalRegistration_Settings("deptscreenname");
            if (this.deptScreenName != "")
            {
                this.lblDepartment.Text = string.Concat(this.deptScreenName, " Echo");
            }
            ((Label)base.Master.FindControl("lblPathLink")).Text = string.Concat("<a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "userprofileapproval.aspx' ></a>User Profile Approval");
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt64(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                this.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            this.txtDisApproved.Focus();
            this.Session["RedirectToProfModApprovalPage"] = null;
            try
            {
                if (base.Request.QueryString == null || !(base.Request.QueryString.ToString() != ""))
                {
                    if (this.Session["StoreUserID"] != null)
                    {
                        this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
                    }
                    ((Panel)base.Master.FindControl("HeaderPanel")).Visible = true;
                    ((Panel)base.Master.FindControl("FooterPanel")).Visible = true;
                }
                else
                {
                    string str = Encryption.DecryptQueryString(QueryString.FromCurrent()).ToString();
                    ArrayList arrayLists = Encryption.querystrvalue(str);
                    this.user_ID = Convert.ToInt64(arrayLists[1].ToString());
                    long num = Convert.ToInt64(arrayLists[3].ToString());
                    this.AccountID = num;
                    baseClass.Assign_ApprovalSystemSettings_ForAccount(this.AccountID);
                    this.approvalType = baseClass.Return_ApprovalSystem_Settings("approvaltype");
                    if (this.approvalType == "u")
                    {
                        this.Session["RegisterPendingUserID"] = this.user_ID;
                        ((Panel)base.Master.FindControl("HeaderPanel")).Visible = false;
                        ((Panel)base.Master.FindControl("FooterPanel")).Visible = false;
                        foreach (DataRow row in OrderBasePage.Get_IsApprovalProfile(this.StoreUserID).Rows)
                        {
                            if (row["IsApproved"].ToString().ToLower() == "true" || row["Rejected"].ToString().ToLower() == "true")
                            {
                                this.btnApproved.Visible = false;
                                this.btnDisapproved.Visible = false;
                            }
                            else
                            {
                                this.btnApproved.Visible = true;
                                this.btnDisapproved.Visible = true;
                            }
                        }
                    }
                    else if (this.approvalType == "a" || this.approvalType == "da")
                    {
                        DataTable dataTable = LoginBasePage.accounts_getAccountDetails(Convert.ToInt32(this.AccountID));
                        if (dataTable.Rows.Count > 0)
                        {
                            this.AccountName = dataTable.Rows[0]["accountName"].ToString();
                        }
                        this.Session["RegisterPendingUserID"] = this.user_ID;
                        string str1 = base.Request.Url.ToString().Substring(0, base.Request.Url.ToString().IndexOf('?'));
                        this.Session["RedirectToProfModApprovalPage"] = str1;
                    }
                }
            }
            catch
            {
            }
            if (this.Session["StoreUserID"] == null || this.CompanyID == (long)0 && this.AccountID == (long)0)
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx"));
            }
            this.GetUserDetail_ForApproval();
            this.txtApproverPassword.Attributes.Add("onblur", string.Concat("javascript:ValidateExistanceOfPassword(this.value,", this.StoreUserID, ")"));
            if (this.Session["ApprovalSystem"] != null)
            {
                if (this.Session["ApprovalSystem"].ToString() != "on")
                {
                    this.DivApproverPassword.Visible = false;
                }
                else
                {
                    this.approvalType = baseClass.Return_ApprovalSystem_Settings("approvaltype");
                    this.RequirePassword = baseClass.Return_ApprovalSystem_Settings("requirepwd");
                    if (this.approvalType == "u")
                    {
                        this.DivApproverPassword.Visible = false;
                    }
                    else if (this.RequirePassword != "True")
                    {
                        this.DivApproverPassword.Visible = false;
                    }
                    else
                    {
                        this.DivApproverPassword.Visible = true;
                    }
                }
            }
            base.Title = commonclass.pageTitle("Profile Approval", Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.AccountID));
        }
    }
}