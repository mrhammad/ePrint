-- Validates sample estimate item bodies open without empty detail rows.
-- Set @companyId to a tenant that has DEMO-* estimates (after registration or RepairNewCompanySetup).

DECLARE @companyId int = 0; -- e.g. new sign-up company id

IF @companyId <= 0
BEGIN
	SELECT TOP 1 @companyId = CompanyID
	FROM tb_estimate
	WHERE EstimateNumber LIKE N'DEMO-%' AND ISNULL(IsDeleted, 0) = 0
	ORDER BY CompanyID DESC;
END

IF @companyId <= 0
BEGIN
	RAISERROR('No DEMO estimates found. Register a new user first or set @companyId.', 16, 1);
	RETURN;
END

PRINT 'Validating company ' + CAST(@companyId AS varchar(20));

SELECT e.EstimateNumber, e.EstimateTitle, ei.EstimateItemID, ei.EstimateType,
	CASE ei.EstimateType
		WHEN 'S' THEN (SELECT COUNT(*) FROM tb_EstSingleItem x WHERE x.EstimateItemID = ei.EstimateItemID)
		WHEN 'L' THEN (SELECT COUNT(*) FROM tb_EstimateLitho x WHERE x.EstimateItemID = ei.EstimateItemID)
		WHEN 'F' THEN (SELECT COUNT(*) FROM tb_EstLargeItem x WHERE x.EstimateItemID = ei.EstimateItemID)
		WHEN 'O' THEN (SELECT COUNT(*) FROM tb_EstOutwork x WHERE x.EstimateItemID = ei.EstimateItemID AND ISNULL(x.IsDeleted,0)=0)
		WHEN 'U' THEN (SELECT COUNT(*) FROM tb_EstOtherCost x WHERE x.EstimateItemID = ei.EstimateItemID AND ISNULL(x.IsDeleted,0)=0)
		WHEN 'W' THEN (SELECT COUNT(*) FROM tb_EstWarehouseItem x WHERE x.EstimateItemID = ei.EstimateItemID AND ISNULL(x.IsDeleted,0)=0)
		WHEN 'Q' THEN (SELECT COUNT(*) FROM tb_EstimateQuickQuote x WHERE x.EstimateItemID = ei.EstimateItemID AND ISNULL(x.isdeleted,0)=0)
		ELSE -1
	END AS DetailRowCount
FROM tb_estimate e
INNER JOIN tb_estimateitem ei ON ei.EstimateID = e.EstimateID AND ISNULL(ei.IsDeleted, 0) = 0
WHERE e.CompanyID = @companyId
	AND ISNULL(e.IsDeleted, 0) = 0
	AND (e.EstimateNumber LIKE N'DEMO-%' OR e.Comments LIKE N'%Registration sample estimate%')
ORDER BY e.EstimateNumber;

SELECT N'Plant' AS ResourceType, COUNT(*) AS Cnt FROM tb_DigitalPress WHERE CompanyID = @companyId AND ISNULL(IsDeleted,0)=0
UNION ALL SELECT N'Litho', COUNT(*) FROM tb_LithoPress WHERE CompanyID = @companyId AND ISNULL(IsDeleted,0)=0
UNION ALL SELECT N'LargeFormat', COUNT(*) FROM tb_LargeFormatPress WHERE CompanyID = @companyId AND ISNULL(IsDeleted,0)=0
UNION ALL SELECT N'OtherCost', COUNT(*) FROM tb_OtherCost WHERE CompanyID = @companyId AND ISNULL(IsDeleted,0)=0
UNION ALL SELECT N'Paper', COUNT(*) FROM tb_inventory WHERE CompanyID = @companyId AND InventoryCode=N'PAPER-130' AND ISNULL(IsDeleted,0)=0;
