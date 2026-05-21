using System;
using System.Data.SqlClient;

namespace nmsCommon
{
	/// <summary>
	/// Inserts minimal estimate item detail rows so sample estimates open without errors in the UI.
	/// </summary>
	internal static class NewCompanySampleEstimateItemBodies
	{
		public static void SeedForItem(
			int companyId,
			int adminUserId,
			long estimateItemId,
			string itemTypeCode,
			string itemTitle)
		{
			if (companyId <= 0 || adminUserId <= 0 || estimateItemId <= 0 || string.IsNullOrEmpty(itemTypeCode))
			{
				return;
			}

			PlantResources plant = PlantResources.Load(companyId);
			if (plant == null)
			{
				return;
			}

			commonClass cmn = new commonClass();
			SqlConnection connection = cmn.openConnection();
			try
			{
				switch (itemTypeCode.ToUpperInvariant())
				{
					case "S":
						SeedDigitalSingleItem(connection, estimateItemId, adminUserId, itemTitle, plant);
						break;
					case "L":
						SeedLithoItem(connection, estimateItemId, adminUserId, itemTitle, plant);
						break;
					case "F":
						SeedLargeFormatItem(connection, estimateItemId, adminUserId, itemTitle, plant);
						break;
					case "O":
						SeedOutworkItem(connection, estimateItemId, adminUserId, itemTitle);
						break;
					case "U":
						SeedOtherCostItem(connection, companyId, estimateItemId, adminUserId, itemTitle, plant);
						break;
					case "W":
						SeedWarehouseItem(connection, estimateItemId, adminUserId, itemTitle, plant);
						break;
					case "Q":
						SeedQuickQuoteItem(connection, companyId, estimateItemId, adminUserId, itemTitle, plant);
						break;
				}
			}
			finally
			{
				cmn.closeConnection();
			}
		}

		private static void SeedDigitalSingleItem(SqlConnection connection, long estimateItemId, int userId, string itemTitle, PlantResources plant)
		{
			if (plant.DigitalPressId <= 0)
			{
				return;
			}

			Execute(connection, plant.DigitalPressId, @"
IF NOT EXISTS (SELECT 1 FROM tb_EstSingleItem WHERE EstimateItemID = @estimateItemId)
INSERT INTO tb_EstSingleItem (
	EstimateItemID, PressID, PressType, PaperID, PaperUnitPrice, IsPricePerPack, IsPaperSupplied,
	SetUpSpoilage, RunningSpoilage, Colour, IsDoubleSided, PrintSheetSizeID, IsSheetCustom, SheetHeight, SheetWidth,
	JobFlatSizeID, IsJobCustom, JobHeight, JobWidth, IsIncludeGutters, GutterHorizontal, GutterVertical,
	IsPressRestrictions, PrintLayout, PortraitValue, LandscapeValue, GuillotineID,
	IsAnyWarehouseItem, IsAnyOutwork, IsAnyOtherCost, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate, IsDeleted, ItemTitle)
VALUES (
	@estimateItemId, @pressId, N'D', @paperId, 0, 0, 0,
	0, 0, N'4/0', 0, @printSheetId, 0, 450, 320,
	@jobSizeId, 0, 297, 210, 0, 0, 0,
	0, N'L', 0, 0, @guillotineId,
	N'N', N'N', N'N', @userId, @userId, GETDATE(), GETDATE(), 0, @itemTitle)",
				estimateItemId, userId, itemTitle, plant);
		}

		private static void SeedLithoItem(SqlConnection connection, long estimateItemId, int userId, string itemTitle, PlantResources plant)
		{
			if (plant.LithoPressId <= 0)
			{
				return;
			}

			Execute(connection, plant.LithoPressId, @"
IF NOT EXISTS (SELECT 1 FROM tb_EstimateLitho WHERE EstimateItemID = @estimateItemId)
INSERT INTO tb_EstimateLitho (
	EstimateItemID, PressID, PaperID, IsPricePerPack, IsPaperSupplied, SetUpSpoilage, RunningSpoilage,
	sidesprinted, side1Color, side2Color, PlateID, Noofplates, NoofMakeReady, NoofWashup,
	PrintSheetSizeID, IsSheetCustom, SheetHeight, SheetWidth, JobFlatSizeID, IsJobCustom, JobHeight, JobWidth,
	IsIncludeGutters, GutterHorizontal, GutterVertical, IsPressRestrictions, PrintLayout, PortraitValue, LandscapeValue,
	GuillotineID, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate, IsDeleted, ItemTitle)
VALUES (
	@estimateItemId, @pressId, @paperId, 0, 0, 0, 0,
	N'Single', N'4', N'0', @plateId, N'1', N'1', N'1',
	@printSheetId, 0, 450, 320, @jobSizeId, 0, 297, 210,
	0, 0, 0, 0, N'L', 0, 0,
	@guillotineId, @userId, @userId, GETDATE(), GETDATE(), 0, @itemTitle)",
				estimateItemId, userId, itemTitle, plant);
		}

		private static void SeedLargeFormatItem(SqlConnection connection, long estimateItemId, int userId, string itemTitle, PlantResources plant)
		{
			if (plant.LargeFormatPressId <= 0)
			{
				return;
			}

			Execute(connection, plant.LargeFormatPressId, @"
IF NOT EXISTS (SELECT 1 FROM tb_EstLargeItem WHERE EstimateItemID = @estimateItemId)
INSERT INTO tb_EstLargeItem (
	EstimateItemID, PressID, PressType, PaperID, IsPricePerPack, IsPaperSupplied, SetUpSpoilage, RunningSpoilage,
	Colour, IsDoubleSided, PrintSheetSizeID, IsSheetCustom, SheetHeight, SheetWidth, JobFlatSizeID, IsJobCustom,
	JobHeight, JobWidth, IsIncludeGutters, GutterHorizontal, GutterVertical, IsPressRestrictions, PrintLayout,
	PortraitValue, LandscapeValue, GuillotineID, PrintQuality, InkCoverageSide1, InkCoverageSide2,
	IsAnyWarehouseItem, IsAnyOutwork, IsAnyOtherCost, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate, IsDeleted, ItemTitle)
VALUES (
	@estimateItemId, @pressId, N'L', @paperId, 0, 0, 0, 0,
	N'4/0', 0, @printSheetId, 0, 450, 320, @jobSizeId, 0,
	297, 210, 0, 0, 0, 0, N'L',
	0, 0, @largeGuillotineId, N'medium', 100, 100,
	N'N', N'N', N'N', @userId, @userId, GETDATE(), GETDATE(), 0, @itemTitle)",
				estimateItemId, userId, itemTitle, plant);
		}

		private static void SeedOutworkItem(SqlConnection connection, long estimateItemId, int userId, string itemTitle)
		{
			Execute(connection, 0, @"
IF NOT EXISTS (SELECT 1 FROM tb_EstOutwork WHERE EstimateItemID = @estimateItemId AND ISNULL(IsDeleted, 0) = 0)
INSERT INTO tb_EstOutwork (
	EstimateItemID, CostingType, RFQReturnDate, JobCompletionDate, ItemTitle, CreatedBy, ModifiedBy,
	CreatedDate, ModifiedDate, IsDeleted, ItemDescription, ParentItemID, ParentItemType, PriceCatalogueID)
VALUES (
	@estimateItemId, N'S', GETDATE(), DATEADD(day, 7, GETDATE()), @itemTitle, @userId, @userId,
	GETDATE(), GETDATE(), 0, @itemTitle, 0, N'', 0)",
				estimateItemId, userId, itemTitle, null);
		}

		private static void SeedOtherCostItem(
			SqlConnection connection,
			int companyId,
			long estimateItemId,
			int userId,
			string itemTitle,
			PlantResources plant)
		{
			if (plant.OtherCostId <= 0)
			{
				return;
			}

			Execute(connection, 0, @"
IF NOT EXISTS (SELECT 1 FROM tb_EstOtherCost WHERE EstimateItemID = @estimateItemId AND ISNULL(IsDeleted, 0) = 0)
INSERT INTO tb_EstOtherCost (
	EstimateType, TypeID, EstimateItemID, OtherCostID, CalculationType, HoursOrQty, HourlyRate, UnitRate,
	SetUpTime, HourlyRunSpeed, Passes, Cost, MinimumCost, Markup, ItemTitle, CreatedBy, ModifiedBy,
	CreatedDate, IsDeleted, ItemDescription, TaxID)
VALUES (
	N'S', @otherCostId, @estimateItemId, @otherCostId, N'f', 1, 0, 0,
	0, 0, 0, 0, 0, 10, @itemTitle, @userId, @userId,
	GETDATE(), 0, @itemTitle, @taxId)",
				estimateItemId, userId, itemTitle, plant);
		}

		private static void SeedWarehouseItem(SqlConnection connection, long estimateItemId, int userId, string itemTitle, PlantResources plant)
		{
			if (plant.PaperInventoryId <= 0)
			{
				return;
			}

			Execute(connection, 0, @"
IF NOT EXISTS (SELECT 1 FROM tb_EstWarehouseItem WHERE EstimateItemID = @estimateItemId AND ISNULL(IsDeleted, 0) = 0)
INSERT INTO tb_EstWarehouseItem (
	EstimateItemID, WarehouseType, WarehouseTypeID, Quantity, UnitPrice, ItemTitle,
	CreatedBy, ModifiedBy, CreatedDate, IsDeleted, Markup, TaxID, PackedInQty, ParentItemID, ParentItemType,
	CostPrice1ExMarkup, TotalMarkupPrice1, ProfitMargin, SubTotal, Tax)
VALUES (
	@estimateItemId, N'I', @inventoryId, 1, 1, @itemTitle,
	@userId, @userId, GETDATE(), 0, 0, @taxId, 1, 0, N'',
	1, 1, 0, 1, 0)",
				estimateItemId, userId, itemTitle, plant);
		}

		private static void SeedQuickQuoteItem(
			SqlConnection connection,
			int companyId,
			long estimateItemId,
			int userId,
			string itemTitle,
			PlantResources plant)
		{
			long estimateId = 0;
			using (SqlCommand command = new SqlCommand(
				"SELECT EstimateID FROM tb_estimateitem WHERE EstimateItemID = @estimateItemId",
				connection))
			{
				command.Parameters.AddWithValue("@estimateItemId", estimateItemId);
				object result = command.ExecuteScalar();
				if (result != null && result != DBNull.Value)
				{
					estimateId = Convert.ToInt64(result);
				}
			}

			if (estimateId <= 0)
			{
				return;
			}

			Execute(connection, 0, @"
IF NOT EXISTS (SELECT 1 FROM tb_EstimateQuickQuote WHERE EstimateItemID = @estimateItemId AND ISNULL(isdeleted, 0) = 0)
INSERT INTO tb_EstimateQuickQuote (
	CompanyID, EstimateID, EstimateItemID, Quantity1, Quantity2, Quantity3, Quantity4,
	CostPrice1, CostPrice2, CostPrice3, CostPrice4, ItemTitle, Profitmargin, Subtotal1, Subtotal2, Subtotal3, Subtotal4,
	Tax, TaxID, SellingPrice, iscompleted, isdeleted, ItemDescription, AccountCodeID, CreatedDate)
VALUES (
	@companyId, @estimateId, @estimateItemId, 1, 0, 0, 0,
	1, 0, 0, 0, @itemTitle, 0, 1, 0, 0, 0,
	0, @taxId, 1, 0, 0, @itemTitle, 0, GETDATE())",
				estimateItemId, userId, itemTitle, plant, companyId, estimateId);
		}

		private static void Execute(
			SqlConnection connection,
			long pressId,
			string sql,
			long estimateItemId,
			int userId,
			string itemTitle,
			PlantResources plant,
			int companyId = 0,
			long estimateId = 0)
		{
			using (SqlCommand command = new SqlCommand(sql, connection))
			{
				command.Parameters.AddWithValue("@estimateItemId", estimateItemId);
				command.Parameters.AddWithValue("@userId", userId);
				command.Parameters.AddWithValue("@itemTitle", itemTitle ?? string.Empty);
				if (plant != null)
				{
					command.Parameters.AddWithValue("@pressId", pressId);
					command.Parameters.AddWithValue("@paperId", plant.PaperInventoryId);
					command.Parameters.AddWithValue("@plateId", plant.PlateInventoryId);
					command.Parameters.AddWithValue("@printSheetId", plant.PrintSheetSizeId);
					command.Parameters.AddWithValue("@jobSizeId", plant.JobSizeId);
					command.Parameters.AddWithValue("@guillotineId", plant.GuillotineId);
					command.Parameters.AddWithValue("@largeGuillotineId", plant.LargeGuillotineId);
					command.Parameters.AddWithValue("@inventoryId", plant.PaperInventoryId);
					command.Parameters.AddWithValue("@otherCostId", plant.OtherCostId);
					command.Parameters.AddWithValue("@taxId", plant.TaxId);
				}

				if (companyId > 0)
				{
					command.Parameters.AddWithValue("@companyId", companyId);
				}

				if (estimateId > 0)
				{
					command.Parameters.AddWithValue("@estimateId", estimateId);
				}

				command.ExecuteNonQuery();
			}
		}

		private sealed class PlantResources
		{
			public long DigitalPressId { get; private set; }
			public long LithoPressId { get; private set; }
			public long LargeFormatPressId { get; private set; }
			public long PaperInventoryId { get; private set; }
			public long PlateInventoryId { get; private set; }
			public int PrintSheetSizeId { get; private set; }
			public int JobSizeId { get; private set; }
			public long GuillotineId { get; private set; }
			public long LargeGuillotineId { get; private set; }
			public int OtherCostId { get; private set; }
			public int TaxId { get; private set; }

			public static PlantResources Load(int companyId)
			{
				commonClass cmn = new commonClass();
				SqlCommand command = new SqlCommand(@"
SELECT
	(SELECT TOP 1 DigitalPressID FROM tb_DigitalPress WHERE CompanyID = @companyId AND ISNULL(IsDeleted, 0) = 0 ORDER BY ISNULL(IsDefaultPress, 0) DESC, DigitalPressID) AS DigitalPressId,
	(SELECT TOP 1 LithoPressID FROM tb_LithoPress WHERE CompanyID = @companyId AND ISNULL(IsDeleted, 0) = 0 ORDER BY ISNULL(IsDefaultPress, 0) DESC, LithoPressID) AS LithoPressId,
	(SELECT TOP 1 PressID FROM tb_LargeFormatPress WHERE CompanyID = @companyId AND ISNULL(IsDeleted, 0) = 0 ORDER BY ISNULL(IsDefaultPress, 0) DESC, PressID) AS LargeFormatPressId,
	(SELECT TOP 1 InventoryID FROM tb_inventory WHERE CompanyID = @companyId AND InventoryCode = N'PAPER-130' AND ISNULL(IsDeleted, 0) = 0) AS PaperInventoryId,
	(SELECT TOP 1 InventoryID FROM tb_inventory WHERE CompanyID = @companyId AND InventoryCode = N'PLATE-1' AND ISNULL(IsDeleted, 0) = 0) AS PlateInventoryId,
	(SELECT TOP 1 PaperSizeID FROM tb_papersize WHERE companyid = @companyId AND PaperSizeName = N'SRA3' AND ISNULL(IsDeleted, 0) = 0) AS PrintSheetSizeId,
	(SELECT TOP 1 PaperSizeID FROM tb_papersize WHERE companyid = @companyId AND PaperSizeName = N'A4' AND ISNULL(IsDeleted, 0) = 0) AS JobSizeId,
	(SELECT TOP 1 GuillotineID FROM tb_Guillotine WHERE CompanyID = @companyId AND GuillotineName = N'Sample Guillotine' AND ISNULL(IsDeleted, 0) = 0) AS GuillotineId,
	(SELECT TOP 1 GuillotineID FROM tb_Guillotine WHERE CompanyID = @companyId AND GuillotineName = N'Sample Cutting Table' AND ISNULL(IsDeleted, 0) = 0) AS LargeGuillotineId,
	(SELECT TOP 1 OtherCostID FROM tb_OtherCost WHERE CompanyID = @companyId AND OtherCostName = N'Sample Admin Cost' AND ISNULL(IsDeleted, 0) = 0) AS OtherCostId,
	(SELECT TOP 1 TaxID FROM tb_taxrates WHERE CompanyID = @companyId AND ISNULL(IsDeleted, 0) = 0 ORDER BY TaxID) AS TaxId", cmn.openConnection());
				command.Parameters.AddWithValue("@companyId", companyId);

				try
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (!reader.Read())
						{
							return null;
						}

						PlantResources resources = new PlantResources();
						resources.DigitalPressId = ReadLong(reader, "DigitalPressId");
						resources.LithoPressId = ReadLong(reader, "LithoPressId");
						resources.LargeFormatPressId = ReadLong(reader, "LargeFormatPressId");
						resources.PaperInventoryId = ReadLong(reader, "PaperInventoryId");
						resources.PlateInventoryId = ReadLong(reader, "PlateInventoryId");
						resources.PrintSheetSizeId = (int)ReadLong(reader, "PrintSheetSizeId");
						resources.JobSizeId = (int)ReadLong(reader, "JobSizeId");
						resources.GuillotineId = ReadLong(reader, "GuillotineId");
						resources.LargeGuillotineId = ReadLong(reader, "LargeGuillotineId");
						resources.OtherCostId = (int)ReadLong(reader, "OtherCostId");
						resources.TaxId = (int)ReadLong(reader, "TaxId");

						if (resources.JobSizeId <= 0)
						{
							resources.JobSizeId = resources.PrintSheetSizeId;
						}

						if (resources.LargeGuillotineId <= 0)
						{
							resources.LargeGuillotineId = resources.GuillotineId;
						}

						return resources;
					}
				}
				finally
				{
					cmn.closeConnection();
				}
			}

			private static long ReadLong(SqlDataReader reader, string column)
			{
				object value = reader[column];
				if (value == null || value == DBNull.Value)
				{
					return 0;
				}

				return Convert.ToInt64(value);
			}
		}
	}
}
