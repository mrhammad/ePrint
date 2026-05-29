/*
  Fix Progress Estimate -> Job failures for new tenants:
  - NULL PONO: missing tb_LastCounter row for ModuleType 'p' (Get_Eprint_Number in PC_purchase_insert)
  - NULL ModuleID on tb_notes: side effect when PO insert fails
  - Optional: enable default Purchase / Delivery statuses used when raising POs from progress-to-job
*/
SET NOCOUNT ON;

DECLARE @CompanyId INT = NULL; -- e.g. 2165, or NULL for all companies missing counters

INSERT INTO dbo.tb_LastCounter (CompanyID, ModuleType, LastCounter)
SELECT c.CompanyID, v.ModuleType, 0
FROM dbo.tb_Company c
CROSS APPLY (VALUES (N'p'), (N'd')) v(ModuleType)
WHERE (@CompanyId IS NULL OR c.CompanyID = @CompanyId)
  AND NOT EXISTS (
      SELECT 1 FROM dbo.tb_LastCounter lc
      WHERE lc.CompanyID = c.CompanyID AND lc.ModuleType = v.ModuleType);

UPDATE s SET Purchase = 1, PurchaseDefault = 1
FROM dbo.tb_EstimateStatus s
WHERE (@CompanyId IS NULL OR s.companyid = @CompanyId)
  AND s.StatusTitle = N'Awaiting Authorization'
  AND NOT EXISTS (
      SELECT 1 FROM dbo.tb_EstimateStatus x
      WHERE x.companyid = s.companyid AND x.Purchase = 1);

UPDATE s SET Delivery = 1, DeliveryDefault = 1
FROM dbo.tb_EstimateStatus s
WHERE (@CompanyId IS NULL OR s.companyid = @CompanyId)
  AND s.StatusTitle = N'New Del. Note'
  AND NOT EXISTS (
      SELECT 1 FROM dbo.tb_EstimateStatus x
      WHERE x.companyid = s.companyid AND x.Delivery = 1);

SELECT c.CompanyID,
       dbo.Get_Eprint_Number(c.CompanyID, 'P', 'PO-', 0) AS SamplePONumber
FROM dbo.tb_Company c
WHERE (@CompanyId IS NULL OR c.CompanyID = @CompanyId)
  AND EXISTS (SELECT 1 FROM dbo.tb_LastCounter lc WHERE lc.CompanyID = c.CompanyID AND lc.ModuleType = N'p')
ORDER BY c.CompanyID;
