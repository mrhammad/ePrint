using System.Data.SqlClient;

namespace nmsCommon
{
	/// <summary>
	/// Seeds eight working sample estimates for new tenant registration (Other Cost, Quick Quote,
	/// Large Format, Product Catalogue, Sheet Fed Digital, Inventory, and multi-item examples).
	/// Data is applied from built-in SQL (<see cref="NewCompanyRegistrationEstimateSeeds"/>), not copied from company 2144 at runtime.
	/// </summary>
	internal static class NewCompanyReferenceEstimates
	{
		public static void Seed(int companyId, int adminUserId)
		{
			if (companyId <= 0 || adminUserId <= 0)
			{
				return;
			}

			commonClass cmn = new commonClass();
			SqlConnection connection = cmn.openConnection();
			try
			{
				NewCompanyRegistrationEstimateSeeds.Apply(companyId, adminUserId, connection);
			}
			finally
			{
				cmn.closeConnection();
			}
		}
	}
}
