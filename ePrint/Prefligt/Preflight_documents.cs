using nmsConnectionClass;
using System;
using System.Diagnostics;
using System.IO;

namespace Prefligt
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

		public PreflightParameters Preflight_file(string UploadedfileName, string preflightProfile, string AccountId, string CompanyId, string PdfPath)
		{
			this.SecureDocPath = ConnectionClass.SecureDocPath.ToString();
			this.ServerName = ConnectionClass.ServerName.ToString();
			string[] secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "/store/0/PreflightProfile/", preflightProfile, ".ppp" };
			this.PreflightProfilePath = string.Concat(secureDocPath);
			PreflightParameters preflightParameter = new PreflightParameters();
			try
			{
				this.InputPdfPath = string.Concat(PdfPath, "/", UploadedfileName);
				this.OutPutPdfPath = string.Concat(PdfPath, "/Prelight_", UploadedfileName);
				this.ReportPdfName = string.Concat(PdfPath, "/Report_", UploadedfileName);
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