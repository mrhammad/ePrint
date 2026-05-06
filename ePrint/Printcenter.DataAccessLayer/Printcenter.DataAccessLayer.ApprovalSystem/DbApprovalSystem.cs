using DataAccessLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using Printcenter.BusinessAccessLayer.ApprovalSystem;
using System;
using System.Data;
using System.Data.Common;

namespace Printcenter.DataAccessLayer.ApprovalSystem
{
	public class DbApprovalSystem : DataAccess
	{
		public DbApprovalSystem()
		{
		}

		public virtual int ApprovalOrderingProcess_AddOrEdit(ApprovalSystemItems item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2B_ApprovalOrderingProcess_AddOREdit");
			database.AddInParameter(storedProcCommand, "@ApprovalOrderID", DbType.Int64, item.ApprovalOrderID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, item.accountID);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, item.companyID);
			database.AddInParameter(storedProcCommand, "@allow_order_behalf_users_app", DbType.String, item.allow_order_behalf_users_app);
			database.AddInParameter(storedProcCommand, "@allow_order_behalf_users_dept", DbType.String, item.allow_order_behalf_users_dept);
			database.AddInParameter(storedProcCommand, "@allow_order_behalf_users_user", DbType.String, item.allow_order_behalf_users_user);
			database.AddInParameter(storedProcCommand, "@allow_order_behalf_depts_app", DbType.String, item.allow_order_behalf_depts_app);
			database.AddInParameter(storedProcCommand, "@allow_order_behalf_depts_dept", DbType.String, item.allow_order_behalf_depts_dept);
			database.AddInParameter(storedProcCommand, "@allow_order_behalf_depts_user", DbType.String, item.allow_order_behalf_depts_user);
			database.AddInParameter(storedProcCommand, "@allow_checkout_process_app", DbType.String, item.allow_checkout_process_app);
			database.AddInParameter(storedProcCommand, "@allow_checkout_process_dept", DbType.String, item.allow_checkout_process_dept);
			database.AddInParameter(storedProcCommand, "@allow_checkout_process_user", DbType.String, item.allow_checkout_process_user);
			database.AddInParameter(storedProcCommand, "@users_change_addresses_app", DbType.String, item.users_change_addresses_app);
			database.AddInParameter(storedProcCommand, "@users_change_addresses_dept", DbType.String, item.users_change_addresses_dept);
			database.AddInParameter(storedProcCommand, "@users_change_addresses_user", DbType.String, item.users_change_addresses_user);
			database.AddInParameter(storedProcCommand, "@users_select_addresses_app", DbType.String, item.users_select_addresses_app);
			database.AddInParameter(storedProcCommand, "@users_select_addresses_dept", DbType.String, item.users_select_addresses_dept);
			database.AddInParameter(storedProcCommand, "@users_select_addresses_user", DbType.String, item.users_select_addresses_user);
			database.AddInParameter(storedProcCommand, "@users_edit_addresses_app", DbType.String, item.users_edit_addresses_app);
			database.AddInParameter(storedProcCommand, "@users_edit_addresses_dept", DbType.String, item.users_edit_addresses_dept);
			database.AddInParameter(storedProcCommand, "@users_edit_addresses_user", DbType.String, item.users_edit_addresses_user);
            // save new address
            database.AddInParameter(storedProcCommand, "@users_new_add_addresses_app", DbType.String, item.users_new_add_addresses_app);
            database.AddInParameter(storedProcCommand, "@users_new_add_addresses_dept", DbType.String, item.users_new_add_addresses_dept);
            database.AddInParameter(storedProcCommand, "@users_new_add_addresses_user", DbType.String, item.users_new_add_addresses_user);

			database.AddInParameter(storedProcCommand, "@users_add_addresses_app", DbType.String, item.users_add_addresses_app);
			database.AddInParameter(storedProcCommand, "@users_add_addresses_dept", DbType.String, item.users_add_addresses_dept);
			database.AddInParameter(storedProcCommand, "@users_add_addresses_user", DbType.String, item.users_add_addresses_user);
			database.AddInParameter(storedProcCommand, "@users_select_Department_address_MainApp", DbType.String, item.users_select_Department_address_MainApp);
			database.AddInParameter(storedProcCommand, "@users_select_Department_address_DeptApp", DbType.String, item.users_select_Department_address_DeptApp);
			database.AddInParameter(storedProcCommand, "@users_select_Department_address_AllUser", DbType.String, item.users_select_Department_address_AllUser);
			database.AddInParameter(storedProcCommand, "@users_AddNew_address_NotSaved_MainApp", DbType.String, item.users_addNew_addresses_NotSaved_MainApp);
			database.AddInParameter(storedProcCommand, "@users_AddNew_address_NotSaved_DeptApp", DbType.String, item.users_addNew_addresses_NotSaved_DeptApp);
			database.AddInParameter(storedProcCommand, "@users_AddNew_address_NotSaved_AllUser", DbType.String, item.users_addNew_addresses_NotSaved_AllUser);
			database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, item.createdBy);
			database.AddInParameter(storedProcCommand, "@ShowCostCenters", DbType.Boolean, item.ShowCostCentre);
			database.AddInParameter(storedProcCommand, "@ShowStockReplenish", DbType.String, item.ShowStockReplenish);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
		}

		public virtual int ApprovalRegistration_AddOrEdit(ApprovalSystemItems item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2B_ApprovalRegistration_AddOREdit");
			database.AddInParameter(storedProcCommand, "@ApprovalRegisterID", DbType.Int64, item.ApprovalRegisterID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, item.accountID);
			database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, item.createdBy);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, item.companyID);
			database.AddInParameter(storedProcCommand, "@userDeptType", DbType.String, item.userDeptType);
			database.AddInParameter(storedProcCommand, "@DepartmentID", DbType.Int32, item.DepartmentID);
			database.AddInParameter(storedProcCommand, "@RegisterEmailAddress", DbType.String, item.registerEmailAddress);
			database.AddInParameter(storedProcCommand, "@ApprovedEmailAddress", DbType.String, item.approvedEmailAddress);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.AddInParameter(storedProcCommand, "@PrefilAdded", DbType.Int32, item.PrefilAdded);
			database.AddInParameter(storedProcCommand, "@OverwriteAdded", DbType.Int32, item.OverwriteAdded);
			database.AddInParameter(storedProcCommand, "@IsSelfRegister", DbType.Int32, item.isSelfReg);
			database.AddInParameter(storedProcCommand, "@AddNewDept", DbType.Boolean, item.AddNewDept);
			database.AddInParameter(storedProcCommand, "@DeptScreenName", DbType.String, item.DeptScreenName);
			database.AddInParameter(storedProcCommand, "@IsSingleField", DbType.Boolean, item.SingleField);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
		}

		public virtual int approvalsystemsettings_AddOrEdit(ApprovalSystemItems item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2B_approvalsystemsettings_AddOREdit");
			database.AddInParameter(storedProcCommand, "@approvalSystemID", DbType.Int64, item.approvalSystemID);
			database.AddInParameter(storedProcCommand, "@accountID", DbType.Int64, item.accountID);
			database.AddInParameter(storedProcCommand, "@createdBy", DbType.Int64, item.createdBy);
			database.AddInParameter(storedProcCommand, "@companyID", DbType.Int64, item.companyID);
			database.AddInParameter(storedProcCommand, "@approvalType", DbType.String, item.approvalType);
			database.AddInParameter(storedProcCommand, "@reapproval", DbType.Boolean, item.reapproval);
			database.AddInParameter(storedProcCommand, "@requirePwd", DbType.Boolean, item.requirePwd);
			database.AddInParameter(storedProcCommand, "@approverEmail", DbType.String, item.approverEmail);
			database.AddInParameter(storedProcCommand, "@lastApproverDefault", DbType.Boolean, item.lastApproverDefault);
			database.AddInParameter(storedProcCommand, "@newOrdersApprove", DbType.Boolean, item.newOrdersApprove);
			database.AddInParameter(storedProcCommand, "@newUserApprove", DbType.Boolean, item.newUserApprove);
			database.AddInParameter(storedProcCommand, "@editedUserApprove", DbType.Boolean, item.editedUserApprove);
			database.AddInParameter(storedProcCommand, "@createdOn", DbType.DateTime, item.createdOn);
			database.AddInParameter(storedProcCommand, "@approvalReqForOrder", DbType.Int32, item.approvalReqForOrder);
			database.AddInParameter(storedProcCommand, "@orderResendApproval", DbType.Int32, item.orderResendApproval);
			database.AddInParameter(storedProcCommand, "@orderAutoDelete", DbType.Int32, item.orderAutoDelete);
			database.AddInParameter(storedProcCommand, "@orderAutoChangeStatus", DbType.Int32, item.orderAutoChangeStatus);
			database.AddInParameter(storedProcCommand, "@StatusID ", DbType.Int64, item.StatusID);
			database.AddInParameter(storedProcCommand, "@orderInformAdmin", DbType.Int32, item.orderInformAdmin);
			database.AddInParameter(storedProcCommand, "@regResendApproval", DbType.Int32, item.regResendApproval);
			database.AddInParameter(storedProcCommand, "@regAutoReject", DbType.Int32, item.regAutoReject);
			database.AddInParameter(storedProcCommand, "@regInformAdmin", DbType.Int32, item.regInformAdmin);
			database.AddInParameter(storedProcCommand, "@ApprovedEmailAddress", DbType.String, item.approvedEmailAddress);
			database.AddInParameter(storedProcCommand, "@MarkalltheitemsasApproved", DbType.Boolean, item.MarkalltheitemsasApproved);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
		}

		public virtual DataSet approvalsystemsettings_getDetails(long UserID, long CompanyID, long AccountID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataSet dataSet = new DataSet();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2B_approvalsystemsettings_select");
			database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public virtual DataTable PendingApprovalRecordsPerAccount(long AccountID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataSet dataSet = new DataSet();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PendingApprovalRecordsPerAccount");
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			return database.ExecuteDataSet(storedProcCommand).Tables[0];
		}
	}
}