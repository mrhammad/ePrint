using System;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace nmsCommon
{
	/// <summary>
	/// Built-in System Templates for new company registration (same pattern as RegistrationBootstrapSeeds).
	/// Template content is stored in SeedData/SystemTemplatesRegistration.sql in the repository,
	/// not read from another company at runtime.
	/// </summary>
	internal static class NewCompanySystemTemplateSeeds
	{
		private const string EmbeddedResourceName = "nmsCommon.SeedData.SystemTemplatesRegistration.sql";
		private const string SeedDataRelativePath = "nms/nmsCommon/SeedData/SystemTemplatesRegistration.sql";

		public static void Apply(int companyId, SqlConnection connection)
		{
			if (companyId <= 0 || connection == null)
			{
				return;
			}

			string sql = LoadSeedSql();
			if (string.IsNullOrWhiteSpace(sql))
			{
				System.Diagnostics.Trace.WriteLine("NewCompanySystemTemplateSeeds: seed SQL not found.");
				return;
			}

			using (SqlCommand command = new SqlCommand(sql, connection))
			{
				command.Parameters.AddWithValue("@companyId", companyId);
				command.CommandTimeout = 600;
				command.ExecuteNonQuery();
			}

			CopySeedPdfFiles(companyId);
		}

		private static string LoadSeedSql()
		{
			Assembly assembly = typeof(NewCompanySystemTemplateSeeds).Assembly;
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

		/// <summary>
		/// Copies optional PDF assets shipped under nms/nmsCommon/SeedData/TemplatePDF/ to the tenant folder.
		/// </summary>
		private static void CopySeedPdfFiles(int companyId)
		{
			try
			{
				string secureDocPath = global.SecureDocPath();
				string serverName = nmsConnectionClass.ConnectionClass.ServerName;
				if (string.IsNullOrWhiteSpace(secureDocPath) || string.IsNullOrWhiteSpace(serverName))
				{
					return;
				}

				string basePath = AppDomain.CurrentDomain.BaseDirectory;
				string seedPdfDir = Path.Combine(basePath, "nms", "nmsCommon", "SeedData", "TemplatePDF");
				if (!Directory.Exists(seedPdfDir))
				{
					seedPdfDir = Path.GetFullPath(Path.Combine(basePath, "..", "..", "nms", "nmsCommon", "SeedData", "TemplatePDF"));
				}

				if (!Directory.Exists(seedPdfDir))
				{
					return;
				}

				string targetDir = Path.Combine(secureDocPath, serverName, companyId.ToString(), "TemplatePDF");
				Directory.CreateDirectory(targetDir);

				foreach (string sourceFile in Directory.GetFiles(seedPdfDir))
				{
					string fileName = Path.GetFileName(sourceFile);
					string targetFile = Path.Combine(targetDir, fileName);
					if (!File.Exists(targetFile))
					{
						File.Copy(sourceFile, targetFile);
					}
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Trace.WriteLine("NewCompanySystemTemplateSeeds.CopySeedPdfFiles: " + ex);
			}
		}
	}
}
