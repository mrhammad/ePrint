using System;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace nmsCommon
{
	/// <summary>
	/// Built-in sample estimates for new company registration (eight reference estimates from company 2144).
	/// Content is stored in SeedData/SystemEstimatesRegistration.sql in the repository,
	/// not read from another company at runtime.
	/// </summary>
	internal static class NewCompanyRegistrationEstimateSeeds
	{
		private const string EmbeddedResourceName = "nmsCommon.SeedData.SystemEstimatesRegistration.sql";
		private const string SeedDataRelativePath = "nms/nmsCommon/SeedData/SystemEstimatesRegistration.sql";

		public static void Apply(int companyId, int adminUserId, SqlConnection connection)
		{
			if (companyId <= 0 || adminUserId <= 0 || connection == null)
			{
				return;
			}

			string sql = LoadSeedSql();
			if (string.IsNullOrWhiteSpace(sql))
			{
				System.Diagnostics.Trace.WriteLine("NewCompanyRegistrationEstimateSeeds: seed SQL not found.");
				return;
			}

			using (SqlCommand command = new SqlCommand(sql, connection))
			{
				command.Parameters.AddWithValue("@companyId", companyId);
				command.Parameters.AddWithValue("@adminUserId", adminUserId);
				command.CommandTimeout = 600;
				command.ExecuteNonQuery();
			}
		}

		private static string LoadSeedSql()
		{
			Assembly assembly = typeof(NewCompanyRegistrationEstimateSeeds).Assembly;
			using (Stream stream = assembly.GetManifestResourceStream(EmbeddedResourceName))
			{
				if (stream != null)
				{
					using (StreamReader reader = new StreamReader(stream))
					{
						return reader.ReadToEnd();
					}
				}
			}

			string basePath = AppDomain.CurrentDomain.BaseDirectory;
			string filePath = Path.Combine(basePath, SeedDataRelativePath.Replace('/', Path.DirectorySeparatorChar));
			if (File.Exists(filePath))
			{
				return File.ReadAllText(filePath);
			}

			return null;
		}
	}
}
