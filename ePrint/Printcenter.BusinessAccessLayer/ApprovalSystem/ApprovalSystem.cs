using Printcenter.BusinessAccessLayer;
using Printcenter.DataAccessLayer.ApprovalSystem;
using System;
using System.Data;

namespace Printcenter.BusinessAccessLayer.ApprovalSystem
{
	public class ApprovalSystem : BaseBusiness
	{
		public ApprovalSystem()
		{
		}

		public static int ApprovalOrderingProcess_AddOrEdit(ApprovalSystemItems item)
		{
			return (new DbApprovalSystem()).ApprovalOrderingProcess_AddOrEdit(item);
		}

		public static int ApprovalRegistration_AddOrEdit(ApprovalSystemItems item)
		{
			return (new DbApprovalSystem()).ApprovalRegistration_AddOrEdit(item);
		}

		public static int approvalsystemsettings_AddOrEdit(ApprovalSystemItems item)
		{
			return (new DbApprovalSystem()).approvalsystemsettings_AddOrEdit(item);
		}

		public static DataSet approvalsystemsettings_getDetails(long UserID, long CompanyID, long AccountID)
		{
			return (new DbApprovalSystem()).approvalsystemsettings_getDetails(UserID, CompanyID, AccountID);
		}

		public static DataTable PendingApprovalRecordsPerAccount(long AccountID)
		{
			return (new DbApprovalSystem()).PendingApprovalRecordsPerAccount(AccountID);
		}
	}
}