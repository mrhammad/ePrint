/*
  Repair Outwork (O) supplier item description rows for tenants where DisplayOrder is NULL
  or only ItemTitle/Description were seeded. Prevents LoadSortedDivs from clearing the
  description panel on estimate_printbroker.aspx (add outwork item).
*/
SET NOCOUNT ON;

DECLARE @CompanyId INT = NULL; -- set e.g. 2156, or NULL for all companies missing O fields

;WITH Targets AS (
    SELECT c.CompanyID
    FROM dbo.tb_Company c
    WHERE (@CompanyId IS NULL OR c.CompanyID = @CompanyId)
      AND EXISTS (SELECT 1 FROM dbo.tb_ItemDescription d WHERE d.CompanyID = c.CompanyID)
)
INSERT INTO dbo.tb_ItemDescription (CompanyID, EstimateType, DatabaseFieldName, ScreenName, IsChecked, DisplayOrder)
SELECT t.CompanyID, v.EstimateType, v.DatabaseFieldName, v.ScreenName, 1, v.DisplayOrder
FROM Targets t
CROSS APPLY (VALUES
    (N'O', N'Artwork',      N'Artwork',      3),
    (N'O', N'Colour',       N'Colour',       4),
    (N'O', N'Size',         N'Size',         5),
    (N'O', N'Material',     N'Material',     6),
    (N'O', N'Delivery',     N'Delivery',     7),
    (N'O', N'Finishing',    N'Finishing',    8),
    (N'O', N'Proofs',       N'Proofs',       9),
    (N'O', N'Packing',      N'Packing',      10),
    (N'O', N'Notes',        N'Notes',        11),
    (N'O', N'Instructions', N'Instructions', 12)
) v(EstimateType, DatabaseFieldName, ScreenName, DisplayOrder)
WHERE NOT EXISTS (
    SELECT 1
    FROM dbo.tb_ItemDescription d
    WHERE d.CompanyID = t.CompanyID
      AND d.EstimateType = v.EstimateType
      AND d.DatabaseFieldName = v.DatabaseFieldName
);

UPDATE d SET DisplayOrder = 1
FROM dbo.tb_ItemDescription d
WHERE (@CompanyId IS NULL OR d.CompanyID = @CompanyId)
  AND d.EstimateType = N'O' AND d.DatabaseFieldName = N'ItemTitle' AND d.DisplayOrder IS NULL;

UPDATE d SET DisplayOrder = 2
FROM dbo.tb_ItemDescription d
WHERE (@CompanyId IS NULL OR d.CompanyID = @CompanyId)
  AND d.EstimateType = N'O' AND d.DatabaseFieldName = N'Description' AND d.DisplayOrder IS NULL;

SELECT CompanyID, EstimateType, DatabaseFieldName, ScreenName, IsChecked, DisplayOrder
FROM dbo.tb_ItemDescription
WHERE EstimateType = N'O'
  AND (@CompanyId IS NULL OR CompanyID = @CompanyId)
ORDER BY CompanyID, DisplayOrder, DatabaseFieldName;
