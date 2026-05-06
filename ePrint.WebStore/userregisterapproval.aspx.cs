using nmsCommon;
using nmsConnection;
using nmsEmail;
using nmsLanguage;
using Printcenter.UI.LoginNew;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.WebStore
{
    public partial class userregisterapproval : BaseClass, IRequiresSessionState
    {

        public string strImagepath = BaseClass.imagePath();

        public long StoreUserID;

        public long ApproverUserID;

        public string strSitepath = string.Empty;

        public string Subject = string.Empty;

        public string EmailBodyUser = string.Empty;

        public int AccountID;

        public long ContactID;

        public int CompanyID;

        public string approvalType = string.Empty;

        public string RequirePassword = string.Empty;

        public string AccountName = string.Empty;

        private storeEmail objEmail = new storeEmail();

        public long RegisterPendingUserID;

        public languageClass objLanguage = new languageClass();

        private BaseClass objBaseClass = new BaseClass();

        public string deptScreenName = string.Empty;

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

        public userregisterapproval()
        {
        }

        protected void btnApproved_Click(object sender, EventArgs e)
        {
            this.Session["PendingMessage"] = "Approved";
            if (this.Session["ApprovalSystem"] != null && this.Session["ApprovalSystem"].ToString() == "on")
            {
                if (this.approvalType != "u")
                {
                    if (this.RequirePassword != "True")
                    {
                        LoginBasePage.Insert_Edit_Address_IsActive(this.RegisterPendingUserID, this.StoreUserID);
                        this.objEmail.B2BRegisterDetails_Email(this.RegisterPendingUserID, this.CompanyID, (long)this.AccountID, "New B2B Contact Registration", "Customer", this.StoreUserID, this.lblEmailAddress.Text.Trim());
                        this.UserDetailPanel.Attributes.Add("style", "display:none;");
                        base.Response.Redirect(string.Concat(this.strSitepath, "approvalpending.aspx?userID=", this.RegisterPendingUserID));
                        this.RadWindow2.Visible = false;
                        return;
                    }
                    if (LoginBasePage.ExistanceOfPassword(this.StoreUserID, this.txtApproverPassword.Text) == (long)0)
                    {
                        this.lblReqiPassword.Visible = true;
                        this.RadWindow2.Visible = false;
                        return;
                    }
                    LoginBasePage.Insert_Edit_Address_IsActive(this.RegisterPendingUserID, this.StoreUserID);
                    this.objEmail.B2BRegisterDetails_Email(this.RegisterPendingUserID, this.CompanyID, (long)this.AccountID, "New B2B Contact Registration", "Customer", this.StoreUserID, this.lblEmailAddress.Text.Trim());
                    this.UserDetailPanel.Attributes.Add("style", "display:none;");
                    base.Response.Redirect(string.Concat(this.strSitepath, "approvalpending.aspx?userID=", this.RegisterPendingUserID));
                    this.RadWindow2.Visible = false;
                    return;
                }
                LoginBasePage.Insert_Edit_Address_IsActive(this.RegisterPendingUserID, (long)0);
                this.objEmail.B2BRegisterDetails_Email(this.RegisterPendingUserID, this.CompanyID, (long)this.AccountID, "New B2B Contact Registration", "Customer", (long)0, this.lblEmailAddress.Text.Trim());
                this.btnApproved.Visible = false;
                this.btnDisapproved.Visible = false;
                this.RadWindow2.Visible = false;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, this.AccountName));
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
            this.Session["PendingMessage"] = "Rejected";
            if (this.Session["ApprovalSystem"] != null && this.Session["ApprovalSystem"].ToString() == "on")
            {
                if (this.approvalType != "u")
                {
                    if (this.RequirePassword != "True")
                    {
                        LoginBasePage.Insert_Edit_Address_RejectReason(this.RegisterPendingUserID, this.txtDisApproved.Text, this.StoreUserID);
                        this.objEmail.B2BRejectsUserDetails_Email(this.RegisterPendingUserID, this.CompanyID, (long)this.AccountID, "B2B New User Rejection", "Customer", this.StoreUserID, this.lblEmailAddress.Text.Trim());
                        this.RadWindow2.Visible = false;
                        this.UserDetailPanel.Attributes.Add("style", "display:none;");
                        base.Response.Redirect(string.Concat(this.strSitepath, "approvalpending.aspx?userID=", this.RegisterPendingUserID));
                        return;
                    }
                    if (LoginBasePage.ExistanceOfPassword(this.StoreUserID, this.txtApproverPassword.Text) == (long)0)
                    {
                        this.lblReqiPassword.Visible = true;
                        return;
                    }
                    LoginBasePage.Insert_Edit_Address_RejectReason(this.RegisterPendingUserID, this.txtDisApproved.Text, this.StoreUserID);
                    this.objEmail.B2BRejectsUserDetails_Email(this.RegisterPendingUserID, this.CompanyID, (long)this.AccountID, "B2B New User Rejection", "Customer", this.StoreUserID, this.lblEmailAddress.Text.Trim());
                    this.RadWindow2.Visible = false;
                    this.UserDetailPanel.Attributes.Add("style", "display:none;");
                    base.Response.Redirect(string.Concat(this.strSitepath, "approvalpending.aspx?userID=", this.RegisterPendingUserID));
                    return;
                }
                LoginBasePage.Insert_Edit_Address_RejectReason(this.RegisterPendingUserID, this.txtDisApproved.Text, (long)0);
                this.objEmail.B2BRejectsUserDetails_Email(this.RegisterPendingUserID, this.CompanyID, (long)this.AccountID, "B2B New User Rejection", "Customer", (long)0, this.lblEmailAddress.Text.Trim());
                this.RadWindow2.Visible = false;
                this.btnApproved.Visible = false;
                this.btnDisapproved.Visible = false;
            }
        }

        public void GetUserDetail()
        {
            foreach (DataRow row in LoginBasePage.Select_UserDetail(this.RegisterPendingUserID).Rows)
            {
                this.lblFirstname.Text = base.SpecialDecode(row["FirstName"].ToString());
                this.lbllastName.Text = base.SpecialDecode(row["Lastname"].ToString());
                this.lblMiddleName.Text = base.SpecialDecode(row["MiddleName"].ToString());
                this.lblDepartmentEcho.Text = base.SpecialDecode(row["Department"].ToString());
                this.lblBillAddress1.Text = base.SpecialDecode(row["HomeAddressLine1"].ToString());
                this.lblBillAddress2.Text = base.SpecialDecode(row["HomeAddressLine2"].ToString());
                this.lblAddress3.Text = base.SpecialDecode(row["HomeAddressLine3"].ToString());
                this.lblAddress4.Text = base.SpecialDecode(row["HomeAddressLine4"].ToString());
                this.lblAddress5.Text = base.SpecialDecode(row["AddressLine2"].ToString());
                this.lblCountry.Text = base.SpecialDecode(row["HomeCountry"].ToString());
                this.lblTelephone.Text = base.SpecialDecode(row["HomeTelephone"].ToString());
                this.lblFax.Text = base.SpecialDecode(row["Fax"].ToString());
                this.lblEmailAddress.Text = base.SpecialDecode(row["Email"].ToString());
                this.lblPassword.Text = base.SpecialDecode(row["Password"].ToString());
                this.lblApproverEmail.Text = base.SpecialDecode(row["DesignatedApproverEmail"].ToString());
                this.AccountID = Convert.ToInt32(row["AccountID"].ToString());
                this.CompanyID = Convert.ToInt32(row["CompanyID"].ToString());
            }
        }

        protected void lnkGoBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "products/product.aspx?ID=0"));
        }

        public void Logout()
        {
            HttpCookie item = this.Context.Request.Cookies["ResumeSessionID"];
            if (item != null)
            {
                commonclass _commonclass = new commonclass();
                SqlCommand sqlCommand = new SqlCommand("Ws_ResumeSessionStore_delete", _commonclass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add("@ResumeSessionID", item.Value.ToString());
                sqlCommand.ExecuteNonQuery();
                _commonclass.closeConnection();
                base.Request.Cookies.Set(new HttpCookie("ResumeSessionID", ""));
                base.Response.Cookies.Set(new HttpCookie("ResumeSessionID", ""));
            }
            base.Response.Cookies["ResumeSessionID"].Expires = DateTime.Now.AddDays(-1);
            this.Session["StoreUserID"] = "";
            this.Session.Clear();
            this.Session.Abandon();
            GC.Collect();
            base.Response.Redirect(string.Concat(this.strSitepath, "logout.aspx?id=", this.AccountID));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblDis.Text = this.objLanguage.GetLanguageConversion("Reject_Reason");
            this.btnOk.Text = this.objLanguage.GetLanguageConversion("OK");
            Label label = (Label)base.Master.FindControl("lblPathLink");
            string[] sitePath = new string[] { "<a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "approvalpending.aspx' >", this.objLanguage.GetLanguageConversion("Approval_Pending"), "</a><span Class='floatLeft'>&nbsp;>>&nbsp;</span><span>", this.objLanguage.GetLanguageConversion("Approve_User_Registration"), "</span>" };
            label.Text = string.Concat(sitePath);
            this.deptScreenName = this.objBaseClass.Return_ApprovalRegistration_Settings("deptscreenname");
            this.lblDepartment.Text = this.deptScreenName;
            if (ConnectionClass.SitePath != null && ConnectionClass.SitePath != "")
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                this.AccountID = Convert.ToInt32(ConnectionClass.AccountID);
            }
            this.lnkGoBack.Text = this.objLanguage.GetLanguageConversion("Go_Back");
            this.Session["RedirectToUserRegApprovalPage"] = null;
            this.DivApproverPassword.Visible = false;
            if (base.Request.QueryString == null || !(base.Request.QueryString.ToString() != ""))
            {
                this.UserDetailPanel.Visible = false;
                this.tb_IncorrectLink.Visible = true;
                this.lblErrorMsg.Text = this.objLanguage.GetLanguageConversion("IncorrectLink");
                ((Panel)base.Master.FindControl("HeaderPanel")).Visible = false;
                ((Panel)base.Master.FindControl("FooterPanel")).Visible = false;
            }
            else
            {
                string str = Encryption.DecryptQueryString(QueryString.FromCurrent()).ToString();
                ArrayList arrayLists = Encryption.querystrvalue(str);
                if (arrayLists.Count < 4)
                {
                    this.UserDetailPanel.Visible = false;
                    this.tb_IncorrectLink.Visible = true;
                    this.lblErrorMsg.Text = this.objLanguage.GetLanguageConversion("IncorrectLink");
                    ((Panel)base.Master.FindControl("HeaderPanel")).Visible = false;
                    ((Panel)base.Master.FindControl("FooterPanel")).Visible = false;
                }
                else
                {
                    try
                    {
                        this.RegisterPendingUserID = Convert.ToInt64(arrayLists[1]);
                        if (this.AccountID == 0 || this.AccountID == Convert.ToInt32(arrayLists[3]))
                        {
                            this.AccountID = Convert.ToInt32(arrayLists[3]);
                        }
                        else
                        {
                            this.UserDetailPanel.Visible = false;
                            this.tb_IncorrectLink.Visible = true;
                            this.lblErrorMsg.Text = this.objLanguage.GetLanguageConversion("IncorrectLink");
                            ((Panel)base.Master.FindControl("HeaderPanel")).Visible = false;
                            ((Panel)base.Master.FindControl("FooterPanel")).Visible = false;
                            return;
                        }
                    }
                    catch (Exception exception)
                    {
                        this.UserDetailPanel.Visible = false;
                        this.tb_IncorrectLink.Visible = true;
                        this.lblErrorMsg.Text = this.objLanguage.GetLanguageConversion("IncorrectLink");
                        ((Panel)base.Master.FindControl("HeaderPanel")).Visible = false;
                        ((Panel)base.Master.FindControl("FooterPanel")).Visible = false;
                    }
                    DataTable dataTable = LoginBasePage.accounts_getAccountDetails(this.AccountID);
                    if (dataTable.Rows.Count > 0)
                    {
                        this.AccountName = dataTable.Rows[0]["accountName"].ToString();
                    }
                    this.objBaseClass.Assign_ApprovalSystemSettings_ForAccount((long)this.AccountID);
                    if (this.Session["ApprovalSystem"] == null)
                    {
                        this.UserDetailPanel.Visible = false;
                        this.tb_IncorrectLink.Visible = true;
                        this.lblErrorMsg.Text = this.objLanguage.GetLanguageConversion("Approval_Feature_Disabled_Msg");
                        ((Panel)base.Master.FindControl("HeaderPanel")).Visible = false;
                        ((Panel)base.Master.FindControl("FooterPanel")).Visible = false;
                    }
                    else if (this.Session["ApprovalSystem"].ToString() != "on")
                    {
                        this.UserDetailPanel.Visible = false;
                        this.tb_IncorrectLink.Visible = true;
                        this.lblErrorMsg.Text = this.objLanguage.GetLanguageConversion("Approval_Feature_Disabled_Msg");
                        ((Panel)base.Master.FindControl("HeaderPanel")).Visible = false;
                        ((Panel)base.Master.FindControl("FooterPanel")).Visible = false;
                    }
                    else
                    {
                        this.approvalType = this.objBaseClass.Return_ApprovalSystem_Settings("approvaltype");
                        this.RequirePassword = this.objBaseClass.Return_ApprovalSystem_Settings("requirepwd");
                        foreach (DataRow row in LoginBasePage.Get_IsApprovRegistraton_Status(this.RegisterPendingUserID).Rows)
                        {
                            if (row["IsApproved"].ToString().ToLower() == "true" || row["IsUserRejected"].ToString().ToLower() == "true")
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
                        if (this.approvalType == "u")
                        {
                            ((Panel)base.Master.FindControl("HeaderPanel")).Visible = false;
                            ((Panel)base.Master.FindControl("FooterPanel")).Visible = false;
                        }
                        else if (this.approvalType == "a" || this.approvalType == "da")
                        {
                            this.Session["RedirectToUserRegApprovalPage"] = base.Request.Url.ToString();
                            ((Panel)base.Master.FindControl("HeaderPanel")).Visible = true;
                            ((Panel)base.Master.FindControl("FooterPanel")).Visible = true;
                            if (this.Session["StoreUserID"] == null || this.CompanyID == 0 && this.AccountID == 0)
                            {
                                if (this.AccountID == 0)
                                {
                                    base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx"));
                                }
                                else
                                {
                                    base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx?id=", this.AccountID));
                                }
                            }
                            if (this.Session["StoreUserID"] != null)
                            {
                                string empty = string.Empty;
                                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"]);
                                empty = LoginBasePage.UserTypeCheck(this.StoreUserID);
                                if (empty.ToLower() == "u")
                                {
                                    this.Logout();
                                }
                                if (this.approvalType == "a" && empty.ToLower() == "d")
                                {
                                    this.Logout();
                                }
                                if (empty.ToLower() == "d")
                                {
                                    foreach (DataRow dataRow in LoginBasePage.Select_DepartmentID_ApproverUserID((long)this.AccountID, this.RegisterPendingUserID).Rows)
                                    {
                                        this.ApproverUserID = Convert.ToInt64(dataRow["ApproverStoreUserID"]);
                                    }
                                    if (this.StoreUserID != this.ApproverUserID)
                                    {
                                        this.Logout();
                                    }
                                }
                                this.txtApproverPassword.Attributes.Add("onblur", string.Concat("javascript:ValidateExistanceOfPassword(this.value,", this.StoreUserID, ")"));
                            }
                            if (this.RequirePassword == "True")
                            {
                                this.DivApproverPassword.Visible = true;
                            }
                        }
                        this.GetUserDetail();
                    }
                }
            }
            if (this.CompanyID == 0 && this.AccountID == 0)
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx"));
            }
            base.Title = commonclass.pageTitle(this.objLanguage.GetLanguageConversion("Registration_Approval"), Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.AccountID));
        }
    }
}