using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnection;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

namespace Preflight
{
	public class Preflight_documents
	{
		public string SecureDocPath = string.Empty;

		public string ServerName = string.Empty;

		public string InputPdfPath = string.Empty;

		public string OutPutPdfPath = string.Empty;

		public string ReportPdfName = string.Empty;

		public string PreflightProfilePath = string.Empty;

		public Preflight_documents()
		{
		}

		public PreflightParameters Preflight_file(string UploadedfileName, long ProductID, string preflightProfile, string AccountId, string CompanyId, string PdfStorePath, string PdfAttachmentPath)
		{
			this.SecureDocPath = ConnectionClass.SecureDocPath.ToString();
			this.ServerName = ConnectionClass.ServerName.ToString();
			bool flag = false;
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			SqlCommand sqlCommand = new SqlCommand()
			{
				CommandText = string.Concat("select isnull(PreFlightProfile,0) as PreFlightProfile from tb_PriceCatalogue where PriceCatalogueID=", ProductID)
			};
			long num = (long)0;
			num = Convert.ToInt64(database.ExecuteScalar(sqlCommand).ToString());
			preflightProfile = string.Empty;
			if (num != (long)0)
			{
				sqlCommand.CommandText = string.Concat("select ProfileName from tb_PreflightProfile where Id=", num);
				preflightProfile = database.ExecuteScalar(sqlCommand).ToString();
				string[] secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "/store/0/PreflightProfile/", preflightProfile, ".ppp" };
				this.PreflightProfilePath = string.Concat(secureDocPath);
				flag = true;
			}
			PreflightParameters preflightParameter = new PreflightParameters();
			if (!flag || preflightProfile == null || preflightProfile == "")
			{
				preflightParameter.CorrectedFile = "";
				preflightParameter.IsPreflighted = false;
				preflightParameter.ReportFile = "";
				return preflightParameter;
			}
			try
			{
				this.InputPdfPath = string.Concat(PdfStorePath, "/", UploadedfileName);
				this.OutPutPdfPath = string.Concat(PdfStorePath, "/Prelight_", UploadedfileName);
				this.ReportPdfName = string.Concat(PdfStorePath, "/Report_", UploadedfileName);
				Process process = new Process();
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.RedirectStandardError = true;
				//process.StartInfo.FileName = "C:\\Program Files\\Enfocus\\Enfocus PitStop Server 18\\PitStopServerCLI.exe";
                process.StartInfo.FileName = "D:\\Enfocus\\Enfocus PitStop Server 18\\PitStopServerCLI.exe";
                string str = string.Concat("-input \"[input]\" -mutator \"[Profile]\"", " -output \"[output]\" -reportPDF \"[log]\"");
				str = str.Replace("[input]", this.InputPdfPath).Replace("[Profile]", this.PreflightProfilePath).Replace("[output]", this.OutPutPdfPath).Replace("[log]", this.ReportPdfName);
				process.StartInfo.Arguments = str;
				process.Start();
				process.StandardOutput.ReadToEnd();
				process.StandardError.ReadToEnd();
				process.WaitForExit();
				if (process.ExitCode != 0)
				{
					preflightParameter.CorrectedFile = UploadedfileName;
					preflightParameter.ReportFile = "";
					preflightParameter.IsPreflighted = false;
				}
				else
				{
					if (File.Exists(this.OutPutPdfPath))
					{
						File.Copy(this.OutPutPdfPath, string.Concat(PdfAttachmentPath, "/Prelight_", UploadedfileName));
					}
					if (File.Exists(this.ReportPdfName))
					{
						File.Copy(this.ReportPdfName, string.Concat(PdfAttachmentPath, "/Report_", UploadedfileName));
					}
					preflightParameter.CorrectedFile = string.Concat("Prelight_", UploadedfileName);
					preflightParameter.ReportFile = string.Concat("Report_", UploadedfileName);
					preflightParameter.IsPreflighted = true;
				}
			}
			catch
			{
				preflightParameter.CorrectedFile = UploadedfileName;
				preflightParameter.ReportFile = "";
				preflightParameter.IsPreflighted = false;
			}
			return preflightParameter;
		}
	}
}