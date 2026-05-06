using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mail;

namespace nmsCommon
{
	public class checkEmail
	{
		public checkEmail()
		{
		}

		public bool Email(string email)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_checkemail"
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@email", email);
			sqlCommand.ExecuteNonQuery();
			int value = (int)sqlCommand.Parameters["ReturnValue"].Value;
			_commonClass.closeConnection();
			if (value > 0)
			{
				return true;
			}
			return false;
		}

		public bool Email_secondAdmin(string email, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_checkEmail_secondAdmin"
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@email", email);
			sqlCommand.Parameters.AddWithValue("@companyID", companyid);
			sqlCommand.ExecuteNonQuery();
			int value = (int)sqlCommand.Parameters["ReturnValue"].Value;
			_commonClass.closeConnection();
			if (value > 0)
			{
				return true;
			}
			return false;
		}

		public bool SendEmailToClient(string MailToId, ArrayList ContentList, string SectionName, int CompanyID, string LanguageName)
		{
			string empty = string.Empty;
			string str = string.Empty;
			string empty1 = string.Empty;
			string str1 = string.Empty;
			MailMessage mailMessage = new MailMessage();
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_common_select_email_message", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@companyId", CompanyID);
			sqlCommand.Parameters.AddWithValue("@sectionName", SectionName);
			sqlCommand.Parameters.AddWithValue("@languageName", LanguageName);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
			while (sqlDataReader.Read())
			{
				mailMessage.From = sqlDataReader["registrationEmail"].ToString().Trim().Replace("&lt;", "<").Replace("&gt;", ">");
				empty = sqlDataReader["registrationEmail"].ToString().Trim().Replace("&lt;", "<").Replace("&gt;", ">");
				mailMessage.Subject = sqlDataReader["subject"].ToString().Trim();
				str = sqlDataReader["subject"].ToString().Trim();
				str1 = sqlDataReader["message"].ToString();
			}
			sqlDataReader.Close();
			_commonClass.closeConnection();
			if (SectionName.ToLower().Trim() == "registration")
			{
				str1 = str1.Replace("[$EMAILADDRESS$]", MailToId.Trim());
				str1 = str1.Replace("[$PASSWORD$]", ContentList[0].ToString().Trim());
				str1 = str1.Replace("[$LOGINLINK$]", "");
				string.Concat(global.sitePath(), "VerificationPage.aspx?vCode=", ContentList[1].ToString().Trim());
				str1 = str1.Replace("[$VERIFICATIONCODE$]", string.Concat(global.sitePath(), "VerificationPage.aspx?vCode=", ContentList[1].ToString().Trim()));
				str1 = str1.Replace("[$DISPLAYCODE$]", ContentList[1].ToString().Trim());
			}
			else if (SectionName.ToLower().Trim() == "add user")
			{
				str1 = str1.Replace("[$EMAILADDRESS$]", MailToId.Trim());
				str1 = str1.Replace("[$PASSWORD$]", ContentList[0].ToString().Trim());
				str1 = str1.Replace("[$LOGINLINK$]", string.Concat("<a href='", global.sitePath(), "'>Login Here</a>"));
			}
			else if ((SectionName.ToLower().Trim() == "add task" || SectionName.ToLower().Trim() == "edit task") && ContentList.Count == 3)
			{
				str1 = str1.Replace("[$subject$]", ContentList[0].ToString().Trim());
				str1 = str1.Replace("[$duedate$]", ContentList[1].ToString().Trim());
				str1 = str1.Replace("[$description$]", ContentList[2].ToString().Trim());
			}
			if (SectionName.ToLower().Trim() != "registration")
			{
				mailMessage.To = MailToId.Trim();
			}
			else
			{
				mailMessage.To = MailToId.Trim();
			}
			mailMessage.Bcc = global.SuperEmail();
			mailMessage.Body = str1.Trim();
			mailMessage.BodyFormat = MailFormat.Html;
			mailMessage.Priority = MailPriority.High;
			SmtpMail.SmtpServer = global.SmtpServerName();
			bool flag = false;
			bool flag1 = true;
			string empty2 = string.Empty;
			BaseClass.SendMailMessage(empty, MailToId.Trim(), global.SuperEmail(), "", str, str1.Trim(), empty2, flag1);
			try
			{
				flag = true;
			}
			catch
			{
			}
			return flag;
		}
	}
}