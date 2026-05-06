using nmsCommon;
using nmsConnectionClass;
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
    public partial class Registration_Option : UsercontrolBasePage
    {
        public static long CompanyID;

        public static long UserID;

        public static long AccountID;

        public long ApprovalSystemID;

        public long ApprovalRegisterID;

        public long ApprovalOrderID;

        public languageClass objLanguage = new languageClass();

        private SettingsBasePage objSet = new SettingsBasePage();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        public string AccountType = string.Empty;

        public string strImagepath = global.imagePath();

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

        static Registration_Option()
        {
        }

        public Registration_Option()
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
            if (dataSet.Tables[3].Rows.Count > 0)
            {
                this.ddlDefaultDept.DataSource = dataSet.Tables[3];
                this.ddlDefaultDept.DataTextField = "DeptName";
                this.ddlDefaultDept.DataValueField = "DeptID";
                this.ddlDefaultDept.DataBind();
            }
            foreach (DataRow row in dataSet.Tables[1].Rows)
            {
                if (row["userDeptType"].ToString() == "L")
                {
                    this.rdoDeptList.Checked = true;
                    this.divDefaultDept.Style.Add("display", "none");
                }
                else if (row["userDeptType"].ToString() == "D")
                {
                    this.rdoDeptDefault.Checked = true;
                    this.divDefaultDept.Style.Add("display", "block");
                    if (row["DepartmentID"].ToString() != "")
                    {
                        this.ddlDefaultDept.SelectedValue = row["DepartmentID"].ToString();
                    }
                }
                if (row["AddNewDept"].ToString() == "True")
                {
                    this.chkAllowAddDept.Checked = true;
                }
                if (row["PrefilAdded"].ToString() == "True")
                {
                    this.rdoPrefilcontact.Checked = true;
                }
                if (row["OverwriteAdded"].ToString() == "True")
                {
                    this.RdoAllowuser.Checked = true;
                }
                if (row["IsSelfRegister"].ToString() != "True")
                {
                    this.chkIsselfregister.Checked = false;
                }
                else
                {
                    this.chkIsselfregister.Checked = true;
                }
                if (row["DeptScreenName"].ToString() != "")
                {
                    this.txtDepartmentLabel.Text = row["DeptScreenName"].ToString();
                }
                if (row["IsSingleField"].ToString() == "True")
                {
                    this.chkSingleField.Checked = true;
                }
                this.txtRegisterEmail.Text = row["RegisterEmailAddress"].ToString();
            }
        }

        protected void btnSaveSettings_Click(object sender, EventArgs e)
        {
            ApprovalSystemItems approvalSystemItem = new ApprovalSystemItems()
            {
                accountID = Registration_Option.AccountID,
                createdBy = Registration_Option.UserID,
                companyID = Registration_Option.CompanyID,
                createdOn = DateTime.Now
            };
            if (this.rdoDeptList.Checked)
            {
                approvalSystemItem.userDeptType = "L";
                approvalSystemItem.DepartmentID = 0;
            }
            else if (this.rdoDeptDefault.Checked)
            {
                approvalSystemItem.userDeptType = "D";
                if (this.ddlDefaultDept.SelectedValue != null || this.ddlDefaultDept.SelectedValue != "")
                {
                    approvalSystemItem.DepartmentID = Convert.ToInt32(this.ddlDefaultDept.SelectedValue);
                }
            }
            if (this.chkAllowAddDept.Checked)
            {
                approvalSystemItem.AddNewDept = true;
            }
            if (this.rdoPrefilcontact.Checked)
            {
                approvalSystemItem.PrefilAdded = 1;
            }
            if (this.RdoAllowuser.Checked)
            {
                approvalSystemItem.OverwriteAdded = 1;
            }
            if (!this.chkIsselfregister.Checked)
            {
                approvalSystemItem.isSelfReg = 0;
            }
            if (this.chkSingleField.Checked)
            {
                approvalSystemItem.SingleField = true;
            }
            approvalSystemItem.registerEmailAddress = this.txtRegisterEmail.Text;
            approvalSystemItem.DeptScreenName = this.txtDepartmentLabel.Text;
            DataSet dataSet = ApprovalSystem.approvalsystemsettings_getDetails(Registration_Option.UserID, Registration_Option.CompanyID, Registration_Option.AccountID);
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
            approvalSystemItem.ApprovalRegisterID = this.ApprovalRegisterID;
            if (ApprovalSystem.ApprovalRegistration_AddOrEdit(approvalSystemItem) != 2)
            {
                this.objBase.Message_Display("Added successfully", "msg-success", this.plhMessageNew);
            }
            else
            {
                this.objBase.Message_Display("Updated successfully", "msg-success", this.plhMessageNew);
            }
            this.BindApprovalSettings(Registration_Option.UserID, Registration_Option.CompanyID, Registration_Option.AccountID);
            base.Response.Redirect(base.Request.Url.ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnSaveSettings.Text = this.objLanguage.GetLanguageConversion("Save");
            this.lblDepartmentLabel.Text = this.objLanguage.GetLanguageConversion("Department_screen_name");
            if (base.Session["UserID"].ToString() != null)
            {
                Registration_Option.UserID = Convert.ToInt64(base.Session["UserID"].ToString());
            }
            if (base.Session["CompanyID"].ToString() != null)
            {
                Registration_Option.CompanyID = Convert.ToInt64(base.Session["CompanyID"].ToString());
            }
            string str = SettingsBasePage.Fetch_SelectedAccountID(Registration_Option.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                Registration_Option.AccountID = (long)Convert.ToInt32(strArrays[0]);
            }
            if (Registration_Option.AccountID != (long)0)
            {
                this.AccountType = WebstoreBasePage.SelectAccountType(Convert.ToInt32(Registration_Option.AccountID));
                if (this.AccountType.ToLower() == "x")
                {
                    Registration_Option.AccountID = (long)0;
                }
            }
            if (!base.IsPostBack)
            {
                this.BindApprovalSettings(Registration_Option.UserID, Registration_Option.CompanyID, Registration_Option.AccountID);
            }
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "javascript:EnableDisable();", true);
        }
    }
}