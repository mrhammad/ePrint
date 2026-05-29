using System.Data.SqlClient;

namespace nmsCommon
{
	/// <summary>
	/// Applies built-in System Templates registration seed (see NewCompanySystemTemplateSeeds).
	/// </summary>
	internal static class NewCompanySystemTemplates
	{
		public static void Apply(int companyId, SqlConnection connection)
		{
			NewCompanySystemTemplateSeeds.Apply(companyId, connection);
		}
	}
}
