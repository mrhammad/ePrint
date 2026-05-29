using Printcenter.UI.Company;
using Printcenter.UI.Department;
using System;
using System.Data;
using System.Data.SqlClient;

namespace nmsCommon
{
	public class registrationClass
	{
		public registrationClass()
		{
		}

		public void add_user(int companyid, string email, string password, string firstname, string lastname, string phone, string jobtitle, int isadmin, string createdate, string modifieddate, int timezoneid, int ispasswordexpire, string expiredate, int groupid, int usertypeid, int iscorporateright, string verificationcode)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_user_add_withAccessRights"
			};
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.Parameters.AddWithValue("@email", email);
			sqlCommand.Parameters.AddWithValue("@password", password);
			sqlCommand.Parameters.AddWithValue("@firstname", firstname);
			sqlCommand.Parameters.AddWithValue("@lastname", lastname);
			sqlCommand.Parameters.AddWithValue("@phone", phone);
			sqlCommand.Parameters.AddWithValue("@jobtitle", jobtitle);
			sqlCommand.Parameters.AddWithValue("@isadmin", isadmin);
			sqlCommand.Parameters.AddWithValue("@createdate", createdate);
			sqlCommand.Parameters.AddWithValue("@modifieddate", modifieddate);
			sqlCommand.Parameters.AddWithValue("@timezoneid", timezoneid);
			sqlCommand.Parameters.AddWithValue("@ispasswordexpire", ispasswordexpire);
			sqlCommand.Parameters.AddWithValue("@expiredate", expiredate);
			sqlCommand.Parameters.AddWithValue("@groupid", groupid);
			sqlCommand.Parameters.AddWithValue("@usertypeid", usertypeid);
			sqlCommand.Parameters.AddWithValue("@iscorporateright", iscorporateright);
			sqlCommand.Parameters.AddWithValue("@verificationcode", verificationcode);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void AddSecondAdmin(string companyname, string firstname, string lastname, string email, string password, string confirmpassword, string address1, string address2, string city, string country, string zip, string hearaboutus, string comments, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_addsecondadmin"
			};
			sqlCommand.Parameters.AddWithValue("@companyname", companyname);
			sqlCommand.Parameters.AddWithValue("@firstname", firstname);
			sqlCommand.Parameters.AddWithValue("@lastname", lastname);
			sqlCommand.Parameters.AddWithValue("@email", email);
			sqlCommand.Parameters.AddWithValue("@password", password);
			sqlCommand.Parameters.AddWithValue("@confirmpassword", confirmpassword);
			sqlCommand.Parameters.AddWithValue("@address1", address1);
			sqlCommand.Parameters.AddWithValue("@address2", address2);
			sqlCommand.Parameters.AddWithValue("@city", city);
			sqlCommand.Parameters.AddWithValue("@country", country);
			sqlCommand.Parameters.AddWithValue("@zip", zip);
			sqlCommand.Parameters.AddWithValue("@hearaboutus", hearaboutus);
			sqlCommand.Parameters.AddWithValue("@comments", comments);
			sqlCommand.Parameters.AddWithValue("@companyID", companyid);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public int registration(string country, string lcid, string companyname, string address, string city, string zip, int noofemployee, int noofuser, string hearfrom, string comment, int isTrial, string regdate, string modifieddate, int isnewsletter, int isbusiness, string expiredate, string languagename, string currency, int isgroupenabled, int timezoneid, string datetimeformat, string email, int createuserid, int expire, string uniqueValue)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_register"
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@country", country);
			sqlCommand.Parameters.AddWithValue("@lcid", lcid);
			sqlCommand.Parameters.AddWithValue("@companyname", companyname);
			sqlCommand.Parameters.AddWithValue("@address", address);
			sqlCommand.Parameters.AddWithValue("@city", city);
			sqlCommand.Parameters.AddWithValue("@zip", zip);
			sqlCommand.Parameters.AddWithValue("@noofemployee", noofemployee);
			sqlCommand.Parameters.AddWithValue("@noofuser", noofuser);
			sqlCommand.Parameters.AddWithValue("@hearfrom", hearfrom);
			sqlCommand.Parameters.AddWithValue("@comment", comment);
			sqlCommand.Parameters.AddWithValue("@istrail", isTrial);
			sqlCommand.Parameters.AddWithValue("@regdate", regdate);
			sqlCommand.Parameters.AddWithValue("@modifieddate", modifieddate);
			sqlCommand.Parameters.AddWithValue("@isnewsletter", isnewsletter);
			sqlCommand.Parameters.AddWithValue("@isbusiness", isbusiness);
			sqlCommand.Parameters.AddWithValue("@expiredate", expiredate);
			sqlCommand.Parameters.AddWithValue("@languagename", languagename);
			sqlCommand.Parameters.AddWithValue("@currency", currency);
			sqlCommand.Parameters.AddWithValue("@datetimeformat", datetimeformat);
			sqlCommand.Parameters.AddWithValue("@isgroupenabled", isgroupenabled);
			sqlCommand.Parameters.AddWithValue("@timezoneid", timezoneid);
			sqlCommand.Parameters.AddWithValue("@email", email);
			sqlCommand.Parameters.AddWithValue("@createuserid", createuserid);
			sqlCommand.Parameters.AddWithValue("@expires", expire);
			sqlCommand.Parameters.AddWithValue("@UniqueValue", uniqueValue);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
			return (int)sqlCommand.Parameters["ReturnValue"].Value;
		}

		public int RegisterNew(string country, string lcid, string companyname, string address, string city, string zip, int noofemployee, int noofuser, string hearfrom, string comment, int isTrial, DateTime regdate, DateTime modifieddate, int isnewsletter, int isbusiness, DateTime expiredate, string languagename, string currency, int isgroupenabled, int timezoneid, string datetimeformat, string email, int createuserid, int expire, string uniqueValue)
		{
			commonClass _commonClass = new commonClass();
			SqlConnection connection = _commonClass.openConnection();
			try
			{
				SqlCommand existsCommand = new SqlCommand(
					"SELECT TOP 1 1 FROM tb_user WHERE email = @email",
					connection);
				existsCommand.Parameters.AddWithValue("@email", email ?? string.Empty);
				if (existsCommand.ExecuteScalar() != null)
				{
					return 0;
				}

				const string insertCompanySql = @"
INSERT INTO tb_company (
	country, lcid, companyName, address, city, zip, noofemployee, noofuser, hearFrom, comment,
	istrial, regdate, modifieddate, isnewsletter, isbusiness, expiredate, languagename, currency,
	datetimeformat, isgroupenabled, timezoneid, leadsHTMLEmail, marketingEmail, CreatedUserID,
	ExipredAfter, UniqueValue)
VALUES (
	@country, @lcid, @companyname, @address, @city, @zip, @noofemployee, @noofuser, @hearfrom, @comment,
	1, @regdate, @modifieddate, @isnewsletter, @isbusiness, @expiredate, @languagename, @currency,
	@datetimeformat, @isgroupenabled, @timezoneid, @email, @email, @createuserid, @expires, @UniqueValue);
SELECT CAST(SCOPE_IDENTITY() AS INT);";

				SqlCommand insertCommand = new SqlCommand(insertCompanySql, connection);
				insertCommand.Parameters.AddWithValue("@country", country ?? string.Empty);
				insertCommand.Parameters.AddWithValue("@lcid", lcid ?? string.Empty);
				insertCommand.Parameters.AddWithValue("@companyname", companyname ?? string.Empty);
				insertCommand.Parameters.AddWithValue("@address", address ?? string.Empty);
				insertCommand.Parameters.AddWithValue("@city", city ?? string.Empty);
				insertCommand.Parameters.AddWithValue("@zip", zip ?? string.Empty);
				insertCommand.Parameters.AddWithValue("@noofemployee", noofemployee);
				insertCommand.Parameters.AddWithValue("@noofuser", noofuser);
				insertCommand.Parameters.AddWithValue("@hearfrom", hearfrom ?? string.Empty);
				insertCommand.Parameters.AddWithValue("@comment", comment ?? string.Empty);
				insertCommand.Parameters.AddWithValue("@regdate", regdate);
				insertCommand.Parameters.AddWithValue("@modifieddate", modifieddate);
				insertCommand.Parameters.AddWithValue("@isnewsletter", isnewsletter);
				insertCommand.Parameters.AddWithValue("@isbusiness", isbusiness);
				insertCommand.Parameters.AddWithValue("@expiredate", expiredate);
				insertCommand.Parameters.AddWithValue("@languagename", languagename ?? string.Empty);
				insertCommand.Parameters.AddWithValue("@currency", currency ?? string.Empty);
				insertCommand.Parameters.AddWithValue("@datetimeformat", datetimeformat ?? string.Empty);
				insertCommand.Parameters.AddWithValue("@isgroupenabled", isgroupenabled);
				insertCommand.Parameters.AddWithValue("@timezoneid", timezoneid);
				insertCommand.Parameters.AddWithValue("@email", email ?? string.Empty);
				insertCommand.Parameters.AddWithValue("@createuserid", createuserid);
				insertCommand.Parameters.AddWithValue("@expires", expire);
				insertCommand.Parameters.AddWithValue("@UniqueValue", uniqueValue ?? string.Empty);

				object newCompanyId = insertCommand.ExecuteScalar();
				if (newCompanyId == null || newCompanyId == DBNull.Value)
				{
					return 0;
				}

				return Convert.ToInt32(newCompanyId);
			}
			finally
			{
				_commonClass.closeConnection();
			}
		}

		public void RegisterAdminUser(int companyId, string email, string encryptedPassword, string firstName, string lastName, string phone, int timezoneId)
		{
			DateTime now = DateTime.Now;
			this.add_user(
				companyId,
				email,
				encryptedPassword,
				firstName,
				lastName,
				phone ?? string.Empty,
				"Administrator",
				1,
				now.ToString(),
				now.ToString(),
				timezoneId,
				0,
				now.AddYears(10).ToString(),
				0,
				0,
				1,
				string.Empty);
		}

		/// <summary>Re-runs setup for a company left incomplete after a failed sign-up.</summary>
		public void RepairNewCompanySetup(int companyId, int timezoneId, string dateFormat)
		{
			this.CompleteNewCompanySetup(companyId, timezoneId, dateFormat);
		}

		/// <summary>Re-runs built-in registration sample estimate seeding for an existing tenant.</summary>
		public void RepairReferenceEstimates(int companyId)
		{
			if (companyId <= 0)
			{
				return;
			}

			commonClass cmn = new commonClass();
			SqlCommand adminUserCommand = new SqlCommand(
				"SELECT TOP 1 userid FROM tb_user WHERE companyid = @companyId AND isadmin = 1 ORDER BY userid",
				cmn.openConnection());
			adminUserCommand.Parameters.AddWithValue("@companyId", companyId);
			object userIdResult = adminUserCommand.ExecuteScalar();
			cmn.closeConnection();
			if (userIdResult == null || userIdResult == DBNull.Value)
			{
				return;
			}

			int adminUserId = Convert.ToInt32(userIdResult);
			this.SeedSampleCrmData(companyId, adminUserId);
			NewCompanyReferenceEstimates.Seed(companyId, adminUserId);
		}

		/// <summary>Re-runs sample CRM/estimate seeding and backfills missing item detail rows for an existing tenant.</summary>
		public void RepairSampleEstimates(int companyId)
		{
			if (companyId <= 0)
			{
				return;
			}

			commonClass cmn = new commonClass();
			SqlCommand adminUserCommand = new SqlCommand(
				"SELECT TOP 1 userid FROM tb_user WHERE companyid = @companyId AND isadmin = 1 ORDER BY userid",
				cmn.openConnection());
			adminUserCommand.Parameters.AddWithValue("@companyId", companyId);
			object userIdResult = adminUserCommand.ExecuteScalar();
			cmn.closeConnection();
			if (userIdResult == null || userIdResult == DBNull.Value)
			{
				return;
			}

			int adminUserId = Convert.ToInt32(userIdResult);
			this.RepairReferenceEstimates(companyId);
		}

		/// <summary>Applies built-in System Templates registration seed.</summary>
		public void RepairSystemTemplates(int companyId)
		{
			if (companyId <= 0)
			{
				return;
			}

			commonClass cmn = new commonClass();
			SqlConnection connection = cmn.openConnection();
			try
			{
				NewCompanySystemTemplates.Apply(companyId, connection);
			}
			finally
			{
				cmn.closeConnection();
			}
		}

		/// <summary>Repairs list views only (Customer, Estimate, Job, etc.) for an existing tenant.</summary>
		public void RepairCustomizeViews(int companyId)
		{
			if (companyId <= 0)
			{
				return;
			}

			commonClass cmn = new commonClass();
			SqlConnection connection = cmn.openConnection();
			try
			{
				NewCompanyDefaultSeeds.ApplyCustomizeViews(companyId, connection);
			}
			finally
			{
				cmn.closeConnection();
			}
		}

		public void CompleteNewCompanySetup(int companyId, int timezoneId, string dateFormat)
		{
			if (companyId <= 0)
			{
				return;
			}

			commonClass cmn = new commonClass();
			SqlConnection connection = cmn.openConnection();
			try
			{
				SqlCommand userCommand = new SqlCommand(
					"UPDATE tb_user SET DefaultLanding = 'Home' WHERE companyid = @companyId AND isadmin = 1",
					connection);
				userCommand.Parameters.AddWithValue("@companyId", companyId);
				userCommand.ExecuteNonQuery();

				SqlCommand companyCommand = new SqlCommand(
					"UPDATE tb_company SET LanguageConversionFile = 'English_TO_English' WHERE companyid = @companyId AND (LanguageConversionFile IS NULL OR LTRIM(RTRIM(LanguageConversionFile)) = '')",
					connection);
				companyCommand.Parameters.AddWithValue("@companyId", companyId);
				companyCommand.ExecuteNonQuery();

				SqlCommand defaultViewsCommand = new SqlCommand("CRM_INSERT_DEFAULTVIEW", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				defaultViewsCommand.Parameters.AddWithValue("@CompanyID", companyId);
				defaultViewsCommand.ExecuteNonQuery();

				NewCompanyDefaultSeeds.ApplyAll(companyId, connection, timezoneId, dateFormat ?? "dd/mm/yyyy");

				try
				{
					NewCompanySystemTemplates.Apply(companyId, connection);
				}
				catch (Exception templateSeedEx)
				{
					System.Diagnostics.Trace.WriteLine("NewCompanySystemTemplates: " + templateSeedEx);
				}

				int adminUserId = 0;
				SqlCommand adminUserCommand = new SqlCommand(
					"SELECT TOP 1 userid FROM tb_user WHERE companyid = @companyId AND isadmin = 1 ORDER BY userid",
					connection);
				adminUserCommand.Parameters.AddWithValue("@companyId", companyId);
				object userIdResult = adminUserCommand.ExecuteScalar();
				if (userIdResult != null && userIdResult != DBNull.Value)
				{
					adminUserId = Convert.ToInt32(userIdResult);
				}

				if (adminUserId > 0)
				{
					SqlCommand proofViewCommand = new SqlCommand("PC_CustomizeViewIfNotExist", connection)
					{
						CommandType = CommandType.StoredProcedure
					};
					proofViewCommand.Parameters.AddWithValue("@companyID", companyId);
					proofViewCommand.Parameters.AddWithValue("@userID", adminUserId);
					proofViewCommand.ExecuteNonQuery();

					try
					{
						this.SeedSampleCrmData(companyId, adminUserId);
					}
					catch (Exception sampleEx)
					{
						System.Diagnostics.Trace.WriteLine("SeedSampleCrmData: " + sampleEx);
					}

					// Sample estimate seeding disabled for new registrations (re-enable via RepairReferenceEstimates when needed).
				}
			}
			finally
			{
				cmn.closeConnection();
			}
		}

		/// <summary>
		/// Creates a sample CRM customer, delivery address, and default contact so new tenants can explore the system immediately.
		/// </summary>
		public void SeedSampleCrmData(int companyId, int adminUserId)
		{
			if (companyId <= 0 || adminUserId <= 0)
			{
				return;
			}

			const string sampleCustomerName = "Test Customer";
			const string sampleContactFirstName = "John";
			const string sampleContactLastName = "Doe";
			const string sampleCountry = "Australia";

			commonClass cmn = new commonClass();
			BaseClass encoder = new BaseClass();
			string encodedCustomerName = encoder.SpecialEncode(sampleCustomerName);

			SqlCommand existsCommand = new SqlCommand(@"
SELECT TOP 1 clientid
FROM tb_client
WHERE companyID = @companyId
	AND companytype = 'Customer'
	AND ISNULL(isdelete, 0) = 0
	AND LTRIM(RTRIM(clientname)) = @clientName", cmn.openConnection());
			existsCommand.Parameters.AddWithValue("@companyId", companyId);
			existsCommand.Parameters.AddWithValue("@clientName", encodedCustomerName);
			object existingClientId = existsCommand.ExecuteScalar();
			cmn.closeConnection();
			if (existingClientId != null && existingClientId != DBNull.Value)
			{
				return;
			}

			string accountNumber = string.Empty;
			try
			{
				DataTable accountNumberTable = CompanyBasePage.Account_Number_Generate(companyId, "A");
				if (accountNumberTable != null && accountNumberTable.Rows.Count > 0 && accountNumberTable.Columns.Count > 0)
				{
					accountNumber = encoder.SpecialEncode(accountNumberTable.Rows[0][0].ToString());
				}
			}
			catch
			{
			}

			DateTime now = DateTime.Now;
			string encodedAlias = encoder.SpecialEncode("Test");
			string encodedEmail = encoder.SpecialEncode("sample@testcustomer.local");
			string encodedDescription = encoder.SpecialEncode("Sample customer created during registration.");
			string encodedStreet = encoder.SpecialEncode("123 Sample Street");
			string encodedCity = encoder.SpecialEncode("Sydney");
			string encodedState = encoder.SpecialEncode("NSW");
			string encodedZip = encoder.SpecialEncode("2000");
			string encodedCountry = encoder.SpecialEncode(sampleCountry);
			string encodedPhone = encoder.SpecialEncode("02 9000 0000");
			string encodedContactAlias = encoder.SpecialEncode("John_Doe");
			string encodedCompanyNameOnContact = encoder.SpecialEncode(sampleCustomerName);

			string accountStatusId = this.GetDefaultAccountStatusId(companyId, cmn);
			if (string.IsNullOrEmpty(accountStatusId))
			{
				accountStatusId = "0";
			}

			int clientId = CompanyBasePage.Company_InsertUpdate(
				companyId,
				0,
				"Customer",
				encodedCustomerName,
				encodedAlias,
				string.Empty,
				accountStatusId,
				accountNumber,
				encodedEmail,
				string.Empty,
				string.Empty,
				string.Empty,
				0,
				0,
				string.Empty,
				string.Empty,
				string.Empty,
				"0",
				new DateTime(1900, 1, 1),
				string.Empty,
				string.Empty,
				string.Empty,
				adminUserId,
				string.Empty,
				string.Empty,
				encodedDescription,
				now,
				adminUserId,
				0,
				0,
				false,
				string.Empty,
				string.Empty,
				false);

			if (clientId <= 0)
			{
				return;
			}

			long addressId = CompanyBasePage.CompanyDefaultAddress_InsertUpdate(
				0,
				clientId,
				encodedStreet,
				encodedCity,
				encodedState,
				encodedZip,
				encodedCountry,
				encodedPhone,
				string.Empty,
				string.Empty,
				adminUserId,
				now.ToString(),
				string.Empty,
				encoder.SpecialEncode("Suite 1"),
				encodedEmail,
				"N");

			long departmentId = DepartmentBaseClass.departmentInsert(
				0,
				"Main",
				clientId,
				0,
				adminUserId,
				Convert.ToInt32(addressId),
				"A",
				now,
				now,
				companyId,
				addressId,
				0,
				0,
				"N",
				false,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				0,
				string.Empty,
				string.Empty,
				false,
				string.Empty);

			CompanyBasePage.Contact_InsertUpdate(
				companyId,
				0,
				clientId,
				string.Empty,
				encoder.SpecialEncode(sampleContactFirstName),
				string.Empty,
				encoder.SpecialEncode(sampleContactLastName),
				encodedContactAlias,
				encodedCompanyNameOnContact,
				string.Empty,
				string.Empty,
				encodedPhone,
				string.Empty,
				encodedEmail,
				0,
				adminUserId,
				departmentId,
				string.Empty,
				Convert.ToInt32(addressId),
				true,
				0,
				0,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				false,
				now);
		}

		private string GetDefaultAccountStatusId(int companyId, commonClass cmn)
		{
			if (companyId <= 0 || cmn == null)
			{
				return string.Empty;
			}

			SqlCommand command = new SqlCommand(@"
SELECT TOP 1 CAST(StatusID AS NVARCHAR(20))
FROM tb_AccountStatus
WHERE CompanyID = @companyId AND ISNULL(IsDeleted, 0) = 0
ORDER BY StatusID", cmn.openConnection());
			command.Parameters.AddWithValue("@companyId", companyId);
			object result = command.ExecuteScalar();
			cmn.closeConnection();
			return result == null || result == DBNull.Value ? string.Empty : result.ToString();
		}
	}
}
