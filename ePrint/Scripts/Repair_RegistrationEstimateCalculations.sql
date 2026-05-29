-- Backfill missing calculation rows on registration sample estimates (S/L items).
SET NOCOUNT ON;

DECLARE @pairs TABLE (
    RefEstimateId int NOT NULL,
    SeedEstimateId int NOT NULL
);

INSERT @pairs (RefEstimateId, SeedEstimateId)
SELECT e.EstimateID, s.EstimateID
FROM tb_estimate e
INNER JOIN tb_estimate s
    ON s.Comments = N'Registration sample estimate (' + e.EstimateNumber + N')'
   AND ISNULL(s.IsDeleted, 0) = 0
WHERE e.CompanyID = 2144
  AND s.CompanyID IN (2144, 2150, 2153)
  AND e.EstimateNumber IN (
      N'EST-0000241', N'EST-0000281', N'EST-0000282', N'EST-0000284',
      N'EST-0000285', N'EST-0000287', N'EST-0000298', N'EST-0000299')
  AND ISNULL(e.IsDeleted, 0) = 0
  AND e.Comments NOT LIKE N'%Registration sample estimate%';

DECLARE @refItemId int, @seedItemId int, @itemType char(1), @newCalcId bigint;

DECLARE item_cursor CURSOR LOCAL FAST_FORWARD FOR
SELECT ri.EstimateItemID, si.EstimateItemID, ri.EstimateType
FROM @pairs p
INNER JOIN (
    SELECT EstimateID, EstimateItemID, EstimateType,
           ROW_NUMBER() OVER (PARTITION BY EstimateID ORDER BY EstimateItemID) AS rn
    FROM tb_EstimateItem WHERE ISNULL(IsDeleted, 0) = 0
) ri ON ri.EstimateID = p.RefEstimateId
INNER JOIN (
    SELECT EstimateID, EstimateItemID, EstimateType,
           ROW_NUMBER() OVER (PARTITION BY EstimateID ORDER BY EstimateItemID) AS rn
    FROM tb_EstimateItem WHERE ISNULL(IsDeleted, 0) = 0
) si ON si.EstimateID = p.SeedEstimateId AND si.rn = ri.rn AND si.EstimateType = ri.EstimateType
WHERE ri.EstimateType IN ('S', 'L');

OPEN item_cursor;
FETCH NEXT FROM item_cursor INTO @refItemId, @seedItemId, @itemType;

WHILE @@FETCH_STATUS = 0
BEGIN
    IF NOT EXISTS (SELECT 1 FROM tb_EstimateCalculation WHERE EstimateItemID = @seedItemId AND ISNULL(IsDeleted, 0) = 0)
    BEGIN
        INSERT INTO tb_EstimateCalculation (
            EstimateItemID, EstimateBookletItemID, PaperUnitPrice, PaperWeight, PaperMarkup, PressMarkUp, PressType,
            PressSetupCharge, PressMinimumRunningCharge, BlackChargeableRate, ColorChargeableRate, NoOfChargeableSheets,
            HourlyCharge, PrintPerHourLow, PrintPerHourMedium, PrintPerHourHigh, GuillotineSetupCharge,
            GuillotineMinimumRunningCharge, GuillotineMarkUp, GuillotineCostPerCut, GuillotinePaperWeight1,
            GuillotineMaximumThroat1, GuillotinePaperWeight2, GuillotineMaximumThroat2, GuillotinePaperWeight3,
            GuillotineMaximumThroat3, PaperPackedInQty, IsDeleted, OneSqCmInkCost, InkMarkup, PlateMarkup,
            MakeReadyMarkup, WashUpMarkup, EstimateLithoNCRItemID, EstimateLithoBookletItemID, PressPasses,
            WashupUnitprice, MakeReadyUnitprice, PlateUnitPrice, PaperMarkup2, PaperMarkup3, PaperMarkup4,
            PressMarkUp2, PressMarkUp3, PressMarkUp4, GuillotineMarkUp2, GuillotineMarkUp3, GuillotineMarkUp4,
            InkMarkup2, InkMarkup3, InkMarkup4, PlateMarkup2, PlateMarkup3, PlateMarkup4, MakeReadyMarkup2,
            MakeReadyMarkup3, MakeReadyMarkup4, WashUpMarkup2, WashUpMarkup3, WashUpMarkup4, CreatedDate,
            HourlyCharge2, HourlyCharge3, HourlyCharge4, OneSqCmInkMarkup)
        SELECT @seedItemId, EstimateBookletItemID, PaperUnitPrice, PaperWeight, PaperMarkup, PressMarkUp, PressType,
            PressSetupCharge, PressMinimumRunningCharge, BlackChargeableRate, ColorChargeableRate, NoOfChargeableSheets,
            HourlyCharge, PrintPerHourLow, PrintPerHourMedium, PrintPerHourHigh, GuillotineSetupCharge,
            GuillotineMinimumRunningCharge, GuillotineMarkUp, GuillotineCostPerCut, GuillotinePaperWeight1,
            GuillotineMaximumThroat1, GuillotinePaperWeight2, GuillotineMaximumThroat2, GuillotinePaperWeight3,
            GuillotineMaximumThroat3, PaperPackedInQty, IsDeleted, OneSqCmInkCost, InkMarkup, PlateMarkup,
            MakeReadyMarkup, WashUpMarkup, EstimateLithoNCRItemID, EstimateLithoBookletItemID, PressPasses,
            WashupUnitprice, MakeReadyUnitprice, PlateUnitPrice, PaperMarkup2, PaperMarkup3, PaperMarkup4,
            PressMarkUp2, PressMarkUp3, PressMarkUp4, GuillotineMarkUp2, GuillotineMarkUp3, GuillotineMarkUp4,
            InkMarkup2, InkMarkup3, InkMarkup4, PlateMarkup2, PlateMarkup3, PlateMarkup4, MakeReadyMarkup2,
            MakeReadyMarkup3, MakeReadyMarkup4, WashUpMarkup2, WashUpMarkup3, WashUpMarkup4, GETDATE(),
            HourlyCharge2, HourlyCharge3, HourlyCharge4, OneSqCmInkMarkup
        FROM tb_EstimateCalculation
        WHERE EstimateItemID = @refItemId AND ISNULL(IsDeleted, 0) = 0;

        IF @@ROWCOUNT = 0 AND @itemType = 'L'
        BEGIN
            INSERT INTO tb_EstimateCalculation (
                EstimateItemID, EstimateBookletItemID, PaperUnitPrice, PaperWeight, PaperMarkup, PressMarkUp, PressType,
                PressSetupCharge, PressMinimumRunningCharge, BlackChargeableRate, ColorChargeableRate, NoOfChargeableSheets,
                HourlyCharge, PrintPerHourLow, PrintPerHourMedium, PrintPerHourHigh, GuillotineSetupCharge,
                GuillotineMinimumRunningCharge, GuillotineMarkUp, GuillotineCostPerCut, GuillotinePaperWeight1,
                GuillotineMaximumThroat1, GuillotinePaperWeight2, GuillotineMaximumThroat2, GuillotinePaperWeight3,
                GuillotineMaximumThroat3, PaperPackedInQty, IsDeleted, OneSqCmInkCost, InkMarkup, PlateMarkup,
                MakeReadyMarkup, WashUpMarkup, EstimateLithoNCRItemID, EstimateLithoBookletItemID, PressPasses,
                WashupUnitprice, MakeReadyUnitprice, PlateUnitPrice, PaperMarkup2, PaperMarkup3, PaperMarkup4,
                PressMarkUp2, PressMarkUp3, PressMarkUp4, GuillotineMarkUp2, GuillotineMarkUp3, GuillotineMarkUp4,
                InkMarkup2, InkMarkup3, InkMarkup4, PlateMarkup2, PlateMarkup3, PlateMarkup4, MakeReadyMarkup2,
                MakeReadyMarkup3, MakeReadyMarkup4, WashUpMarkup2, WashUpMarkup3, WashUpMarkup4, CreatedDate,
                HourlyCharge2, HourlyCharge3, HourlyCharge4, OneSqCmInkMarkup)
            SELECT @seedItemId, ec.EstimateBookletItemID, ec.PaperUnitPrice, ec.PaperWeight, ec.PaperMarkup, ec.PressMarkUp, ec.PressType,
                ec.PressSetupCharge, ec.PressMinimumRunningCharge, ec.BlackChargeableRate, ec.ColorChargeableRate, ec.NoOfChargeableSheets,
                ec.HourlyCharge, ec.PrintPerHourLow, ec.PrintPerHourMedium, ec.PrintPerHourHigh, ec.GuillotineSetupCharge,
                ec.GuillotineMinimumRunningCharge, ec.GuillotineMarkUp, ec.GuillotineCostPerCut, ec.GuillotinePaperWeight1,
                ec.GuillotineMaximumThroat1, ec.GuillotinePaperWeight2, ec.GuillotineMaximumThroat2, ec.GuillotinePaperWeight3,
                ec.GuillotineMaximumThroat3, ec.PaperPackedInQty, ec.IsDeleted, ec.OneSqCmInkCost, ec.InkMarkup, ec.PlateMarkup,
                ec.MakeReadyMarkup, ec.WashUpMarkup, ec.EstimateLithoNCRItemID, ec.EstimateLithoBookletItemID, ec.PressPasses,
                ec.WashupUnitprice, ec.MakeReadyUnitprice, ec.PlateUnitPrice, ec.PaperMarkup2, ec.PaperMarkup3, ec.PaperMarkup4,
                ec.PressMarkUp2, ec.PressMarkUp3, ec.PressMarkUp4, ec.GuillotineMarkUp2, ec.GuillotineMarkUp3, ec.GuillotineMarkUp4,
                ec.InkMarkup2, ec.InkMarkup3, ec.InkMarkup4, ec.PlateMarkup2, ec.PlateMarkup3, ec.PlateMarkup4, ec.MakeReadyMarkup2,
                ec.MakeReadyMarkup3, ec.MakeReadyMarkup4, ec.WashUpMarkup2, ec.WashUpMarkup3, ec.WashUpMarkup4, GETDATE(),
                ec.HourlyCharge2, ec.HourlyCharge3, ec.HourlyCharge4, ec.OneSqCmInkMarkup
            FROM tb_EstimateCalculation ec
            INNER JOIN tb_EstLargeItemCalculation lc ON lc.EstimateCalculationID = ec.EstimateCalculationID
            WHERE lc.EstimateItemID = @refItemId AND ISNULL(ec.IsDeleted, 0) = 0;
        END

        SET @newCalcId = SCOPE_IDENTITY();

        IF @itemType = 'L'
           AND @newCalcId IS NOT NULL
           AND NOT EXISTS (SELECT 1 FROM tb_EstLargeItemCalculation WHERE EstimateItemID = @seedItemId AND ISNULL(IsDeleted, 0) = 0)
           AND EXISTS (SELECT 1 FROM tb_EstLargeItemCalculation WHERE EstimateItemID = @refItemId AND ISNULL(IsDeleted, 0) = 0)
        BEGIN
            INSERT INTO tb_EstLargeItemCalculation (
                EstimateCalculationID, EstimateItemID, MaterialID, MaterialUnitPrice, MaterialWeight,
                MaterialPackedInQty, MaterialMarkup1, MaterialMarkup2, MaterialMarkup3, MaterialMarkup4,
                IsDeleted, MaterialNo, CreatedDate)
            SELECT @newCalcId, @seedItemId, MaterialID, MaterialUnitPrice, MaterialWeight,
                   MaterialPackedInQty, MaterialMarkup1, MaterialMarkup2, MaterialMarkup3, MaterialMarkup4,
                   IsDeleted, MaterialNo, GETDATE()
            FROM tb_EstLargeItemCalculation
            WHERE EstimateItemID = @refItemId AND ISNULL(IsDeleted, 0) = 0;
        END
    END

    FETCH NEXT FROM item_cursor INTO @refItemId, @seedItemId, @itemType;
END

CLOSE item_cursor;
DEALLOCATE item_cursor;

SELECT e.CompanyID, e.EstimateNumber, ei.EstimateItemID, ei.EstimateType,
       (SELECT COUNT(*) FROM tb_EstimateCalculation c WHERE c.EstimateItemID = ei.EstimateItemID AND ISNULL(c.IsDeleted,0)=0) AS CalcRows,
       (SELECT COUNT(*) FROM tb_EstLargeItemCalculation lc WHERE lc.EstimateItemID = ei.EstimateItemID AND ISNULL(lc.IsDeleted,0)=0) AS LargeCalcRows
FROM tb_estimate e
INNER JOIN tb_EstimateItem ei ON ei.EstimateID = e.EstimateID
WHERE e.Comments LIKE N'%Registration sample estimate (%'
  AND e.CompanyID IN (2144, 2150, 2153)
  AND ei.EstimateType IN ('S', 'L')
ORDER BY e.CompanyID, e.EstimateNumber, ei.EstimateItemID;
