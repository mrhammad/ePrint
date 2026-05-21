-- Backfill detail rows for DEMO / registration sample estimate items.
DECLARE @companyId int = $(companyId); -- pass -v companyId=N, or 0 for all companies with DEMO estimates

DECLARE @targets TABLE (CompanyID int PRIMARY KEY);
IF ISNULL(@companyId, 0) > 0
	INSERT INTO @targets VALUES (@companyId);
ELSE
	INSERT INTO @targets (CompanyID)
	SELECT DISTINCT CompanyID FROM tb_estimate
	WHERE EstimateNumber LIKE N'DEMO-%' AND ISNULL(IsDeleted, 0) = 0;

DECLARE @cid int, @userId int, @digitalPress bigint, @lithoPress bigint, @lfPress bigint;
DECLARE @paper bigint, @plate bigint, @printSheet int, @jobSize int, @guillotine bigint, @lfGuillotine bigint, @otherCost int, @taxId int;

DECLARE tc CURSOR LOCAL FAST_FORWARD FOR SELECT CompanyID FROM @targets;
OPEN tc;
FETCH NEXT FROM tc INTO @cid;
WHILE @@FETCH_STATUS = 0
BEGIN
	SELECT @userId = (SELECT TOP 1 userid FROM tb_user WHERE companyid = @cid AND isadmin = 1 ORDER BY userid);
	IF @userId IS NULL SELECT @userId = (SELECT TOP 1 userid FROM tb_user WHERE companyid = @cid ORDER BY userid);

	SELECT @digitalPress = (SELECT TOP 1 DigitalPressID FROM tb_DigitalPress WHERE CompanyID = @cid AND ISNULL(IsDeleted,0)=0 ORDER BY ISNULL(IsDefaultPress,0) DESC, DigitalPressID);
	SELECT @lithoPress = (SELECT TOP 1 LithoPressID FROM tb_LithoPress WHERE CompanyID = @cid AND ISNULL(IsDeleted,0)=0 ORDER BY ISNULL(IsDefaultPress,0) DESC, LithoPressID);
	SELECT @lfPress = (SELECT TOP 1 PressID FROM tb_LargeFormatPress WHERE CompanyID = @cid AND ISNULL(IsDeleted,0)=0 ORDER BY ISNULL(IsDefaultPress,0) DESC, PressID);
	SELECT @paper = (SELECT TOP 1 InventoryID FROM tb_inventory WHERE CompanyID = @cid AND InventoryCode = N'PAPER-130' AND ISNULL(IsDeleted,0)=0);
	SELECT @plate = (SELECT TOP 1 InventoryID FROM tb_inventory WHERE CompanyID = @cid AND InventoryCode = N'PLATE-1' AND ISNULL(IsDeleted,0)=0);
	SELECT @printSheet = (SELECT TOP 1 PaperSizeID FROM tb_papersize WHERE companyid = @cid AND PaperSizeName = N'SRA3' AND ISNULL(IsDeleted,0)=0);
	SELECT @jobSize = (SELECT TOP 1 PaperSizeID FROM tb_papersize WHERE companyid = @cid AND PaperSizeName = N'A4' AND ISNULL(IsDeleted,0)=0);
	IF @jobSize IS NULL SET @jobSize = @printSheet;
	SELECT @guillotine = (SELECT TOP 1 GuillotineID FROM tb_Guillotine WHERE CompanyID = @cid AND GuillotineName = N'Sample Guillotine' AND ISNULL(IsDeleted,0)=0);
	SELECT @lfGuillotine = (SELECT TOP 1 GuillotineID FROM tb_Guillotine WHERE CompanyID = @cid AND GuillotineName = N'Sample Cutting Table' AND ISNULL(IsDeleted,0)=0);
	IF @lfGuillotine IS NULL SET @lfGuillotine = @guillotine;
	SELECT @otherCost = (SELECT TOP 1 OtherCostID FROM tb_OtherCost WHERE CompanyID = @cid AND OtherCostName = N'Sample Admin Cost' AND ISNULL(IsDeleted,0)=0);
	SELECT @taxId = (SELECT TOP 1 TaxID FROM tb_taxrates WHERE CompanyID = @cid AND ISNULL(IsDeleted,0)=0 ORDER BY TaxID);

	-- Digital (S)
	IF @digitalPress > 0 AND @paper > 0
		INSERT INTO tb_EstSingleItem (
			EstimateItemID, PressID, PressType, PaperID, PaperUnitPrice, IsPricePerPack, IsPaperSupplied,
			SetUpSpoilage, RunningSpoilage, Colour, IsDoubleSided, PrintSheetSizeID, IsSheetCustom, SheetHeight, SheetWidth,
			JobFlatSizeID, IsJobCustom, JobHeight, JobWidth, IsIncludeGutters, GutterHorizontal, GutterVertical,
			IsPressRestrictions, PrintLayout, PortraitValue, LandscapeValue, GuillotineID,
			IsAnyWarehouseItem, IsAnyOutwork, IsAnyOtherCost, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate, IsDeleted, ItemTitle)
		SELECT ei.EstimateItemID, @digitalPress, N'D', @paper, 0, 0, 0,
			0, 0, N'4/0', 0, @printSheet, 0, 450, 320,
			@jobSize, 0, 297, 210, 0, 0, 0,
			0, N'L', 0, 0, @guillotine,
			N'N', N'N', N'N', @userId, @userId, GETDATE(), GETDATE(), 0, e.EstimateTitle
		FROM tb_estimateitem ei
		INNER JOIN tb_estimate e ON e.EstimateID = ei.EstimateID AND e.CompanyID = @cid
		WHERE ei.EstimateType = N'S' AND ISNULL(ei.IsDeleted,0)=0
			AND (e.EstimateNumber LIKE N'DEMO-%' OR e.Comments LIKE N'%Registration sample estimate%')
			AND NOT EXISTS (SELECT 1 FROM tb_EstSingleItem x WHERE x.EstimateItemID = ei.EstimateItemID);

	-- Litho (L)
	IF @lithoPress > 0 AND @paper > 0 AND @plate > 0
		INSERT INTO tb_EstimateLitho (
			EstimateItemID, PressID, PaperID, IsPricePerPack, IsPaperSupplied, SetUpSpoilage, RunningSpoilage,
			sidesprinted, side1Color, side2Color, PlateID, Noofplates, NoofMakeReady, NoofWashup,
			PrintSheetSizeID, IsSheetCustom, SheetHeight, SheetWidth, JobFlatSizeID, IsJobCustom, JobHeight, JobWidth,
			IsIncludeGutters, GutterHorizontal, GutterVertical, IsPressRestrictions, PrintLayout, PortraitValue, LandscapeValue,
			GuillotineID, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate, IsDeleted, ItemTitle)
		SELECT ei.EstimateItemID, @lithoPress, @paper, 0, 0, 0, 0,
			N'Single', N'4', N'0', @plate, N'1', N'1', N'1',
			@printSheet, 0, 450, 320, @jobSize, 0, 297, 210,
			0, 0, 0, 0, N'L', 0, 0,
			@guillotine, @userId, @userId, GETDATE(), GETDATE(), 0, e.EstimateTitle
		FROM tb_estimateitem ei
		INNER JOIN tb_estimate e ON e.EstimateID = ei.EstimateID AND e.CompanyID = @cid
		WHERE ei.EstimateType = N'L' AND ISNULL(ei.IsDeleted,0)=0
			AND (e.EstimateNumber LIKE N'DEMO-%' OR e.Comments LIKE N'%Registration sample estimate%')
			AND NOT EXISTS (SELECT 1 FROM tb_EstimateLitho x WHERE x.EstimateItemID = ei.EstimateItemID);

	-- Large format (F)
	IF @lfPress > 0 AND @paper > 0
		INSERT INTO tb_EstLargeItem (
			EstimateItemID, PressID, PressType, PaperID, IsPricePerPack, IsPaperSupplied, SetUpSpoilage, RunningSpoilage,
			Colour, IsDoubleSided, PrintSheetSizeID, IsSheetCustom, SheetHeight, SheetWidth, JobFlatSizeID, IsJobCustom,
			JobHeight, JobWidth, IsIncludeGutters, GutterHorizontal, GutterVertical, IsPressRestrictions, PrintLayout,
			PortraitValue, LandscapeValue, GuillotineID, PrintQuality, InkCoverageSide1, InkCoverageSide2,
			IsAnyWarehouseItem, IsAnyOutwork, IsAnyOtherCost, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate, IsDeleted, ItemTitle)
		SELECT ei.EstimateItemID, @lfPress, N'L', @paper, 0, 0, 0, 0,
			N'4/0', 0, @printSheet, 0, 450, 320, @jobSize, 0,
			297, 210, 0, 0, 0, 0, N'L',
			0, 0, @lfGuillotine, N'medium', 100, 100,
			N'N', N'N', N'N', @userId, @userId, GETDATE(), GETDATE(), 0, e.EstimateTitle
		FROM tb_estimateitem ei
		INNER JOIN tb_estimate e ON e.EstimateID = ei.EstimateID AND e.CompanyID = @cid
		WHERE ei.EstimateType = N'F' AND ISNULL(ei.IsDeleted,0)=0
			AND (e.EstimateNumber LIKE N'DEMO-%' OR e.Comments LIKE N'%Registration sample estimate%')
			AND NOT EXISTS (SELECT 1 FROM tb_EstLargeItem x WHERE x.EstimateItemID = ei.EstimateItemID);

	-- Outwork (O)
	INSERT INTO tb_EstOutwork (
		EstimateItemID, CostingType, RFQReturnDate, JobCompletionDate, ItemTitle, CreatedBy, ModifiedBy,
		CreatedDate, ModifiedDate, IsDeleted, ItemDescription, ParentItemID, ParentItemType, PriceCatalogueID)
	SELECT ei.EstimateItemID, N'S', GETDATE(), DATEADD(day,7,GETDATE()), e.EstimateTitle, @userId, @userId,
		GETDATE(), GETDATE(), 0, e.EstimateTitle, 0, N'', 0
	FROM tb_estimateitem ei
	INNER JOIN tb_estimate e ON e.EstimateID = ei.EstimateID AND e.CompanyID = @cid
	WHERE ei.EstimateType = N'O' AND ISNULL(ei.IsDeleted,0)=0
		AND (e.EstimateNumber LIKE N'DEMO-%' OR e.Comments LIKE N'%Registration sample estimate%')
		AND NOT EXISTS (SELECT 1 FROM tb_EstOutwork x WHERE x.EstimateItemID = ei.EstimateItemID AND ISNULL(x.IsDeleted,0)=0);

	-- Other cost (U)
	IF @otherCost > 0
		INSERT INTO tb_EstOtherCost (
			EstimateType, TypeID, EstimateItemID, OtherCostID, CalculationType, HoursOrQty, HourlyRate, UnitRate,
			SetUpTime, HourlyRunSpeed, Passes, Cost, MinimumCost, Markup, ItemTitle, CreatedBy, ModifiedBy,
			CreatedDate, IsDeleted, ItemDescription, TaxID)
		SELECT N'S', @otherCost, ei.EstimateItemID, @otherCost, N'f', 1, 0, 0,
			0, 0, 0, 0, 0, 10, e.EstimateTitle, @userId, @userId,
			GETDATE(), 0, e.EstimateTitle, @taxId
		FROM tb_estimateitem ei
		INNER JOIN tb_estimate e ON e.EstimateID = ei.EstimateID AND e.CompanyID = @cid
		WHERE ei.EstimateType = N'U' AND ISNULL(ei.IsDeleted,0)=0
			AND (e.EstimateNumber LIKE N'DEMO-%' OR e.Comments LIKE N'%Registration sample estimate%')
			AND NOT EXISTS (SELECT 1 FROM tb_EstOtherCost x WHERE x.EstimateItemID = ei.EstimateItemID AND ISNULL(x.IsDeleted,0)=0);

	-- Warehouse (W)
	IF @paper > 0
		INSERT INTO tb_EstWarehouseItem (
			EstimateItemID, WarehouseType, WarehouseTypeID, Quantity, UnitPrice, ItemTitle,
			CreatedBy, ModifiedBy, CreatedDate, IsDeleted, Markup, TaxID, PackedInQty, ParentItemID, ParentItemType,
			CostPrice1ExMarkup, TotalMarkupPrice1, ProfitMargin, SubTotal, Tax)
		SELECT ei.EstimateItemID, N'I', @paper, 1, 1, e.EstimateTitle,
			@userId, @userId, GETDATE(), 0, 0, @taxId, 1, 0, N'',
			1, 1, 0, 1, 0
		FROM tb_estimateitem ei
		INNER JOIN tb_estimate e ON e.EstimateID = ei.EstimateID AND e.CompanyID = @cid
		WHERE ei.EstimateType = N'W' AND ISNULL(ei.IsDeleted,0)=0
			AND (e.EstimateNumber LIKE N'DEMO-%' OR e.Comments LIKE N'%Registration sample estimate%')
			AND NOT EXISTS (SELECT 1 FROM tb_EstWarehouseItem x WHERE x.EstimateItemID = ei.EstimateItemID AND ISNULL(x.IsDeleted,0)=0);

	-- Quick quote (Q)
	INSERT INTO tb_EstimateQuickQuote (
		CompanyID, EstimateID, EstimateItemID, Quantity1, Quantity2, Quantity3, Quantity4,
		CostPrice1, CostPrice2, CostPrice3, CostPrice4, ItemTitle, Profitmargin, Subtotal1, Subtotal2, Subtotal3, Subtotal4,
		Tax, TaxID, SellingPrice, iscompleted, isdeleted, ItemDescription, AccountCodeID, CreatedDate)
	SELECT @cid, e.EstimateID, ei.EstimateItemID, 1, 0, 0, 0,
		1, 0, 0, 0, e.EstimateTitle, 0, 1, 0, 0, 0,
		0, @taxId, 1, 0, 0, e.EstimateTitle, 0, GETDATE()
	FROM tb_estimateitem ei
	INNER JOIN tb_estimate e ON e.EstimateID = ei.EstimateID AND e.CompanyID = @cid
	WHERE ei.EstimateType = N'Q' AND ISNULL(ei.IsDeleted,0)=0
		AND (e.EstimateNumber LIKE N'DEMO-%' OR e.Comments LIKE N'%Registration sample estimate%')
		AND NOT EXISTS (SELECT 1 FROM tb_EstimateQuickQuote x WHERE x.EstimateItemID = ei.EstimateItemID AND ISNULL(x.isdeleted,0)=0);

	UPDATE ei SET IsItemCompleted = 0
	FROM tb_estimateitem ei
	INNER JOIN tb_estimate e ON e.EstimateID = ei.EstimateID AND e.CompanyID = @cid
	WHERE ISNULL(ei.IsDeleted, 0) = 0
		AND (e.EstimateNumber LIKE N'DEMO-%' OR e.Comments LIKE N'%Registration sample estimate%');

	FETCH NEXT FROM tc INTO @cid;
END
CLOSE tc; DEALLOCATE tc;

PRINT 'Sample estimate item bodies backfill complete.';
