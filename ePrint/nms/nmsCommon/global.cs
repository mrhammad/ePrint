using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace nmsCommon
{
	public class global
	{
		public static string strimagepath;

		public static string PageTitle;

		public static string pageName;

		public static string pgName;

		public static string pgDetail;

		private static string[] _pageSize;

		public static string[] PageSize
		{
			get
			{
				return global._pageSize;
			}
		}

		static global()
		{
			global.strimagepath = string.Empty;
			global.PageTitle = string.Empty;
			string[] strArrays = new string[] { "5", "10", "15", "20", "25", "50", "75", "100" };
			global._pageSize = strArrays;
		}

		public global()
		{
		}

		public static string AdjustableNumber()
		{
			return EprintConfigurationManager.AppSettings["AdjustableNumber"];
		}

		public static string companyName()
		{
			return EprintConfigurationManager.AppSettings["CompanyName"];
		}

		public static string databaseUserName()
		{
			return EprintConfigurationManager.AppSettings["Owner"];
		}

		public static string filePath()
		{
			return EprintConfigurationManager.AppSettings["FilePath"];
		}

		public static string GetScreenName(int CompanyId, string LabelName, string pg)
		{
			string labelName = LabelName;
			LabelName = string.Concat("'", LabelName, "'");
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_common_select_ScreenName", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@companyID", CompanyId);
			sqlCommand.Parameters.AddWithValue("@labelName", LabelName);
			sqlCommand.Parameters.AddWithValue("@pg", pg);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			string empty = string.Empty;
			if (!sqlDataReader.HasRows)
			{
				empty = labelName;
			}
			else
			{
				while (sqlDataReader.Read())
				{
					empty = sqlDataReader[0].ToString();
				}
			}
			_commonClass.closeConnection();
			return empty;
		}

		public static bool GetTabDisplayRight(int CompanyID, int UserID, string TabName)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_common_getTabDisplayRight", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@companyID", CompanyID);
			sqlCommand.Parameters.AddWithValue("@userID", UserID);
			sqlCommand.Parameters.AddWithValue("@tabName", TabName);
			sqlCommand.ExecuteNonQuery();
			int value = (int)sqlCommand.Parameters["ReturnValue"].Value;
			_commonClass.closeConnection();
			if (value > 0)
			{
				return true;
			}
			return false;
		}

		public static Image GetTickImage(string imageID)
		{
			Image image = new Image()
			{
				ID = imageID,
				ImageUrl = string.Concat(global.imagePath(), "check.gif"),
				ImageAlign = ImageAlign.AbsMiddle,
				Width = Unit.Pixel(15),
				Height = Unit.Pixel(15),
				ToolTip = "Yes"
			};
			return image;
		}

		public static string imagePath()
		{
			return global.strimagepath;
		}

		public static string ImportFilePath()
		{
			return EprintConfigurationManager.AppSettings["ImportFilePath"];
		}

		public static bool Is_Non_Print_System()
		{
			return Convert.ToBoolean(EprintConfigurationManager.AppSettings["Is_Non_Printing_System"]);
		}

		public static string pageTitle(string title, int companyid, string companyname)
		{
			BasePage basePage = new BasePage();
			BaseClass baseClass = new BaseClass();
			global.PageTitle = basePage.GetRegionalSettings(companyid, "PageTitle");
			if (global.PageTitle == "")
			{
				global.PageTitle = "E-Print Software";
			}
			return baseClass.SpecialDecode(string.Concat(global.PageTitle, ": ", title));
		}

		public static string PublicDocPath()
		{
			return EprintConfigurationManager.AppSettings["PublicDocPath"];
		}

		public static string SecureDocFilepath()
		{
			return EprintConfigurationManager.AppSettings["SecureDocFilepath"];
		}

		public static string SecureDocPath()
		{
			return EprintConfigurationManager.AppSettings["SecureDocPath"];
		}

		public static string SecureSitePath()
		{
			return EprintConfigurationManager.AppSettings["SecureSitePath"];
		}

		public static string SecureVirtualPath()
		{
			return EprintConfigurationManager.AppSettings["SecureVirtualPath"];
		}

		public static string ServerTimeZoneOrderNumber()
		{
			return EprintConfigurationManager.AppSettings["ServerTimeZoneOrderNumber"];
		}

		public static string sitePath()
		{
			return EprintConfigurationManager.AppSettings["SitePath"];
		}

		public static string SmtpServerName()
		{
			return EprintConfigurationManager.AppSettings["SmtpServer"];
		}

		public static string SuperEmail()
		{
			return EprintConfigurationManager.AppSettings["SuperEmail"];
		}

		public static string TemplatesitePath()
		{
			return EprintConfigurationManager.AppSettings["TemplateEditor"];
		}
	}
}