using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using System;
using System.Data;
using System.Data.SqlClient;

namespace nmsCommon
{
	/// <summary>
	/// Creates one sample estimate per major item type so new tenants see variety on the Estimate list.
	/// Does not copy data from template companies.
	/// </summary>
	internal static class NewCompanySampleEstimates
	{
		private const string SampleMarkerComment = "Registration sample estimate";
		private const string DemoNumberPrefix = "DEMO-";

		private static readonly SampleEstimateType[] SampleTypes =
		{
			new SampleEstimateType("S", "Sheet Fed Digital"),
			new SampleEstimateType("L", "Sheet Fed Offset"),
			new SampleEstimateType("F", "Large Format"),
			new SampleEstimateType("O", "Outwork"),
			new SampleEstimateType("U", "Other Cost"),
			new SampleEstimateType("W", "Warehouse"),
			new SampleEstimateType("Q", "Quick Quote"),
		};

		public static void BackfillItemBodies(int companyId, int adminUserId)
		{
			if (companyId <= 0 || adminUserId <= 0)
			{
				return;
			}

			commonClass cmn = new commonClass();
			SqlCommand command = new SqlCommand(@"
SELECT ei.EstimateItemID, ei.EstimateType, e.EstimateTitle
FROM tb_estimate e
INNER JOIN tb_estimateitem ei ON ei.EstimateID = e.EstimateID AND ISNULL(ei.IsDeleted, 0) = 0
WHERE e.CompanyID = @companyId
	AND ISNULL(e.IsDeleted, 0) = 0
	AND (e.EstimateNumber LIKE @demoPrefix OR e.Comments LIKE @marker)", cmn.openConnection());
			command.Parameters.AddWithValue("@companyId", companyId);
			command.Parameters.AddWithValue("@demoPrefix", DemoNumberPrefix + "%");
			command.Parameters.AddWithValue("@marker", "%" + SampleMarkerComment + "%");

			try
			{
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						long estimateItemId = Convert.ToInt64(reader["EstimateItemID"]);
						string itemType = reader["EstimateType"].ToString();
						string title = reader["EstimateTitle"] == DBNull.Value ? string.Empty : reader["EstimateTitle"].ToString();
						NewCompanySampleEstimateItemBodies.SeedForItem(companyId, adminUserId, estimateItemId, itemType, title);
					}
				}
			}
			finally
			{
				cmn.closeConnection();
			}
		}

		public static void Seed(int companyId, int adminUserId)
		{
			if (companyId <= 0 || adminUserId <= 0)
			{
				return;
			}

			if (HasSampleEstimates(companyId))
			{
				return;
			}

			SampleCustomerContext customer = LoadSampleCustomer(companyId);
			if (customer == null)
			{
				return;
			}

			int statusId = GetDefaultEstimateStatusId(companyId);
			if (statusId <= 0)
			{
				return;
			}

			DateTime now = DateTime.Now;
			int validFor = GetDefaultValidForDays(companyId);
			int demoSequence = 0;

			foreach (SampleEstimateType sampleType in SampleTypes)
			{
				demoSequence++;
				try
				{
					CreateSampleEstimate(
						companyId,
						adminUserId,
						customer,
						statusId,
						validFor,
						now,
						sampleType,
						demoSequence);
				}
				catch (Exception ex)
				{
					System.Diagnostics.Trace.WriteLine(
						"NewCompanySampleEstimates " + sampleType.ItemTypeCode + ": " + ex.Message);
				}
			}
		}

		private static void CreateSampleEstimate(
			int companyId,
			int adminUserId,
			SampleCustomerContext customer,
			int statusId,
			int validFor,
			DateTime now,
			SampleEstimateType sampleType,
			int demoSequence)
		{
			string title = EncodeField("Sample - " + sampleType.DisplayName);
			string estimateNumber = DemoNumberPrefix + demoSequence.ToString("000");
			string comment = SampleMarkerComment;

			long estimateId = EstimateBasePage.Estimate_Insert(
				companyId,
				adminUserId,
				customer.ClientId,
				customer.ContactId,
				string.Empty,
				string.Empty,
				customer.AddressId,
				string.Empty,
				string.Empty,
				adminUserId,
				title,
				estimateNumber,
				string.Empty,
				statusId,
				now,
				validFor,
				customer.AddressId,
				false,
				now,
				adminUserId,
				0,
				false,
				"A",
				string.Empty,
				0,
				now,
				now,
				now,
				false,
				now,
				now,
				now,
				now,
				customer.AddressId,
				customer.DepartmentId,
				0,
				adminUserId,
				comment,
				customer.ContactId,
				string.Empty,
				null,
				null,
				null,
				null,
				null);

			if (estimateId <= 0)
			{
				return;
			}

			SetEstimateNumber(estimateId, estimateNumber);

			long estimateItemId = EstimatesBasePage.Estimate_Item_Insert(
				companyId,
				estimateId,
				sampleType.ItemTypeCode,
				true,
				0,
				0);

			if (estimateItemId <= 0)
			{
				return;
			}

			EstimatesBasePage.estimate_item_details_insert(
				companyId,
				estimateId,
				estimateItemId,
				sampleType.ItemTypeCode);

			NewCompanySampleEstimateItemBodies.SeedForItem(
				companyId,
				adminUserId,
				estimateItemId,
				sampleType.ItemTypeCode,
				"Sample - " + sampleType.DisplayName);

			EstimatesBasePage.estimate_item_details_update(
				companyId,
				estimateId,
				estimateItemId,
				sampleType.ItemTypeCode,
				1000,
				0,
				0,
				0,
				"N",
				"N",
				"N",
				"N",
				"N",
				"N",
				"N");

			MarkSampleItemIncomplete(estimateItemId);
		}

		private static void SetEstimateNumber(long estimateId, string estimateNumber)
		{
			if (estimateId <= 0 || string.IsNullOrEmpty(estimateNumber))
			{
				return;
			}

			commonClass cmn = new commonClass();
			SqlCommand command = new SqlCommand(
				"UPDATE tb_estimate SET EstimateNumber = @estimateNumber WHERE EstimateID = @estimateId AND (EstimateNumber IS NULL OR LTRIM(RTRIM(EstimateNumber)) = '')",
				cmn.openConnection());
			command.Parameters.AddWithValue("@estimateId", estimateId);
			command.Parameters.AddWithValue("@estimateNumber", estimateNumber);
			try
			{
				command.ExecuteNonQuery();
			}
			finally
			{
				cmn.closeConnection();
			}
		}

		private static void MarkSampleItemIncomplete(long estimateItemId)
		{
			commonClass cmn = new commonClass();
			SqlCommand command = new SqlCommand(
				"UPDATE tb_estimateitem SET IsItemCompleted = 0 WHERE EstimateItemID = @estimateItemId",
				cmn.openConnection());
			command.Parameters.AddWithValue("@estimateItemId", estimateItemId);
			try
			{
				command.ExecuteNonQuery();
			}
			finally
			{
				cmn.closeConnection();
			}
		}

		private static bool HasSampleEstimates(int companyId)
		{
			commonClass cmn = new commonClass();
			SqlCommand command = new SqlCommand(@"
SELECT COUNT(1)
FROM tb_estimate
WHERE CompanyID = @companyId
	AND ISNULL(IsDeleted, 0) = 0
	AND (
		Comments LIKE @marker
		OR EstimateNumber LIKE @demoPrefix
	)", cmn.openConnection());
			command.Parameters.AddWithValue("@companyId", companyId);
			command.Parameters.AddWithValue("@marker", "%" + SampleMarkerComment + "%");
			command.Parameters.AddWithValue("@demoPrefix", DemoNumberPrefix + "%");
			try
			{
				object result = command.ExecuteScalar();
				return result != null && result != DBNull.Value && Convert.ToInt32(result) > 0;
			}
			finally
			{
				cmn.closeConnection();
			}
		}

		private static string EncodeField(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return string.Empty;
			}

			return value.Replace("'", "%27").Replace("\"", "%22");
		}

		private static SampleCustomerContext LoadSampleCustomer(int companyId)
		{
			string encodedCustomerName = EncodeField("Test Customer");
			string plainCustomerName = "Test Customer";

			commonClass cmn = new commonClass();
			SqlCommand command = new SqlCommand(@"
SELECT TOP 1
	c.clientID,
	ISNULL(c.AddressID, 0) AS AddressID,
	ISNULL(ct.contactId, 0) AS ContactId,
	ISNULL(d.DeptID, 0) AS DepartmentId
FROM tb_client c
OUTER APPLY (
	SELECT TOP 1 contactId
	FROM tb_contact
	WHERE ClientID = c.clientID
		AND companyID = c.companyID
		AND ISNULL(isDelete, 0) = 0
	ORDER BY CASE WHEN ISNULL(DefaultContact, 0) = 1 THEN 0 ELSE 1 END, contactId
) ct
OUTER APPLY (
	SELECT TOP 1 DeptID
	FROM tb_Department
	WHERE CustomerID = c.clientID
		AND CompanyID = c.companyID
		AND ISNULL(IsDeleted, 0) = 0
	ORDER BY CASE WHEN ISNULL(IsDefault, 0) = 1 THEN 0 ELSE 1 END, DeptID
) d
WHERE c.companyID = @companyId
	AND c.companytype = 'Customer'
	AND ISNULL(c.isdelete, 0) = 0
	AND (
		LTRIM(RTRIM(c.clientname)) = @clientName
		OR LTRIM(RTRIM(c.clientname)) = @clientNamePlain
	)
ORDER BY CASE
	WHEN LTRIM(RTRIM(c.clientname)) IN (@clientName, @clientNamePlain) THEN 0
	ELSE 1
END, c.clientID", cmn.openConnection());
			command.Parameters.AddWithValue("@companyId", companyId);
			command.Parameters.AddWithValue("@clientName", encodedCustomerName);
			command.Parameters.AddWithValue("@clientNamePlain", plainCustomerName);

			try
			{
				using (SqlDataReader reader = command.ExecuteReader())
				{
					if (reader.Read())
					{
						return ReadSampleCustomerContext(reader);
					}
				}

				using (SqlCommand fallbackCommand = new SqlCommand(@"
SELECT TOP 1
	c.clientID,
	ISNULL(c.AddressID, 0) AS AddressID,
	ISNULL(ct.contactId, 0) AS ContactId,
	ISNULL(d.DeptID, 0) AS DepartmentId
FROM tb_client c
OUTER APPLY (
	SELECT TOP 1 contactId
	FROM tb_contact
	WHERE ClientID = c.clientID AND companyID = c.companyID AND ISNULL(isDelete, 0) = 0
	ORDER BY contactId
) ct
OUTER APPLY (
	SELECT TOP 1 DeptID
	FROM tb_Department
	WHERE CustomerID = c.clientID AND CompanyID = c.companyID AND ISNULL(IsDeleted, 0) = 0
	ORDER BY DeptID
) d
WHERE c.companyID = @companyId AND c.companytype = 'Customer' AND ISNULL(c.isdelete, 0) = 0
ORDER BY c.clientID", cmn.openConnection()))
				{
					fallbackCommand.Parameters.AddWithValue("@companyId", companyId);
					using (SqlDataReader fallbackReader = fallbackCommand.ExecuteReader())
					{
						if (!fallbackReader.Read())
						{
							return null;
						}

						return ReadSampleCustomerContext(fallbackReader);
					}
				}
			}
			finally
			{
				cmn.closeConnection();
			}
		}

		private static SampleCustomerContext ReadSampleCustomerContext(SqlDataReader reader)
		{
			int clientId = Convert.ToInt32(reader["clientID"]);
			long addressId = Convert.ToInt64(reader["AddressID"]);
			long contactId = Convert.ToInt64(reader["ContactId"]);
			long departmentId = Convert.ToInt64(reader["DepartmentId"]);
			if (clientId <= 0)
			{
				return null;
			}

			return new SampleCustomerContext(clientId, contactId, addressId, departmentId);
		}

		private static int GetDefaultEstimateStatusId(int companyId)
		{
			commonClass cmn = new commonClass();
			SqlCommand command = new SqlCommand(@"
SELECT TOP 1 StatusID
FROM tb_EstimateStatus
WHERE companyid = @companyId
	AND ISNULL(IsDeleted, 0) = 0
	AND ISNULL(Estimate, 0) = 1
ORDER BY ISNULL(EstimateDefault, 0) DESC, StatusID", cmn.openConnection());
			command.Parameters.AddWithValue("@companyId", companyId);

			try
			{
				object result = command.ExecuteScalar();
				if (result == null || result == DBNull.Value)
				{
					return 0;
				}

				return Convert.ToInt32(result);
			}
			finally
			{
				cmn.closeConnection();
			}
		}

		private static int GetDefaultValidForDays(int companyId)
		{
			commonClass cmn = new commonClass();
			SqlCommand command = new SqlCommand(@"
SELECT TOP 1 ISNULL(ValidFor, 0)
FROM tb_defaultsettings
WHERE CompanyID = @companyId AND ISNULL(IsDeleted, 0) = 0", cmn.openConnection());
			command.Parameters.AddWithValue("@companyId", companyId);

			try
			{
				object result = command.ExecuteScalar();
				if (result == null || result == DBNull.Value)
				{
					return 0;
				}

				int validFor = Convert.ToInt32(result);
				return validFor > 0 ? validFor : 0;
			}
			finally
			{
				cmn.closeConnection();
			}
		}

		private sealed class SampleEstimateType
		{
			public SampleEstimateType(string itemTypeCode, string displayName)
			{
				this.ItemTypeCode = itemTypeCode;
				this.DisplayName = displayName;
			}

			public string ItemTypeCode { get; private set; }
			public string DisplayName { get; private set; }
		}

		private sealed class SampleCustomerContext
		{
			public SampleCustomerContext(int clientId, long contactId, long addressId, long departmentId)
			{
				this.ClientId = clientId;
				this.ContactId = contactId;
				this.AddressId = addressId;
				this.DepartmentId = departmentId;
			}

			public int ClientId { get; private set; }
			public long ContactId { get; private set; }
			public long AddressId { get; private set; }
			public long DepartmentId { get; private set; }
		}
	}
}
