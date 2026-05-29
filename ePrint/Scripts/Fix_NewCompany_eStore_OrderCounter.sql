-- eStore B2B checkout: WS_B2B_Insert_OrdersDetails_MIS builds SystemOrderNumber from
-- tb_LastCounter WHERE ModuleType = 'o'. Missing row => NULL SystemOrderNumber => INSERT fails.

USE eprint_demo;
GO

INSERT INTO dbo.tb_LastCounter (CompanyID, ModuleType, LastCounter)
SELECT c.CompanyID, N'o', 0
FROM dbo.tb_Company c
WHERE NOT EXISTS (
    SELECT 1
    FROM dbo.tb_LastCounter lc
    WHERE lc.CompanyID = c.CompanyID
      AND lc.ModuleType = N'o'
);
GO
