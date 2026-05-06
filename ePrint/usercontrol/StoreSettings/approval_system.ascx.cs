using nmsLanguage;
using Printcenter.BusinessAccessLayer.ApprovalSystem;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.StoreSettings
{
    public partial class approval_system : UsercontrolBasePage
    {
        public static long CompanyID;

        public static long UserID;

        public static long AccountID;

        public long ApprovalSystemID;

        public long ApprovalRegisterID;

        public long ApprovalOrderID;

        public languageClass objLanguage = new languageClass();

        private SettingsBasePage objSet = new SettingsBasePage();

        public string PendingCount = "0";

        public string AccountType = string.Empty;

        public string firstTab_Click = string.Empty;

        public string secondTab_Click = string.Empty;

        public string thirdTab_Click = string.Empty;

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

        static approval_system()
        {
        }

        public approval_system()
        {
        }

        public void BindApprovalSettings(long UserID, long CompanyID, long AccountID)
        {
            DataSet dataSet = ApprovalSystem.approvalsystemsettings_getDetails(UserID, CompanyID, AccountID);
            DataTable dataTable = ApprovalSystem.PendingApprovalRecordsPerAccount(AccountID);
            if (dataTable.Rows.Count > 0)
            {
                if (dataTable.Rows[0]["count"].ToString() != "1")
                {
                    this.hdnPendCount.Value = "0";
                }
                else
                {
                    this.hdnPendCount.Value = dataTable.Rows[0]["count"].ToString();
                }
            }
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                this.ApprovalSystemID = Convert.ToInt64(row["approvalSystemID"].ToString());
                AccountID = Convert.ToInt64(row["accountID"].ToString());
                this.hdnPreviousApprovalType.Value = row["approvalType"].ToString();
                if (row["IsActive"].ToString().Trim().ToLower() == "true")
                {
                    this.chkAppSys_Enable.Checked = true;
                }
                if (row["approvalType"].ToString().Trim().ToLower() == "u")
                {
                    this.hdnaccordionIndex.Value = "1";
                    this.chkUserDesignatedApp.Checked = true;
                    this.chkUserDesignateOwnApprover.Checked = true;
                    this.divUserDesignatedApprovers.Attributes.Add("style", "display:block");
                    this.chkMainApprove.Checked = false;
                    this.chkMain.Checked = false;
                    this.chkDeptApprove.Checked = false;
                    this.chkMainApprove.Checked = false;
                }
                else if (row["approvalType"].ToString().Trim().ToLower() == "a")
                {
                    this.hdnaccordionIndex.Value = "0";
                    this.chkMain.Checked = true;
                    this.chkMain.Enabled = true;
                    this.chkMainApprove.Checked = true;
                    this.chkUserDesignatedApp.Checked = false;
                    this.chkUserDesignateOwnApprover.Checked = false;
                    this.divUserDesignatedApprovers.Attributes.Add("style", "display:none");
                }
                else if (row["approvalType"].ToString().Trim().ToLower() == "d")
                {
                    this.hdnaccordionIndex.Value = "0";
                    this.chkDeptApprove.Checked = true;
                    this.chkMainApprove.Checked = true;
                    this.chkUserDesignatedApp.Checked = false;
                    this.chkUserDesignateOwnApprover.Checked = false;
                    this.divUserDesignatedApprovers.Attributes.Add("style", "display:none");
                    this.divDeptApprovers.Attributes.Add("style", "display:block");
                }
                else if (row["approvalType"].ToString().Trim().ToLower() == "da")
                {
                    this.hdnaccordionIndex.Value = "0";
                    this.chkMain.Checked = true;
                    this.chkDeptApprove.Checked = true;
                    this.chkMainApprove.Checked = true;
                    this.chkUserDesignatedApp.Checked = false;
                    this.chkUserDesignateOwnApprover.Checked = false;
                    this.divUserDesignatedApprovers.Attributes.Add("style", "display:none");
                    this.divDeptApprovers.Attributes.Add("style", "display:block");
                }
                else if (row["approvalType"].ToString().Trim().ToLower() == "s")
                {
                    this.hdnaccordionIndex.Value = "2";
                    this.chkSelfApproval.Checked = true;
                    if (row["Is_MarkAll_Items_SelfApproval"].ToString().Trim().ToLower() != "true")
                    {
                        this.chkMarkalltheitemsasApproved.Checked = false;
                        ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "__showConfirm", "javascript:ShowMarkalltheitemsasApproved();document.getElementById('ctl00_ContentPlaceHolder1_ApprovalSystem_chkMarkalltheitemsasApproved').checked = false;return", true);
                    }
                    else
                    {
                        this.chkMarkalltheitemsasApproved.Checked = true;
                        ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "__showConfirm", "javascript:ShowMarkalltheitemsasApproved();return", true);
                    }
                    this.chkMain.Checked = false;
                    this.chkDeptApprove.Checked = false;
                    this.chkMainApprove.Checked = false;
                    this.chkUserDesignatedApp.Checked = false;
                    this.chkUserDesignateOwnApprover.Checked = false;
                    this.divUserDesignatedApprovers.Attributes.Add("style", "display:none");
                    this.divDeptApprovers.Attributes.Add("style", "display:none");
                }
                if (row["reapproval"].ToString().ToLower() != "true")
                {
                    this.chkRepprovalByMainApp.Checked = false;
                }
                else
                {
                    this.chkRepprovalByMainApp.Checked = true;
                }
                if (row["requirePwd"].ToString().ToLower() != "true")
                {
                    this.chkRequirePWD.Checked = false;
                }
                else
                {
                    this.chkRequirePWD.Checked = true;
                }
                if (row["approverEmail"].ToString() == "")
                {
                    this.chkDAEmailAddEndsWith.Checked = false;
                }
                else
                {
                    this.chkDAEmailAddEndsWith.Checked = true;
                    this.chkUserDesignateOwnApprover.Checked = true;
                    this.divUserDesignatedApprovers.Attributes.Add("style", "display:block");
                    this.txtEmailEndsWith.Text = row["approverEmail"].ToString();
                }
                if (row["lastApproverDefault"].ToString().ToLower() != "true")
                {
                    this.chkLastDADefault.Checked = false;
                }
                else
                {
                    this.chkLastDADefault.Checked = true;
                    this.chkUserDesignateOwnApprover.Checked = true;
                    this.divUserDesignatedApprovers.Attributes.Add("style", "display:block");
                }
                if (row["newOrdersApprove"].ToString().ToLower() != "true")
                {
                    this.chkNewOrderApproval.Checked = false;
                    this.hdnNewOrderReqApproval_History.Value = "0";
                }
                else
                {
                    this.chkNewOrderApproval.Checked = true;
                    this.divNewOrdersReqApproval.Attributes.Add("style", "display:block");
                    this.hdnNewOrderReqApproval_History.Value = "1";
                }
                if (row["newUserApprove"].ToString().ToLower() != "true")
                {
                    this.chkNewProfileApproval.Checked = false;
                    this.hdnRegReqApproval_History.Value = "0";
                }
                else
                {
                    this.chkNewProfileApproval.Checked = true;
                    this.hdnRegReqApproval_History.Value = "1";
                    this.divNewProfilesReqApproval.Attributes.Add("style", "display:block");
                }
                if (row["editedUserApprove"].ToString().ToLower() != "true")
                {
                    this.chkEditProfileApproval.Checked = false;
                    this.hdnEditProfileReqApproval_History.Value = "0";
                }
                else
                {
                    this.chkEditProfileApproval.Checked = true;
                    this.hdnEditProfileReqApproval_History.Value = "1";
                }
                if (row["approvalReqForOrder"].ToString() != "0")
                {
                    this.txtOrderForValues.Text = row["approvalReqForOrder"].ToString();
                }
                if (row["orderResendApproval"].ToString() != "0")
                {
                    this.txtOrdResendApproval.Text = row["orderResendApproval"].ToString();
                }
                if (row["orderAutoDelete"].ToString() != "0")
                {
                    this.txtDeleteOrders.Text = row["orderAutoDelete"].ToString();
                }
                if (row["orderAutoChangeStatus"].ToString() != "0")
                {
                    this.txtAutoChangesStatus.Text = row["orderAutoChangeStatus"].ToString();
                }
                if (row["Status_ID"].ToString() != "0")
                {
                    this.ddl_Status.SelectedValue = row["Status_ID"].ToString();
                }
                if (row["orderInformAdmin"].ToString() != "0")
                {
                    this.txtOrdInformAdmin.Text = row["orderInformAdmin"].ToString();
                }
                if (row["regResendApproval"].ToString() != "0")
                {
                    this.txtProResendApproval.Text = row["regResendApproval"].ToString();
                }
                if (row["regAutoReject"].ToString() != "0")
                {
                    this.txtProDeleteOrders.Text = row["regAutoReject"].ToString();
                }
                if (row["regInformAdmin"].ToString() == "0")
                {
                    continue;
                }
                this.txtProInformAdmin.Text = row["regInformAdmin"].ToString();
            }
            if (dataSet.Tables[0].Rows.Count == 0)
            {
                this.chkNewOrderApproval.Checked = true;
                this.divNewOrdersReqApproval.Attributes.Add("style", "display:block");
            }
            foreach (DataRow dataRow in dataSet.Tables[1].Rows)
            {
                this.txtAutoEmail.Text = dataRow["ApprovedEmailAddress"].ToString();
            }
        }

        public void BindStatusDropdown()
        {
            this.objSet.Bind_Status_new(this.ddl_Status, Convert.ToInt32(approval_system.CompanyID), string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"), "webstoreorder");
        }

        protected void btnRevert_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }

        protected void btnSaveSettings_Click(object sender, EventArgs e)
        {
            string pendingCount = this.PendingCount;
            if (this.chkAppSys_Enable.Checked)
            {
                this.PendingCount = "0";
            }
            if (this.PendingCount != "0")
            {
                if (this.PendingCount == "1")
                {
                    this.chkAppSys_Enable.Checked = true;
                    //ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "__showConfirm", "javascript:alert('You are not authorised to switch off since you have some pending Orders/Edit Profiles/Users which are need to be approved');", true);
                    ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "__showConfirm", "javascript:alert('You are not able to turn off the approval system as there are approvals pending for orders, users, or user profiles.');", true);
                }
                return;
            }
            ApprovalSystemItems approvalSystemItem = new ApprovalSystemItems();
            if (this.hdnMainApprove.Value == "1")
            {
                this.chkMainApprove.Checked = true;
            }
            else if (this.hdnUserDesignatedApp.Value == "1")
            {
                this.chkUserDesignatedApp.Checked = true;
            }
            else if (this.hdnchkMarkalltheitemsasApproved.Value == "1")
            {
                this.chkMarkalltheitemsasApproved.Checked = true;
            }
            if (this.chkMainApprove.Checked)
            {
                if (this.chkMain.Checked)
                {
                    approvalSystemItem.approvalType = "a";
                }
                else if (this.hdnchkmain.Value == "1")
                {
                    approvalSystemItem.approvalType = "a";
                }
                if (this.chkDeptApprove.Checked)
                {
                    approvalSystemItem.approvalType = "da";
                    if (this.chkRepprovalByMainApp.Checked)
                    {
                        approvalSystemItem.reapproval = true;
                    }
                }
                else if (this.hdnDeptApprove.Value == "1")
                {
                    approvalSystemItem.approvalType = "da";
                    if (this.hdnRepprovalByMainApp.Value == "1")
                    {
                        approvalSystemItem.reapproval = true;
                    }
                }
                if (this.chkMain.Checked && this.chkDeptApprove.Checked)
                {
                    approvalSystemItem.approvalType = "da";
                }
                else if (this.hdnDeptApprove.Value == "1" && this.hdnchkmain.Value == "1")
                {
                    approvalSystemItem.approvalType = "da";
                }
                if (this.chkRequirePWD.Checked)
                {
                    approvalSystemItem.requirePwd = true;
                }
                else if (this.hdnRequirePWD.Value == "1")
                {
                    approvalSystemItem.requirePwd = true;
                }
            }
            else if (this.chkUserDesignatedApp.Checked)
            {
                approvalSystemItem.approvalType = "u";
                if (this.chkUserDesignateOwnApprover.Checked)
                {
                    if (this.chkDAEmailAddEndsWith.Checked)
                    {
                        approvalSystemItem.approverEmail = this.txtEmailEndsWith.Text;
                    }
                    if (this.chkLastDADefault.Checked)
                    {
                        approvalSystemItem.lastApproverDefault = true;
                    }
                }
                else if (this.hdnUserDesignateOwnApprover.Value == "1")
                {
                    if (this.hdnDAEmailAddEndsWith.Value == "1")
                    {
                        approvalSystemItem.approverEmail = this.hdntxtEmailEndsWith.Value;
                    }
                    if (this.hdnLastDADefault.Value == "1")
                    {
                        approvalSystemItem.lastApproverDefault = true;
                    }
                }
            }
            else if (this.chkSelfApproval.Checked)
            {
                approvalSystemItem.approvalType = "s";
                if (this.chkMarkalltheitemsasApproved.Checked)
                {
                    approvalSystemItem.MarkalltheitemsasApproved = true;
                }
                else if (this.hdnchkMarkalltheitemsasApproved.Value == "1")
                {
                    approvalSystemItem.MarkalltheitemsasApproved = true;
                }
            }
            if (this.hdnNewOrderApproval.Value == "1")
            {
                this.chkNewOrderApproval.Checked = true;
            }
            if (this.chkNewOrderApproval.Checked)
            {
                approvalSystemItem.newOrdersApprove = true;
                if (this.txtOrderForValues.Text != "" && this.txtOrderForValues.Text != null)
                {
                    approvalSystemItem.approvalReqForOrder = Convert.ToInt32(this.txtOrderForValues.Text);
                }
                else if (this.hdntxtOrderForValues.Value != "" && this.hdntxtOrderForValues.Value != null)
                {
                    approvalSystemItem.approvalReqForOrder = Convert.ToInt32(this.hdntxtOrderForValues.Value);
                }
                if (this.txtOrdResendApproval.Text != "" && this.txtOrdResendApproval.Text != null)
                {
                    approvalSystemItem.orderResendApproval = Convert.ToInt32(this.txtOrdResendApproval.Text);
                }
                else if (this.hdntxtOrdResendApproval.Value != "" && this.hdntxtOrdResendApproval.Value != null)
                {
                    approvalSystemItem.orderResendApproval = Convert.ToInt32(this.hdntxtOrdResendApproval.Value);
                }
                if (this.txtDeleteOrders.Text != "" && this.txtDeleteOrders.Text != null)
                {
                    approvalSystemItem.orderAutoDelete = Convert.ToInt32(this.txtDeleteOrders.Text);
                }
                else if (this.hdntxtDeleteOrders.Value != "" && this.hdntxtDeleteOrders.Value != null)
                {
                    approvalSystemItem.orderAutoDelete = Convert.ToInt32(this.hdntxtDeleteOrders.Value);
                }
                if (this.txtAutoChangesStatus.Text != "" && this.txtAutoChangesStatus.Text != null)
                {
                    approvalSystemItem.orderAutoChangeStatus = Convert.ToInt32(this.txtAutoChangesStatus.Text);
                }
                else if (this.hdntxtAutoChangesStatus.Value != "" && this.hdntxtAutoChangesStatus.Value != null)
                {
                    approvalSystemItem.orderAutoChangeStatus = Convert.ToInt32(this.hdntxtAutoChangesStatus.Value);
                }
                if (this.ddl_Status.SelectedItem.Value != "0")
                {
                    approvalSystemItem.StatusID = Convert.ToInt64(this.ddl_Status.SelectedItem.Value);
                }
                else if (!(this.hdnddlstatus.Value != "0") || !(this.hdnddlstatus.Value != ""))
                {
                    approvalSystemItem.StatusID = (long)0;
                }
                else
                {
                    approvalSystemItem.StatusID = Convert.ToInt64(this.hdnddlstatus.Value);
                }
                if (this.txtOrdInformAdmin.Text != "" && this.txtOrdInformAdmin.Text != null)
                {
                    approvalSystemItem.orderInformAdmin = Convert.ToInt32(this.txtOrdInformAdmin.Text);
                }
                else if (this.hdntxtOrdInformAdmin.Value != "" && this.hdntxtOrdInformAdmin.Value != null)
                {
                    approvalSystemItem.orderInformAdmin = Convert.ToInt32(this.hdntxtOrdInformAdmin.Value);
                }
            }
            if (this.hdnEditProfileApproval.Value == "1")
            {
                this.chkEditProfileApproval.Checked = true;
            }
            if (this.chkEditProfileApproval.Checked)
            {
                approvalSystemItem.editedUserApprove = true;
            }
            if (this.hdnNewProfileApproval.Value == "1")
            {
                this.chkNewProfileApproval.Checked = true;
            }
            if (this.chkNewProfileApproval.Checked)
            {
                approvalSystemItem.newUserApprove = true;
                if (this.txtProResendApproval.Text != "" && this.txtProResendApproval.Text != null)
                {
                    approvalSystemItem.regResendApproval = Convert.ToInt32(this.txtProResendApproval.Text);
                }
                else if (this.hdntxtProResendApproval.Value != "" && this.hdntxtProResendApproval.Value != null)
                {
                    approvalSystemItem.regResendApproval = Convert.ToInt32(this.hdntxtProResendApproval.Value);
                }
                if (this.txtProDeleteOrders.Text != "" && this.txtProDeleteOrders.Text != null)
                {
                    approvalSystemItem.regAutoReject = Convert.ToInt32(this.txtProDeleteOrders.Text);
                }
                else if (this.hdntxtProDeleteOrders.Value != "" && this.hdntxtProDeleteOrders.Value != null)
                {
                    approvalSystemItem.regAutoReject = Convert.ToInt32(this.hdntxtProDeleteOrders.Value);
                }
                if (this.txtProInformAdmin.Text != "" && this.txtProInformAdmin.Text != null)
                {
                    approvalSystemItem.regInformAdmin = Convert.ToInt32(this.txtProInformAdmin.Text);
                }
                else if (this.hdntxtProInformAdmin.Value != "" && this.hdntxtProInformAdmin.Value != null)
                {
                    approvalSystemItem.regInformAdmin = Convert.ToInt32(this.hdntxtProInformAdmin.Value);
                }
            }
            approvalSystemItem.accountID = approval_system.AccountID;
            approvalSystemItem.createdBy = approval_system.UserID;
            approvalSystemItem.companyID = approval_system.CompanyID;
            approvalSystemItem.createdOn = DateTime.Now;
            approvalSystemItem.approvedEmailAddress = this.txtAutoEmail.Text;
            if (this.hdnNewProfileApproval.Value == "1" && this.hdntxtAutoEmail.Value != "")
            {
                approvalSystemItem.approvedEmailAddress = this.hdntxtAutoEmail.Value;
            }
            DataSet dataSet = ApprovalSystem.approvalsystemsettings_getDetails(approval_system.UserID, approval_system.CompanyID, approval_system.AccountID);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                this.ApprovalSystemID = Convert.ToInt64(dataSet.Tables[0].Rows[0]["approvalSystemID"].ToString());
            }
            if (dataSet.Tables[1].Rows.Count > 0)
            {
                this.ApprovalRegisterID = Convert.ToInt64(dataSet.Tables[1].Rows[0]["ApprovalRegisterID"].ToString());
            }
            if (dataSet.Tables[2].Rows.Count > 0)
            {
                this.ApprovalOrderID = Convert.ToInt64(dataSet.Tables[2].Rows[0]["ApprovalOrderID"].ToString());
            }
            approvalSystemItem.approvalSystemID = this.ApprovalSystemID;
            if (pendingCount == "1" && this.hdnPreviousApprovalType.Value != approvalSystemItem.approvalType)
            {
                ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "__showConfirm", "javascript:RevertType();", true);
                return;
            }
            if (ApprovalSystem.approvalsystemsettings_AddOrEdit(approvalSystemItem) != 2)
            {
                this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Added_successfully"), "msg-success", this.plhMessageNew);
            }
            else
            {
                this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Updated_Successfully"), "msg-success", this.plhMessageNew);
            }
            if (!this.chkAppSys_Enable.Checked)
            {
                this.objSet.DisableApprovalSystem(approval_system.AccountID);
                this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Updated_Successfully"), "msg-success", this.plhMessageNew);
            }
            this.BindApprovalSettings(approval_system.UserID, approval_system.CompanyID, approval_system.AccountID);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnSaveSettings.Text = this.objLanguage.GetLanguageConversion("Save");
            if (base.Session["UserID"].ToString() != null)
            {
                approval_system.UserID = Convert.ToInt64(base.Session["UserID"].ToString());
            }
            if (base.Session["CompanyID"].ToString() != null)
            {
                approval_system.CompanyID = Convert.ToInt64(base.Session["CompanyID"].ToString());
            }
            string str = SettingsBasePage.Fetch_SelectedAccountID(approval_system.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                approval_system.AccountID = (long)Convert.ToInt32(strArrays[0]);
            }
            if (approval_system.AccountID != (long)0)
            {
                this.AccountType = WebstoreBasePage.SelectAccountType(Convert.ToInt32(approval_system.AccountID));
                if (this.AccountType.ToLower() == "x")
                {
                    approval_system.AccountID = (long)0;
                }
            }
            if (this.chkDeptApprove.Checked)
            {
                this.chkMain.Checked = true;
            }
            if (!base.IsPostBack && this.AccountType.ToLower() != "x")
            {
                this.BindApprovalSettings(approval_system.UserID, approval_system.CompanyID, approval_system.AccountID);
                this.BindStatusDropdown();
            }
            this.PendingCount = this.hdnPendCount.Value;
        }
    }
}