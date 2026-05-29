-- Assign estimate numbers to rows missing EstimateNumber (excluded from VW_Estimate_View).
SET NOCOUNT ON;

DECLARE @estimateId bigint, @companyId int, @estNum nvarchar(25);

DECLARE c CURSOR LOCAL FAST_FORWARD FOR
SELECT e.EstimateID, e.CompanyID
FROM tb_estimate e
WHERE ISNULL(e.IsDeleted, 0) = 0
  AND ISNULL(e.IsForInvoice, 0) = 0
  AND (e.EstimateNumber IS NULL OR LTRIM(RTRIM(e.EstimateNumber)) IN ('', '0'));

OPEN c;
FETCH NEXT FROM c INTO @estimateId, @companyId;

WHILE @@FETCH_STATUS = 0
BEGIN
    SET @estNum = dbo.Get_Eprint_Number(@companyId, 'e', 'EST', 0);

    UPDATE tb_estimate
    SET EstimateNumber = @estNum
    WHERE EstimateID = @estimateId;

    UPDATE tb_LastCounter
    SET LastCounter = LastCounter + 1
    WHERE CompanyID = @companyId AND ModuleType = 'e';

    FETCH NEXT FROM c INTO @estimateId, @companyId;
END

CLOSE c;
DEALLOCATE c;

SELECT e.CompanyID, e.EstimateID, e.EstimateNumber, e.EstimateTitle
FROM tb_estimate e
WHERE e.EstimateID IN (SELECT EstimateID FROM tb_estimate WHERE EstimateNumber IS NOT NULL)
  AND e.EstimateID IN (
      SELECT EstimateID FROM tb_estimate
      WHERE EstimateNumber IS NOT NULL
        AND ModifiedDate >= DATEADD(day, -1, GETDATE())
  )
ORDER BY e.EstimateID DESC;
