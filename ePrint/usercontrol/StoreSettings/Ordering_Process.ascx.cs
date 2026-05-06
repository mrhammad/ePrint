using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.BusinessAccessLayer.ApprovalSystem;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using Sample.Web.UI.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.FileExplorer;

namespace ePrint.usercontrol.StoreSettings
{
    public partial class Ordering_Process : UsercontrolBasePage
    {
        public static long CompanyID;

        public static long UserID;

        public static long AccountID;

        public long ApprovalSystemID;

        public long ApprovalRegisterID;

        public long ApprovalOrderID;

        public languageClass objLanguage = new languageClass();

        public string ApprovalSystemStatus = string.Empty;

        private SettingsBasePage objSet = new SettingsBasePage();

        public string ProductStockManagement = string.Empty;

        public string ServerName = ConnectionClass.ServerName;

        public string SecureVirtualPath = global.SecureVirtualPath();

        protected string strImagepath = global.imagePath();

        public bool ReplenishBoolVal = true;

        public string strSitepath = global.sitePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string AccountType = string.Empty;

        private BaseClass objBase = new BaseClass();

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

        static Ordering_Process()
        {
        }

        public Ordering_Process()
        {
        }

        public void Assign_ApprovalSystemSettings_ForAccount(long AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_ApprovalSystemSettings_select");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            dataSet = database.ExecuteDataSet(storedProcCommand);
            if (dataSet.Tables[3].Rows.Count <= 0)
            {
                this.ApprovalSystemStatus = "off";
                return;
            }
            if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[3].Rows[0]["IsApprovalFeaturesOn"].ToString().ToLower() == "true")
            {
                this.ApprovalSystemStatus = "on";
                return;
            }
            this.ApprovalSystemStatus = "off";
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
            foreach (DataRow row in dataSet.Tables[2].Rows)
            {
                if (row["allow_order_behalf_users_app"].ToString() == "Y")
                {
                    this.chkAllUserMain.Checked = true;
                }
                else if (row["allow_order_behalf_users_app"].ToString() != "O")
                {
                    this.chkAllUserMain.Checked = false;
                }
                else
                {
                    this.chkDeptMain.Checked = true;
                }
                if (row["allow_order_behalf_users_dept"].ToString() == "Y")
                {
                    this.chkAllUserDept.Checked = true;
                }
                else if (row["allow_order_behalf_users_dept"].ToString() != "O")
                {
                    this.chkAllUserDept.Checked = false;
                }
                else
                {
                    this.chkDept.Checked = true;
                }
                if (row["allow_order_behalf_users_user"].ToString() == "Y")
                {
                    this.chkAllUserUser.Checked = true;
                }
                else if (row["allow_order_behalf_users_user"].ToString() != "O")
                {
                    this.chkAllUserUser.Checked = false;
                }
                else
                {
                    this.chkDeptUser.Checked = true;
                }
                if (row["allow_order_behalf_depts_app"].ToString() == "N")
                {
                    this.chkAllMain_dept.Checked = false;
                    this.chkBelongMain_dept.Checked = false;
                }
                else if (row["allow_order_behalf_depts_app"].ToString() == "A")
                {
                    this.chkAllMain_dept.Checked = true;
                    this.chkBelongMain_dept.Checked = false;
                }
                else if (row["allow_order_behalf_depts_app"].ToString() == "O")
                {
                    this.chkBelongMain_dept.Checked = true;
                    this.chkAllMain_dept.Checked = false;
                }
                if (row["allow_order_behalf_depts_dept"].ToString() == "N")
                {
                    this.chkAllDept_dept.Checked = false;
                    this.chkBelongDept_dept.Checked = false;
                }
                else if (row["allow_order_behalf_depts_dept"].ToString() == "A")
                {
                    this.chkAllDept_dept.Checked = true;
                    this.chkBelongDept_dept.Checked = false;
                }
                else if (row["allow_order_behalf_depts_dept"].ToString() == "O")
                {
                    this.chkBelongDept_dept.Checked = true;
                    this.chkAllDept_dept.Checked = false;
                }
                if (row["allow_order_behalf_depts_user"].ToString() == "N")
                {
                    this.chkAllUser_dept.Checked = false;
                    this.chkBelongUser_dept.Checked = false;
                }
                else if (row["allow_order_behalf_depts_user"].ToString() == "A")
                {
                    this.chkAllUser_dept.Checked = true;
                    this.chkBelongUser_dept.Checked = false;
                }
                else if (row["allow_order_behalf_depts_user"].ToString() == "O")
                {
                    this.chkBelongUser_dept.Checked = true;
                    this.chkAllUser_dept.Checked = false;
                }
                if (row["allow_order_behalf_users_app"].ToString() == "N")
                {
                    this.chkAllUserMain.Checked = false;
                    this.chkDeptMain.Checked = false;
                }
                else if (row["allow_order_behalf_users_app"].ToString() == "Y")
                {
                    this.chkAllUserMain.Checked = true;
                    this.chkDeptMain.Checked = false;
                }
                else if (row["allow_order_behalf_users_app"].ToString() == "O")
                {
                    this.chkDeptMain.Checked = true;
                    this.chkAllUserMain.Checked = false;
                }
                if (row["allow_order_behalf_users_dept"].ToString() == "N")
                {
                    this.chkAllUserDept.Checked = false;
                    this.chkDept.Checked = false;
                }
                else if (row["allow_order_behalf_users_dept"].ToString() == "Y")
                {
                    this.chkAllUserDept.Checked = true;
                    this.chkDept.Checked = false;
                }
                else if (row["allow_order_behalf_users_dept"].ToString() == "O")
                {
                    this.chkDept.Checked = true;
                    this.chkAllUserDept.Checked = false;
                }
                if (row["allow_order_behalf_users_user"].ToString() == "N")
                {
                    this.chkAllUserUser.Checked = false;
                    this.chkDeptUser.Checked = false;
                }
                else if (row["allow_order_behalf_users_user"].ToString() == "Y")
                {
                    this.chkAllUserUser.Checked = true;
                    this.chkDeptUser.Checked = false;
                }
                else if (row["allow_order_behalf_users_user"].ToString() == "O")
                {
                    this.chkDeptUser.Checked = true;
                    this.chkAllUserUser.Checked = false;
                }
                if (this.ProductStockManagement.ToLower() == "true")
                {
                    if (row["ShowStockReplenish"].ToString().ToLower() == "a")
                    {
                        this.chkenablestkreplenished.Checked = true;
                        this.Chk_Users.Checked = true;
                        this.Chk_Main.Checked = true;
                        this.Chk_Dept.Checked = true;
                    }
                    else if (row["ShowStockReplenish"].ToString().ToLower() == "d")
                    {
                        this.chkenablestkreplenished.Checked = true;
                        this.Chk_Dept.Checked = true;
                        this.Chk_Users.Checked = false;
                        this.Chk_Main.Checked = true;
                    }
                    else if (row["ShowStockReplenish"].ToString().ToLower() == "m")
                    {
                        this.chkenablestkreplenished.Checked = true;
                        this.Chk_Main.Checked = true;
                        this.Chk_Users.Checked = false;
                        this.Chk_Dept.Checked = false;
                    }
                    else if (row["ShowStockReplenish"].ToString().ToLower() == "n")
                    {
                        this.chkenablestkreplenished.Checked = false;
                        this.Chk_Dept.Checked = false;
                        this.Chk_Users.Checked = false;
                        this.Chk_Main.Checked = false;
                        this.Chk_Dept.Enabled = false;
                        this.Chk_Users.Enabled = false;
                        this.Chk_Main.Enabled = false;
                    }
                }
                this.chkCostCenter.Checked = Convert.ToBoolean(row["ShowCostCenters"].ToString());
                if ((!(row["allow_order_behalf_users_app"].ToString() != "N") || !(row["allow_order_behalf_users_app"].ToString() != "")) && (!(row["allow_order_behalf_users_dept"].ToString() != "N") || !(row["allow_order_behalf_users_dept"].ToString() != "")) && (!(row["allow_order_behalf_users_user"].ToString() != "N") || !(row["allow_order_behalf_users_user"].ToString() != "")))
                {
                    this.chkUserOrderingProcess.Checked = false;
                }
                else if (!(row["allow_order_behalf_users_app"].ToString() != "O") || !(row["allow_order_behalf_users_dept"].ToString() != "O") || !(row["allow_order_behalf_users_user"].ToString() != "O"))
                {
                    this.chkUserOrderingProcess.Checked = true;
                    this.chkAllowOrder.Checked = true;
                    this.divUserOrderingProcess.Style.Add("display", "block");
                    this.divAllowOrderBehalf.Style.Add("display", "block");
                    this.rdoUser.Checked = true;
                    this.chkDeptMain.Enabled = true;
                    this.chkDept.Enabled = true;
                    this.chkDeptUser.Enabled = true;
                    this.chkAllUserMain.Enabled = false;
                    this.chkAllUserDept.Enabled = false;
                    this.chkAllUserUser.Enabled = false;
                }
                else
                {
                    this.chkUserOrderingProcess.Checked = true;
                    this.chkAllowOrder.Checked = true;
                    this.divUserOrderingProcess.Style.Add("display", "block");
                    this.divAllowOrderBehalf.Style.Add("display", "block");
                    this.rdoAllUsers.Checked = true;
                    this.chkAllUserMain.Enabled = true;
                    this.chkAllUserDept.Enabled = true;
                    this.chkAllUserUser.Enabled = true;
                    this.chkDeptMain.Enabled = false;
                    this.chkDept.Enabled = false;
                    this.chkDeptUser.Enabled = false;
                }
                if ((!(row["allow_order_behalf_depts_app"].ToString() != "N") || !(row["allow_order_behalf_depts_app"].ToString() != "")) && (!(row["allow_order_behalf_depts_dept"].ToString() != "N") || !(row["allow_order_behalf_depts_dept"].ToString() != "")) && (!(row["allow_order_behalf_depts_user"].ToString() != "N") || !(row["allow_order_behalf_depts_user"].ToString() != "")))
                {
                    this.chkDeptOrderingProcess.Checked = false;
                }
                else if (!(row["allow_order_behalf_depts_app"].ToString() != "O") || !(row["allow_order_behalf_depts_dept"].ToString() != "O") || !(row["allow_order_behalf_depts_user"].ToString() != "O"))
                {
                    this.chkDeptOrderingProcess.Checked = true;
                    this.chkAllowOrder.Checked = true;
                    this.divDeptOrderingProcess.Style.Add("display", "block");
                    this.divAllowOrderBehalf.Style.Add("display", "block");
                    this.rdoBelong_Dept.Checked = true;
                    this.chkBelongMain_dept.Enabled = true;
                    this.chkBelongDept_dept.Enabled = true;
                    this.chkBelongUser_dept.Enabled = true;
                    this.chkAllMain_dept.Enabled = false;
                    this.chkAllDept_dept.Enabled = false;
                    this.chkAllUser_dept.Enabled = false;
                }
                else
                {
                    this.chkDeptOrderingProcess.Checked = true;
                    this.chkAllowOrder.Checked = true;
                    this.divDeptOrderingProcess.Style.Add("display", "block");
                    this.divAllowOrderBehalf.Style.Add("display", "block");
                    this.rdoAll_Dept.Checked = true;
                    this.chkBelongMain_dept.Enabled = false;
                    this.chkBelongDept_dept.Enabled = false;
                    this.chkBelongUser_dept.Enabled = false;
                    this.chkAllMain_dept.Enabled = true;
                    this.chkAllDept_dept.Enabled = true;
                    this.chkAllUser_dept.Enabled = true;
                }
                if ((row["allow_order_behalf_depts_app"].ToString() != "N" || row["allow_order_behalf_depts_dept"].ToString() != "N" || row["allow_order_behalf_depts_user"].ToString() != "N" || row["allow_order_behalf_users_app"].ToString() != "N" || row["allow_order_behalf_users_dept"].ToString() != "N" || row["allow_order_behalf_users_user"].ToString() != "N") && row["allow_order_behalf_depts_app"].ToString() != "" && row["allow_order_behalf_depts_dept"].ToString() != "" && row["allow_order_behalf_depts_user"].ToString() != "" && row["allow_order_behalf_users_app"].ToString() != "" && row["allow_order_behalf_users_dept"].ToString() != "" && row["allow_order_behalf_users_user"].ToString() != "")
                {
                    this.chkAllowOrder.Checked = true;
                    this.divAllowOrderBehalf.Style.Add("display", "block");
                }
                else
                {
                    this.chkAllowOrder.Checked = false;
                }
                if (row["users_select_addresses_app"].ToString() != "Y")
                {
                    this.chkSelectAdrs_Main.Checked = false;
                }
                else
                {
                    this.chkSelectAdrs_Main.Checked = true;
                }
                if (row["users_select_Department_address_MainApp"].ToString().Trim() != "Y")
                {
                    this.Chk_SeeDeptAddress_MainAppr.Checked = false;
                }
                else
                {
                    this.Chk_SeeDeptAddress_MainAppr.Checked = true;
                }
                if (row["users_select_Department_address_DeptApp"].ToString().Trim() != "Y")
                {
                    this.Chk_SeeDeptAddress_DeptAppr.Checked = false;
                }
                else
                {
                    this.Chk_SeeDeptAddress_DeptAppr.Checked = true;
                }
                if (row["users_select_Department_address_AllUser"].ToString().Trim() != "Y")
                {
                    this.Chk_SeeDeptAddress_AllUser.Checked = false;
                }
                else
                {
                    this.Chk_SeeDeptAddress_AllUser.Checked = true;
                }
                if (row["users_select_addresses_dept"].ToString() != "Y")
                {
                    this.chkSelectAdrs_Dept.Checked = false;
                }
                else
                {
                    this.chkSelectAdrs_Dept.Checked = true;
                }
                if (row["users_select_addresses_user"].ToString() != "Y")
                {
                    this.chkSelectAdrs_User.Checked = false;
                }
                else
                {
                    this.chkSelectAdrs_User.Checked = true;
                }
                if (row["users_add_addresses_app"].ToString() != "Y")
                {
                    this.chkAdd_EditAddress_Main.Checked = false;
                }
                else
                {
                    this.chkAdd_EditAddress_Main.Checked = true;
                }
                if (row["users_add_addresses_dept"].ToString() != "Y")
                {
                    this.chkAdd_EditAddress_Dept.Checked = false;
                }
                else
                {
                    this.chkAdd_EditAddress_Dept.Checked = true;
                }
                if (row["users_add_addresses_user"].ToString() != "Y")
                {
                    this.chkAdd_EditAddress_User.Checked = false;
                }
                else
                {
                    this.chkAdd_EditAddress_User.Checked = true;
                }
                // save new address
                if (row["users_new_add_addresses_app"].ToString() != "Y")
                {
                    this.chkAdd_Address_Main.Checked = false;
                }
                else
                {
                    this.chkAdd_Address_Main.Checked = true;
                }
                if (row["users_new_add_addresses_dept"].ToString() != "Y")
                {
                    this.chkAdd_Address_Dept.Checked = false;
                }
                else
                {
                    this.chkAdd_Address_Dept.Checked = true;
                }
                if (row["users_new_add_addresses_user"].ToString() != "Y")
                {
                    this.chkAdd_Address_User.Checked = false;
                }
                else
                {
                    this.chkAdd_Address_User.Checked = true;
                }

                if (row["users_AddNew_address_NotSaved_MainApp"].ToString().Trim() != "Y")
                {
                    this.chkAddNewAdd_NotSave_Main.Checked = false;
                }
                else
                {
                    this.chkAddNewAdd_NotSave_Main.Checked = true;
                }
                if (row["users_AddNew_address_NotSaved_DeptApp"].ToString().Trim() != "Y")
                {
                    this.chkAddNewAdd_NotSave_Dept.Checked = false;
                }
                else
                {
                    this.chkAddNewAdd_NotSave_Dept.Checked = true;
                }
                if (row["users_AddNew_address_NotSaved_AllUser"].ToString().Trim() != "Y")
                {
                    this.chkAddNewAdd_NotSave_User.Checked = false;
                }
                else
                {
                    this.chkAddNewAdd_NotSave_User.Checked = true;
                }

                //if (row["AttachConNumToUrl"] != null && Convert.ToBoolean(row["AttachConNumToUrl"]) != true)
                //{
                //    this.chkAttachConNumToUrl.Checked = false;
                //}
                //else
                //{
                //    this.chkAttachConNumToUrl.Checked = true;
                //}

                if (this.Chk_SeeDeptAddress_MainAppr.Checked || this.Chk_SeeDeptAddress_DeptAppr.Checked || this.Chk_SeeDeptAddress_AllUser.Checked)
                {
                    this.Rdb_UserSeeOnlyDeptAddrees.Checked = true;
                    this.chkSelectAdrs_Main.Enabled = false;
                    this.chkSelectAdrs_Dept.Enabled = false;
                    this.chkSelectAdrs_User.Enabled = false;
                }
                else
                {
                    this.Rdb_UserSeeOnlyDeptAddrees.Checked = false;
                    this.chkSelectAdrs_Main.Enabled = true;
                    this.chkSelectAdrs_Dept.Enabled = true;
                    this.chkSelectAdrs_User.Enabled = true;
                }
                if (this.chkSelectAdrs_Main.Checked || this.chkSelectAdrs_Dept.Checked || this.chkSelectAdrs_User.Checked)
                {
                    this.Rdb_UserSeeCompAddrees.Checked = true;
                    this.Chk_SeeDeptAddress_MainAppr.Enabled = false;
                    this.Chk_SeeDeptAddress_DeptAppr.Enabled = false;
                    this.Chk_SeeDeptAddress_AllUser.Enabled = false;
                }
                else
                {
                    this.Rdb_UserSeeCompAddrees.Checked = false;
                    this.Chk_SeeDeptAddress_MainAppr.Enabled = true;
                    this.Chk_SeeDeptAddress_DeptAppr.Enabled = true;
                    this.Chk_SeeDeptAddress_AllUser.Enabled = true;
                }
                if (this.Chk_SeeDeptAddress_MainAppr.Checked || this.Chk_SeeDeptAddress_DeptAppr.Checked || this.Chk_SeeDeptAddress_AllUser.Checked || this.chkSelectAdrs_Main.Checked || this.chkSelectAdrs_Dept.Checked || this.chkSelectAdrs_User.Checked)
                {
                    this.Chk_AllowUser_to_vie_changAddress.Checked = true;
                }
                else
                {
                    this.Chk_AllowUser_to_vie_changAddress.Checked = false;
                }
                if (this.chkAdd_EditAddress_Main.Checked || this.chkAdd_EditAddress_Dept.Checked || this.chkAdd_EditAddress_User.Checked)
                {
                    this.chkAdd_EditAddress.Checked = true;
                }
                // save new address
                if (this.chkAdd_Address_Main.Checked || this.chkAdd_Address_Dept.Checked || this.chkAdd_Address_User.Checked)
                {
                    this.chkAdd_Address.Checked = true;
                }

                else
                {
                    this.chkAdd_Address.Checked = false;
                }
                if (this.chkAddNewAdd_NotSave_Main.Checked || this.chkAddNewAdd_NotSave_Dept.Checked || this.chkAddNewAdd_NotSave_User.Checked)
                {
                    this.chkSelectAddress.Checked = true;
                }
                else
                {
                    this.chkSelectAddress.Checked = false;
                }
            }
            DataTable dataTable1 = SettingsBasePage.settings_OrderingProcess_select(Convert.ToInt32(CompanyID), Convert.ToInt32(AccountID));
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                this.txt_OrdTit_Screen.Text = dataRow["OrderTitleText"].ToString();
                this.txt_OrdNum_Screen.Text = dataRow["OrderNumberText"].ToString();
                this.txt_DelReq_Screen.Text = dataRow["DeliveryRequiredByText"].ToString();
                this.txt_Comments_Screen.Text = dataRow["CommentsText"].ToString();
                this.txt_costcenter_screen.Text = dataRow["CostCentreText"].ToString();
                this.txtEstimateDelivery.Value = dataRow["DefaultEstimatedDelivery"].ToString();
                this.objBase.SetDDLValue(this.ddlWorkingdaysFrom, dataRow["WorkingDaysFrom"].ToString());
                this.objBase.SetDDLValue(this.ddlWorkingDaysTo, dataRow["WorkingDaysTo"].ToString());
                if (dataRow["isCheckOrderInfoPublic"].ToString().ToLower() != "true")
                {
                    this.chk_EnableOrder.Checked = false;
                }
                else
                {
                    this.chk_EnableOrder.Checked = true;
                }

                if (dataRow["isDisplayDates"].ToString().ToLower() != "true")
                {
                    this.chkShowDates.Checked = false;
                }
                else
                {
                    this.chkShowDates.Checked = true;
                }

                if (dataRow["isCheckAddressInfo"].ToString().ToLower() != "true")
                {
                    this.Chk_EnableAddress.Checked = false;
                }
                else
                {
                    this.Chk_EnableAddress.Checked = true;
                }
                if (dataRow["isCheckOrderTitle"].ToString().ToLower() != "true")
                {
                    this.chk_OrdTit_Show.Checked = false;
                    this.chk_OrdTit_Req.Enabled = false;
                    this.chk_OrdTit_Req.Checked = false;
                }
                else
                {
                    this.chk_OrdTit_Show.Checked = true;
                    this.chk_OrdTit_Req.Enabled = true;
                }
                if (dataRow["isCheckOrderNumber"].ToString().ToLower() != "true")
                {
                    this.chk_OrdNum_Show.Checked = false;
                    this.chk_OrdNum_Req.Enabled = false;
                    this.chk_OrdNum_Req.Checked = false;
                }
                else
                {
                    this.chk_OrdNum_Show.Checked = true;
                    this.chk_OrdNum_Req.Enabled = true;
                }
                if (dataRow["isCheckDeliveryRequiredBy"].ToString().ToLower() != "true")
                {
                    this.chk_DelReq_Show.Checked = false;
                    this.chk_DelReq_Req.Enabled = false;
                    this.chk_DelReq_Req.Checked = false;
                }
                else
                {
                    this.chk_DelReq_Show.Checked = true;
                    this.chk_DelReq_Req.Enabled = true;
                }
                if (dataRow["isCheckCooments"].ToString().ToLower() != "true")
                {
                    this.chek_Comments_Show.Checked = false;
                    this.chk_Comments_Req.Enabled = false;
                    this.chk_Comments_Req.Checked = false;
                }
                else
                {
                    this.chek_Comments_Show.Checked = true;
                    this.chk_Comments_Req.Enabled = true;
                }
                if (!this.chkCostCenter.Checked)
                {
                    this.chkCostCenter.Checked = false;
                    this.chkCostCenter_Req.Enabled = false;
                    this.chkCostCenter_Req.Checked = false;
                }
                else
                {
                    this.chkCostCenter.Checked = true;
                    this.chkCostCenter_Req.Enabled = true;
                }
                if (dataRow["IsCheckOrderTitleMandatory"].ToString().ToLower() != "true")
                {
                    this.chk_OrdTit_Req.Checked = false;
                }
                else
                {
                    this.chk_OrdTit_Req.Enabled = true;
                    this.chk_OrdTit_Req.Checked = true;
                }
                if (dataRow["isCheckOrderNumberMandatory"].ToString().ToLower() != "true")
                {
                    this.chk_OrdNum_Req.Checked = false;
                }
                else
                {
                    this.chk_OrdNum_Req.Enabled = true;
                    this.chk_OrdNum_Req.Checked = true;
                }
                if (dataRow["isCheckDeliveryRequiredByMandatory"].ToString().ToLower() != "true")
                {
                    this.chk_DelReq_Req.Checked = false;
                }
                else
                {
                    this.chk_DelReq_Req.Enabled = true;
                    this.chk_DelReq_Req.Checked = true;
                }
                if (dataRow["isCheckCoomentsMandatory"].ToString().ToLower() != "true")
                {
                    this.chk_Comments_Req.Checked = false;
                }
                else
                {
                    this.chk_Comments_Req.Enabled = true;
                    this.chk_Comments_Req.Checked = true;
                }
                if (dataRow["IsCheckCostCentreMandatory"].ToString().ToLower() != "true")
                {
                    this.chkCostCenter_Req.Checked = false;
                }
                else
                {
                    this.chkCostCenter_Req.Enabled = true;
                    this.chkCostCenter_Req.Checked = true;
                }
                if (dataRow["is_DeliveryAddress_Mandatory"].ToString().ToLower() != "true")
                {
                    this.Chk_Mandotory_Del.Checked = false;
                }
                else
                {
                    this.Chk_Mandotory_Del.Enabled = true;
                    this.Chk_Mandotory_Del.Checked = true;
                }
                if (dataRow["is_InvoiceAddress_Mandatory"].ToString().ToLower() != "true")
                {
                    this.chk_Mandotory_Inv.Checked = false;
                }
                else
                {
                    this.chk_Mandotory_Inv.Enabled = true;
                    this.chk_Mandotory_Inv.Checked = true;
                }
                if (dataRow["isCheckInvoiceInfo"].ToString().ToLower() != "true")
                {
                    this.Chk_Display_Inv.Checked = false;
                    this.chk_Mandotory_Inv.Enabled = false;
                }
                else
                {
                    this.Chk_Display_Inv.Checked = true;
                    if (this.AccountType != null && (this.AccountType.ToLower() == "p" || this.AccountType.ToLower() == "x"))
                    {
                        this.chk_Mandotory_Inv.Enabled = true;
                    }
                }
                if (dataRow["isCheckDeliveryInfo"].ToString().ToLower() != "true")
                {
                    this.Chk_Display_Del.Checked = false;
                    this.Chk_Mandotory_Del.Enabled = false;
                }
                else
                {
                    this.Chk_Display_Del.Checked = true;
                    if (this.AccountType == null || !(this.AccountType.ToLower() == "p") && !(this.AccountType.ToLower() == "x"))
                    {
                        continue;
                    }
                    this.Chk_Mandotory_Del.Enabled = true;
                }

                foreach (ListItem item in chkColumnsList.Items)
                {
                    string columnName = item.Value;
                    if (dataRow[columnName] != DBNull.Value)
                    {
                        item.Selected = Convert.ToBoolean(dataRow[columnName]);
                    }
                }

                ddlFilterDateRange.SelectedIndex = 0;
                ddlFilterDateType.SelectedIndex = 0;

                // Set selected value if exists in DB
                if (dataRow["FilterDateRange"] != DBNull.Value && !string.IsNullOrEmpty(dataRow["FilterDateRange"].ToString()))
                {
                    ListItem item = ddlFilterDateRange.Items.FindByValue(dataRow["FilterDateRange"].ToString());
                    if (item != null)
                        ddlFilterDateRange.SelectedValue = item.Value;
                }

                if (dataRow["FilterDateType"] != DBNull.Value && !string.IsNullOrEmpty(dataRow["FilterDateType"].ToString()))
                {
                    ListItem item = ddlFilterDateType.Items.FindByValue(dataRow["FilterDateType"].ToString());
                    if (item != null)
                        ddlFilterDateType.SelectedValue = item.Value;
                }

            }
            if (this.AccountType != null && this.AccountType.ToLower() != "x")
            {
                ScriptManager.RegisterStartupScript(this, base.GetType(), "_enabledisable", ";replenishcheck_onpageload();", true);
            }
            if (!this.chkDeptOrderingProcess.Checked)
            {
                this.divDeptOrderingProcess123.Style.Add("display", "block");
                this.divDeptOrderingProcess123.Attributes.Add("class", "DivBackColor");
            }
            else
            {
                this.divDeptOrderingProcess123.Style.Add("display", "none");
            }
            if (!this.chkUserOrderingProcess.Checked)
            {
                this.divUserOrderingProcess123.Style.Add("display", "block");
                this.divUserOrderingProcess123.Attributes.Add("class", "DivBackColor");
            }
            else
            {
                this.divUserOrderingProcess123.Style.Add("display", "none");
            }
            if (!this.chkAllowOrder.Checked)
            {
                this.divAllowOrderBehalf123.Style.Add("display", "block");
                this.divAllowOrderBehalf123.Attributes.Add("class", "DivBackColor");
            }
            else
            {
                this.divAllowOrderBehalf123.Style.Add("display", "none");
            }
            if (this.chkSelectAddress.Checked)
            {
                this.chkAdd_EditAddress.Enabled = false;
                this.chkAdd_EditAddress_Main.Enabled = false;
                this.chkAdd_EditAddress_Dept.Enabled = false;
                this.chkAdd_EditAddress_User.Enabled = false;

                this.chkAdd_Address.Enabled = false;
                this.chkAdd_Address_Main.Enabled = false;
                this.chkAdd_Address_Dept.Enabled = false;
                this.chkAdd_Address_User.Enabled = false;

                this.chkSelectAddress.Enabled = true;
                this.chkAddNewAdd_NotSave_Main.Enabled = true;
                this.chkAddNewAdd_NotSave_Dept.Enabled = true;
                this.chkAddNewAdd_NotSave_User.Enabled = true;
            }
            if (this.chkAdd_EditAddress.Checked)
            {
                this.chkSelectAddress.Enabled = false;
                this.chkAddNewAdd_NotSave_Main.Enabled = false;
                this.chkAddNewAdd_NotSave_Dept.Enabled = false;
                this.chkAddNewAdd_NotSave_User.Enabled = false;
                this.chkAdd_EditAddress.Enabled = true;
                this.chkAdd_EditAddress_Main.Enabled = true;
                this.chkAdd_EditAddress_Dept.Enabled = true;
                this.chkAdd_EditAddress_User.Enabled = true;

                this.chkAdd_Address.Enabled = true;
                this.chkAdd_Address_Main.Enabled = true;
                this.chkAdd_Address_Dept.Enabled = true;
                this.chkAdd_Address_User.Enabled = true;
            }
        }

        protected void btnSaveSettings_Click(object sender, EventArgs e)
        {
            ApprovalSystemItems approvalSystemItem = new ApprovalSystemItems()
            {
                ShowCostCentre = this.chkCostCenter.Checked,
                accountID = Ordering_Process.AccountID,
                createdBy = Ordering_Process.UserID,
                companyID = Ordering_Process.CompanyID,
                createdOn = DateTime.Now
            };
            if (this.ApprovalSystemStatus == "off")
            {
                if (!this.Chk_AllowUser_to_vie_changAddress.Checked)
                {
                    approvalSystemItem.users_change_addresses_app = "N";
                    approvalSystemItem.users_change_addresses_dept = "N";
                    approvalSystemItem.users_change_addresses_user = "N";
                }
                else
                {
                    approvalSystemItem.users_change_addresses_app = "Y";
                    approvalSystemItem.users_change_addresses_dept = "Y";
                    approvalSystemItem.users_change_addresses_user = "Y";
                }
                if (!this.chkSelectAddress.Checked)
                {
                    approvalSystemItem.users_select_addresses_app = "N";
                    approvalSystemItem.users_select_addresses_dept = "N";
                    approvalSystemItem.users_select_addresses_user = "N";
                }
                else
                {
                    approvalSystemItem.users_select_addresses_app = "Y";
                    approvalSystemItem.users_select_addresses_dept = "Y";
                    approvalSystemItem.users_select_addresses_user = "Y";
                }
                if (!this.chkAdd_EditAddress.Checked)
                {
                    approvalSystemItem.users_edit_addresses_app = "N";
                    approvalSystemItem.users_edit_addresses_dept = "N";
                    approvalSystemItem.users_edit_addresses_user = "N";
                    approvalSystemItem.users_add_addresses_app = "N";
                    approvalSystemItem.users_add_addresses_dept = "N";
                    approvalSystemItem.users_add_addresses_user = "N";
                }
                else
                {
                    approvalSystemItem.users_edit_addresses_app = "Y";
                    approvalSystemItem.users_edit_addresses_dept = "Y";
                    approvalSystemItem.users_edit_addresses_user = "Y";
                    approvalSystemItem.users_add_addresses_app = "Y";
                    approvalSystemItem.users_add_addresses_dept = "Y";
                    approvalSystemItem.users_add_addresses_user = "Y";
                }
                // save new address
                if (!this.chkAdd_Address.Checked)
                {
                    approvalSystemItem.users_new_add_addresses_app = "N";
                    approvalSystemItem.users_new_add_addresses_dept = "N";
                    approvalSystemItem.users_new_add_addresses_user = "N";
                }
                else
                {
                    approvalSystemItem.users_new_add_addresses_app = "Y";
                    approvalSystemItem.users_new_add_addresses_dept = "Y";
                    approvalSystemItem.users_new_add_addresses_user = "Y";
                }
            }

            if (this.chkAttachConNumToUrl.Checked == true)
            {
                approvalSystemItem.AttachConsignmentNumberToUrl = true;
            }
            else
            {
                approvalSystemItem.AttachConsignmentNumberToUrl = false;
            }

            if (this.chkAllUserMain.Checked)
            {
                approvalSystemItem.allow_order_behalf_users_app = "Y";
            }
            else if (!this.chkDeptMain.Checked)
            {
                approvalSystemItem.allow_order_behalf_users_app = "N";
            }
            else
            {
                approvalSystemItem.allow_order_behalf_users_app = "O";
            }
            if (this.chkAllUserDept.Checked)
            {
                approvalSystemItem.allow_order_behalf_users_dept = "Y";
            }
            else if (!this.chkDept.Checked)
            {
                approvalSystemItem.allow_order_behalf_users_dept = "N";
            }
            else
            {
                approvalSystemItem.allow_order_behalf_users_dept = "O";
            }
            if (this.chkAllUserUser.Checked)
            {
                approvalSystemItem.allow_order_behalf_users_user = "Y";
            }
            else if (!this.chkDeptUser.Checked)
            {
                approvalSystemItem.allow_order_behalf_users_user = "N";
            }
            else
            {
                approvalSystemItem.allow_order_behalf_users_user = "O";
            }
            if (this.rdoAll_Dept.Checked)
            {
                if (!this.chkAllMain_dept.Checked)
                {
                    approvalSystemItem.allow_order_behalf_depts_app = "N";
                }
                else
                {
                    approvalSystemItem.allow_order_behalf_depts_app = "A";
                }
                if (!this.chkAllDept_dept.Checked)
                {
                    approvalSystemItem.allow_order_behalf_depts_dept = "N";
                }
                else
                {
                    approvalSystemItem.allow_order_behalf_depts_dept = "A";
                }
                if (!this.chkAllUser_dept.Checked)
                {
                    approvalSystemItem.allow_order_behalf_depts_user = "N";
                }
                else
                {
                    approvalSystemItem.allow_order_behalf_depts_user = "A";
                }
            }
            else if (!this.rdoBelong_Dept.Checked)
            {
                approvalSystemItem.allow_order_behalf_depts_app = "N";
                approvalSystemItem.allow_order_behalf_depts_dept = "N";
                approvalSystemItem.allow_order_behalf_depts_user = "N";
            }
            else
            {
                if (!this.chkBelongMain_dept.Checked)
                {
                    approvalSystemItem.allow_order_behalf_depts_app = "N";
                }
                else
                {
                    approvalSystemItem.allow_order_behalf_depts_app = "O";
                }
                if (!this.chkBelongDept_dept.Checked)
                {
                    approvalSystemItem.allow_order_behalf_depts_dept = "N";
                }
                else
                {
                    approvalSystemItem.allow_order_behalf_depts_dept = "O";
                }
                if (!this.chkBelongUser_dept.Checked)
                {
                    approvalSystemItem.allow_order_behalf_depts_user = "N";
                }
                else
                {
                    approvalSystemItem.allow_order_behalf_depts_user = "O";
                }
            }
            if (!this.Chk_SeeDeptAddress_MainAppr.Checked)
            {
                approvalSystemItem.users_select_Department_address_MainApp = "N";
            }
            else
            {
                approvalSystemItem.users_select_Department_address_MainApp = "Y";
            }
            if (!this.Chk_SeeDeptAddress_DeptAppr.Checked)
            {
                approvalSystemItem.users_select_Department_address_DeptApp = "N";
            }
            else
            {
                approvalSystemItem.users_select_Department_address_DeptApp = "Y";
            }
            if (!this.Chk_SeeDeptAddress_AllUser.Checked)
            {
                approvalSystemItem.users_select_Department_address_AllUser = "N";
            }
            else
            {
                approvalSystemItem.users_select_Department_address_AllUser = "Y";
            }
            if (!this.chkSelectAdrs_Main.Checked)
            {
                approvalSystemItem.users_select_addresses_app = "N";
            }
            else
            {
                approvalSystemItem.users_select_addresses_app = "Y";
            }
            if (!this.chkSelectAdrs_Dept.Checked)
            {
                approvalSystemItem.users_select_addresses_dept = "N";
            }
            else
            {
                approvalSystemItem.users_select_addresses_dept = "Y";
            }
            if (!this.chkSelectAdrs_User.Checked)
            {
                approvalSystemItem.users_select_addresses_user = "N";
            }
            else
            {
                approvalSystemItem.users_select_addresses_user = "Y";
            }
            if (!this.chkAdd_EditAddress_Main.Checked)
            {
                approvalSystemItem.users_add_addresses_app = "N";
                approvalSystemItem.users_edit_addresses_app = "N";
            }
            else
            {
                approvalSystemItem.users_add_addresses_app = "Y";
                approvalSystemItem.users_edit_addresses_app = "Y";
            }
            if (!this.chkAdd_EditAddress_Dept.Checked)
            {
                approvalSystemItem.users_add_addresses_dept = "N";
                approvalSystemItem.users_edit_addresses_dept = "N";
            }
            else
            {
                approvalSystemItem.users_add_addresses_dept = "Y";
                approvalSystemItem.users_edit_addresses_dept = "Y";
            }
            if (!this.chkAdd_EditAddress_User.Checked)
            {
                approvalSystemItem.users_add_addresses_user = "N";
                approvalSystemItem.users_edit_addresses_user = "N";
            }
            else
            {
                approvalSystemItem.users_add_addresses_user = "Y";
                approvalSystemItem.users_edit_addresses_user = "Y";
            }

            // save new address
            if (!this.chkAdd_Address_Main.Checked)
            {
                approvalSystemItem.users_new_add_addresses_app = "N";
                approvalSystemItem.users_new_add_addresses_app = "N";
            }
            else
            {
                approvalSystemItem.users_new_add_addresses_app = "Y";
                approvalSystemItem.users_new_add_addresses_app = "Y";
            }
            if (!this.chkAdd_Address_Dept.Checked)
            {
                approvalSystemItem.users_new_add_addresses_dept = "N";
                approvalSystemItem.users_new_add_addresses_dept = "N";
            }
            else
            {
                approvalSystemItem.users_new_add_addresses_dept = "Y";
                approvalSystemItem.users_new_add_addresses_dept = "Y";
            }
            if (!this.chkAdd_Address_User.Checked)
            {
                approvalSystemItem.users_new_add_addresses_user = "N";
                approvalSystemItem.users_new_add_addresses_user = "N";
            }
            else
            {
                approvalSystemItem.users_new_add_addresses_user = "Y";
                approvalSystemItem.users_new_add_addresses_user = "Y";
            }
            //end 

            if (!this.chkAddNewAdd_NotSave_Main.Checked)
            {
                approvalSystemItem.users_addNew_addresses_NotSaved_MainApp = "N";
            }
            else
            {
                approvalSystemItem.users_addNew_addresses_NotSaved_MainApp = "Y";
            }
            if (!this.chkAddNewAdd_NotSave_Dept.Checked)
            {
                approvalSystemItem.users_addNew_addresses_NotSaved_DeptApp = "N";
            }
            else
            {
                approvalSystemItem.users_addNew_addresses_NotSaved_DeptApp = "Y";
            }
            if (!this.chkAddNewAdd_NotSave_User.Checked)
            {
                approvalSystemItem.users_addNew_addresses_NotSaved_AllUser = "N";
            }
            else
            {
                approvalSystemItem.users_addNew_addresses_NotSaved_AllUser = "Y";
            }
            if (this.ProductStockManagement.ToLower() == "true")
            {
                if (!this.chkenablestkreplenished.Checked)
                {
                    approvalSystemItem.ShowStockReplenish = "N";
                }
                else if (this.Chk_Users.Checked)
                {
                    approvalSystemItem.ShowStockReplenish = "A";
                }
                else if (this.Chk_Dept.Checked)
                {
                    approvalSystemItem.ShowStockReplenish = "D";
                }
                else if (!this.Chk_Main.Checked)
                {
                    approvalSystemItem.ShowStockReplenish = "A";
                }
                else
                {
                    approvalSystemItem.ShowStockReplenish = "M";
                }
            }
            DataSet dataSet = ApprovalSystem.approvalsystemsettings_getDetails(Ordering_Process.UserID, Ordering_Process.CompanyID, Ordering_Process.AccountID);
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
            approvalSystemItem.ApprovalOrderID = this.ApprovalOrderID;
            if (ApprovalSystem.ApprovalOrderingProcess_AddOrEdit(approvalSystemItem) != 2)
            {
                this.objBase.Message_Display("Added successfully", "msg-success", this.plhMessageNew);
            }
            else
            {
                this.objBase.Message_Display("Updated successfully", "msg-success", this.plhMessageNew);
            }
            if (this.AccountType != null && this.AccountType.ToLower() == "p")
            {
                if (!this.Chk_Mandotory_Del.Enabled)
                {
                    this.Chk_Mandotory_Del.Checked = false;
                }
                if (!this.chk_Mandotory_Inv.Enabled)
                {
                    this.chk_Mandotory_Inv.Checked = false;
                }
            }
            if (this.AccountType != null)
            {
            }
            int num = 0;
            num = (!this.chk_isterms.Checked ? 0 : 1);
            WebstoreBasePage.TermsAndConditions_Insert(Convert.ToInt32(Ordering_Process.CompanyID), Convert.ToInt32(Ordering_Process.AccountID), num, this.Radeditor.Content);
            WebstoreBasePage.Orderingprocess_settings(Convert.ToInt32(Ordering_Process.CompanyID), Convert.ToInt32(Ordering_Process.AccountID), this.chkMarkall.Checked, this.chkHideMisJob.Checked, this.rdoIs_Only_User_Jobs.Checked, this.rdoIs_Only_User_DepartmentJobs.Checked, this.rdoIs_User_All_Jobs.Checked, this.chkHideMISinvoice.Checked, this.rdoIs_only_User_Invoice.Checked, this.rdoIs_only_user_DepartmentInvoice.Checked, this.rdoIs_User_All_Invoice.Checked, this.rdoIs_Only_User_Orders.Checked, this.rdoIs_Only_User_DepartmentOrders.Checked, this.rdoIs_User_All_Orders.Checked, this.txtJobName.Text, this.chkJobNameShow.Checked, this.chkJobNameRequired.Checked, this.chkAttachConNumToUrl.Checked);
            string text = this.lbl_OrderTitle.Text;
            string empty = string.Empty;
            int num1 = (string.IsNullOrEmpty(this.txtEstimateDelivery.Value.Trim()) ? 0 : int.Parse(this.txtEstimateDelivery.Value.Trim()));
            WebstoreBasePage.ShowOrderInformation_Update(Ordering_Process.AccountID, Ordering_Process.CompanyID, this.lbl_OrderTitle.Text, this.lbl_OrdNum.Text, this.lbl_DelReq.Text, this.lbl_Comments.Text, this.lbl_costcenter.Text, this.txt_OrdTit_Screen.Text, this.txt_OrdNum_Screen.Text, this.txt_DelReq_Screen.Text, this.txt_Comments_Screen.Text, this.txt_costcenter_screen.Text, this.chk_OrdTit_Show.Checked, this.chk_OrdNum_Show.Checked, this.chk_DelReq_Show.Checked, this.chek_Comments_Show.Checked, this.chk_OrdTit_Req.Checked, this.chk_OrdNum_Req.Checked, this.chk_DelReq_Req.Checked, this.chk_Comments_Req.Checked, this.chkCostCenter_Req.Checked, this.Chk_Mandotory_Del.Checked, this.chk_Mandotory_Inv.Checked, this.Chk_Display_Del.Checked, this.Chk_Display_Inv.Checked, this.chk_EnableOrder.Checked, this.Chk_EnableAddress.Checked, num1, Convert.ToInt32(this.ddlWorkingdaysFrom.SelectedValue), Convert.ToInt32(this.ddlWorkingDaysTo.SelectedValue),  chkColumnsList,ddlFilterDateType.SelectedValue, ddlFilterDateRange.SelectedValue, this.chkShowDates.Checked);
            this.BindApprovalSettings(Ordering_Process.UserID, Ordering_Process.CompanyID, Ordering_Process.AccountID);
            this.OrderManager();
        }

        public void OrderManager()
        {
            DataTable dataTable = WebstoreBasePage.OrderMangerOptions_Select(Convert.ToInt32(Ordering_Process.CompanyID), Convert.ToInt32(Ordering_Process.AccountID));
            foreach (DataRow row in dataTable.Rows)
            {
                if (!Convert.ToBoolean(row["Is_Select_AllCartItems"]))
                {
                    this.chkMarkall.Checked = false;
                }
                else
                {
                    this.chkMarkall.Checked = true;
                }
                this.txtJobName.Text = Convert.ToString(row["CartJobScreenName"]);
                if (!Convert.ToBoolean(row["CartJobNameShow"]))
                {
                    this.chkJobNameShow.Checked = false;
                    this.chkJobNameRequired.Checked = false;
                    this.chkJobNameRequired.Enabled = false;
                }
                else
                {
                    this.chkJobNameShow.Checked = true;
                    if (!Convert.ToBoolean(row["CartJobNameIsMandatory"]))
                    {
                        this.chkJobNameRequired.Checked = false;
                        this.chkJobNameRequired.Enabled = true;
                    }
                    else
                    {
                        this.chkJobNameRequired.Checked = true;
                        this.chkJobNameRequired.Enabled = true;
                    }
                }
                if (!Convert.ToBoolean(row["IsHideMISJob"]))
                {
                    this.chkHideMisJob.Checked = false;
                }
                else
                {
                    this.chkHideMisJob.Checked = true;
                }
                if (!Convert.ToBoolean(row["Is_Only_User_Jobs"]))
                {
                    this.rdoIs_Only_User_Jobs.Checked = false;
                }
                else
                {
                    this.rdoIs_Only_User_Jobs.Checked = true;
                    this.Rdb_SeeAllDeptJobs_Dept.Checked = true;
                    this.Rdb_SeeAllJobs_Dept.Checked = false;
                }
                if (!Convert.ToBoolean(row["Is_Only_User_DepartmentJobs"]))
                {
                    this.rdoIs_Only_User_DepartmentJobs.Checked = false;
                }
                else
                {
                    this.rdoIs_Only_User_DepartmentJobs.Checked = true;
                    this.Rdb_SeeAllDeptJobs_Dept.Checked = true;
                    this.Rdb_SeeAllJobs_Dept.Checked = false;
                }
                if (!Convert.ToBoolean(row["Is_User_All_Jobs"]))
                {
                    this.rdoIs_User_All_Jobs.Checked = false;
                }
                else
                {
                    this.rdoIs_User_All_Jobs.Checked = true;
                    this.Rdb_SeeAllJobs_Dept.Checked = true;
                    this.Rdb_SeeAllDeptJobs_Dept.Checked = false;
                }
                if (!Convert.ToBoolean(row["IsHideMISInvoice"]))
                {
                    this.chkHideMISinvoice.Checked = false;
                }
                else
                {
                    this.chkHideMISinvoice.Checked = true;
                }
                if (!Convert.ToBoolean(row["AttachConNumToUrl"]))
                {
                    this.chkAttachConNumToUrl.Checked = false;
                }
                else
                {
                    this.chkAttachConNumToUrl.Checked = true;
                }
                if (!Convert.ToBoolean(row["Is_only_User_Invoice"]))
                {
                    this.rdoIs_only_User_Invoice.Checked = false;
                }
                else
                {
                    this.rdoIs_only_User_Invoice.Checked = true;
                    this.Rdb_SeeDeptInvoices_Dept.Checked = true;
                    this.Rdb_SeeAllInoices_Dept.Checked = false;
                }
                if (!Convert.ToBoolean(row["Is_only_user_DepartmentInvoice"]))
                {
                    this.rdoIs_only_user_DepartmentInvoice.Checked = false;
                }
                else
                {
                    this.rdoIs_only_user_DepartmentInvoice.Checked = true;
                    this.Rdb_SeeDeptInvoices_Dept.Checked = true;
                    this.Rdb_SeeAllInoices_Dept.Checked = false;
                }
                if (!Convert.ToBoolean(row["Is_User_All_Invoice"]))
                {
                    this.rdoIs_User_All_Invoice.Checked = false;
                }
                else
                {
                    this.rdoIs_User_All_Invoice.Checked = true;
                    this.Rdb_SeeAllInoices_Dept.Checked = true;
                    this.Rdb_SeeDeptInvoices_Dept.Checked = false;
                }
                if (!Convert.ToBoolean(row["Is_Only_User_Orders"]))
                {
                    this.rdoIs_Only_User_Orders.Checked = false;
                }
                else
                {
                    this.rdoIs_Only_User_Orders.Checked = true;
                    this.Rdb_SeeAllDptOrder_Dept.Checked = true;
                    this.Rdb_SeeAllOrder_Dept.Checked = false;
                }
                if (!Convert.ToBoolean(row["Is_Only_User_DepartmentOrders"]))
                {
                    this.rdoIs_Only_User_DepartmentOrders.Checked = false;
                }
                else
                {
                    this.rdoIs_Only_User_DepartmentOrders.Checked = true;
                    this.Rdb_SeeAllDptOrder_Dept.Checked = true;
                    this.Rdb_SeeAllOrder_Dept.Checked = false;
                }
                if (!Convert.ToBoolean(row["Is_User_All_Orders"]))
                {
                    this.rdoIs_User_All_Orders.Checked = false;
                }
                else
                {
                    this.rdoIs_User_All_Orders.Checked = true;
                    this.Rdb_SeeAllOrder_Dept.Checked = true;
                    this.Rdb_SeeAllDptOrder_Dept.Checked = false;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Session["UserID"].ToString() != null)
            {
                Ordering_Process.UserID = Convert.ToInt64(base.Session["UserID"].ToString());
            }
            if (base.Session["CompanyID"].ToString() != null)
            {
                Ordering_Process.CompanyID = Convert.ToInt64(base.Session["CompanyID"].ToString());
            }
            if (base.Session["ProductStockManagement"] != null)
            {
                this.ProductStockManagement = base.Session["ProductStockManagement"].ToString();
            }
            string str = SettingsBasePage.Fetch_SelectedAccountID(Ordering_Process.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                Ordering_Process.AccountID = (long)Convert.ToInt32(strArrays[0]);
            }
            this.AccountType = WebstoreBasePage.SelectAccountType(Convert.ToInt32(Ordering_Process.AccountID));
            if (Ordering_Process.AccountID != (long)0 && !base.IsPostBack && (this.AccountType != null && this.AccountType.ToLower() == "x"))
            {
                this.tblMarkAllSetting.Visible = false;
                this.RadPanelBar1.FindItemByText("Confirm Before Order").Visible = false;
                this.RadPanelBar1.FindItemByText("Order Manager Options").Visible = false;
                this.RadPanelBar1.FindItemByText("Product Details").Visible = false;
                this.RadPanelBar1.FindItemByText("Checkout Page Options").Expanded = true;
                this.tbl_CheckoutProcess.Attributes.Add("style", "display:none");
                this.CheckoutProcess_Header.Visible = false;
                this.lbl_costcenter.Attributes.Add("style", "display:none");
                this.txt_costcenter_screen.Attributes.Add("style", "display:none");
                this.chkCostCenter_Req.Attributes.Add("style", "display:none");
                this.chkCostCenter.Attributes.Add("style", "display:none");
            }
            this.Assign_ApprovalSystemSettings_ForAccount(Ordering_Process.AccountID);
            if (!base.IsPostBack)
            {
                this.BindApprovalSettings(Ordering_Process.UserID, Ordering_Process.CompanyID, Ordering_Process.AccountID);
            }
            this.lblDelWorkDays.Text = this.objLanguage.GetLanguageConversion("Delivery_and_Working_days");
            this.lblDeliveryDate.Text = this.objLanguage.GetLanguageConversion("Delivery_Days");
            this.lblWorkingDays.Text = this.objLanguage.GetLanguageConversion("Working_Days_New");
            DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(Convert.ToInt32(Ordering_Process.CompanyID));
            if (dataTable.Rows.Count > 0)
            {
                Convert.ToBoolean(dataTable.Rows[0]["IsDisplayCostCentre"]);
                if (this.ProductStockManagement.ToLower() == "true")
                {
                    this.tblstkreplnsh.Style.Add("display", "block");
                    this.tblReplenishNote.Style.Add("display", "block");
                }
            }
            this.RadPanelBar1.Width = Unit.Pixel(950);
            if (this.AccountType != null && this.AccountType.ToLower() != "x")
            {
                this.RadPanelBar1.Items[0].Text = this.objLanguage.GetLanguageConversion("Product_Details");
                this.RadPanelBar1.Items[1].Text = this.objLanguage.GetLanguageConversion("Shopping_Cart_Options");
                this.RadPanelBar1.Items[2].Text = this.objLanguage.GetLanguageConversion("Checkout_Page_Options");
                this.RadPanelBar1.Items[3].Text = this.objLanguage.GetLanguageConversion("Order_Confirmation");
                this.RadPanelBar1.Items[4].Text = this.objLanguage.GetLanguageConversion("Order_Manager_Options");
            }
            else
            {
                this.RadPanelBar1.Items[1].Text = this.objLanguage.GetLanguageConversion("Shopping_Cart_Options");
                this.RadPanelBar1.Items[3].Text = this.objLanguage.GetLanguageConversion("Checkout_Page_Options");
            }
            Ordering_Process.CompanyID = (long)Convert.ToInt32(base.Session["CompanyID"].ToString());
            Ordering_Process.UserID = (long)Convert.ToInt32(base.Session["UserID"].ToString());
            string[] strArrays1 = new string[1];
            string[] secureVirtualPath = new string[] { this.SecureVirtualPath, this.ServerName, "/", base.Session["CompanyID"].ToString(), "/" };
            strArrays1[0] = string.Concat(secureVirtualPath);
            string[] strArrays2 = strArrays1;
            this.Radeditor.ImageManager.UploadPaths = strArrays2;
            this.Radeditor.ImageManager.ViewPaths = strArrays2;
            this.Radeditor.FlashManager.ViewPaths = strArrays2;
            this.Radeditor.FlashManager.UploadPaths = strArrays2;
            this.Radeditor.DocumentManager.ViewPaths = strArrays2;
            this.Radeditor.DocumentManager.UploadPaths = strArrays2;
            this.Radeditor.Height = Unit.Pixel(400);
            this.Radeditor.Width = Unit.Pixel(700);
            if (ConnectionClass.RadEditorUploadSize != null)
            {
                this.Radeditor.ImageManager.MaxUploadFileSize = Convert.ToInt32(ConnectionClass.RadEditorUploadSize);
            }
            if (!base.IsPostBack)
            {
                DataTable dataTable1 = WebstoreBasePage.TermsAndConditions_Select(Convert.ToInt32(Ordering_Process.CompanyID), Convert.ToInt32(Ordering_Process.AccountID));
                foreach (DataRow row in dataTable1.Rows)
                {
                    if (!Convert.ToBoolean(row["IsTerms"]))
                    {
                        this.chk_isterms.Checked = false;
                    }
                    else
                    {
                        this.chk_isterms.Checked = true;
                    }
                    this.Radeditor.Content = row["TermsAndCondition"].ToString();
                }
            }
            if (!this.chkDeptOrderingProcess.Checked)
            {
                this.divDeptOrderingProcess123.Style.Add("display", "block");
                this.divDeptOrderingProcess123.Attributes.Add("class", "DivBackColor");
            }
            else
            {
                this.divDeptOrderingProcess123.Attributes.Add("class", "");
            }
            if (!this.chkUserOrderingProcess.Checked)
            {
                this.divUserOrderingProcess123.Style.Add("display", "block");
                this.divUserOrderingProcess123.Attributes.Add("class", "DivBackColor");
            }
            else
            {
                this.divUserOrderingProcess123.Attributes.Add("class", "");
            }
            if (!this.chkAllowOrder.Checked)
            {
                this.divAllowOrderBehalf123.Style.Add("display", "block");
                this.divAllowOrderBehalf123.Attributes.Add("class", "DivBackColor");
            }
            else
            {
                this.divAllowOrderBehalf123.Attributes.Add("class", "");
            }
            if (this.AccountType == null)
            {
                this.OrderInformation.Visible = false;
                this.ShowAddressInformation.Visible = false;
                this.tbl_address.Attributes.Add("style", "padding-top:15px");
                this.Divtbl_address.Attributes.Add("style", "width:69%");
            }
            else if (this.AccountType != null && this.AccountType.ToLower() != "p")
            {
                this.Divtbl_address.Attributes.Add("style", "width:70%");
            }
            else
            {
                this.chk_EnableOrder.Checked = true;
                this.OrderInformation.Visible = false;
                this.ShowAddressInformation.Visible = false;
                this.tbl_address.Attributes.Add("style", "padding-top:10px");
                this.Divtbl_address.Attributes.Add("style", "width:69%");
            }
            this.Rdb_SeeAllOrder_Main.Enabled = false;
            this.Rdb_SeeAllOrder_Dept.Enabled = false;
            this.Rdb_SeeAllDptOrder_Main.Enabled = false;
            this.Rdb_SeetheirOrder_Dept.Enabled = false;
            this.Rdb_SeeAllDptOrder_Dept.Enabled = false;
            this.Rdb_SeetheirOrder_Main.Enabled = false;
            this.Rdb_SeeAllJobs_Main.Enabled = false;
            this.Rdb_SeeAllJobs_Dept.Enabled = false;
            this.Rdb_SeeAllDeptJobs_Main.Enabled = false;
            this.Rdb_SeeAllDeptJobs_Dept.Enabled = false;
            this.Rdb_SeeonlytheirJobs_Main.Enabled = false;
            this.Rdb_SeeonlytheirJobs_Dept.Enabled = false;
            this.Rdb_SeeAllInoices_Main.Enabled = false;
            this.Rdb_SeeAllInoices_Dept.Enabled = false;
            this.Rdb_SeeDeptInvoices_Main.Enabled = false;
            this.Rdb_SeeDeptInvoices_Dept.Enabled = false;
            this.Rdb_SeeOnlyTheirInvoices_Main.Enabled = false;
            this.Rdb_SeeOnlyTheirInvoices_Dept.Enabled = false;
            this.Rdb_SeeAllJobs_Main.Checked = true;
            this.Rdb_SeeAllOrder_Main.Checked = true;
            this.Rdb_SeeAllInoices_Main.Checked = true;
            if (this.AccountType != null && this.AccountType.ToLower() == "x")
            {
                this.Del_Mandatory.Attributes.Add("style", "Padding-left:36px");
                this.Inv_Mandatory.Attributes.Add("style", "Padding-left:36px");
                this.Required.Attributes.Add("style", "Padding-left:35px");
            }
            if (!base.IsPostBack)
            {
                this.OrderManager();
            }
            if (this.AccountType != null && this.AccountType.ToLower() != "x")
            {
                //this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "javascript:HideMisJobsOnLoad();HideMISInvoiceOnLoad()", true);
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "javascript:HideMisJobsOnLoad();", true);
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "javascript:HideMISInvoiceOnLoad();", true);
            }
        }
    }
}