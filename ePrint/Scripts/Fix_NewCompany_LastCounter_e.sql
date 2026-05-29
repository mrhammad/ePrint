-- New registrations seeded ModuleType 'Estimate' but numbering uses 'e' (Get_Eprint_Number / settings_lastcounter_select).
INSERT INTO tb_LastCounter (CompanyID, ModuleType, LastCounter)
SELECT lc.CompanyID, N'e', lc.LastCounter
FROM tb_LastCounter lc
WHERE lc.ModuleType = N'Estimate'
  AND NOT EXISTS (
      SELECT 1 FROM tb_LastCounter x
      WHERE x.CompanyID = lc.CompanyID AND x.ModuleType = N'e');

INSERT INTO tb_LastCounter (CompanyID, ModuleType, LastCounter)
SELECT lc.CompanyID, N'j', lc.LastCounter
FROM tb_LastCounter lc
WHERE lc.ModuleType = N'Job'
  AND NOT EXISTS (
      SELECT 1 FROM tb_LastCounter x
      WHERE x.CompanyID = lc.CompanyID AND x.ModuleType = N'j');

INSERT INTO tb_LastCounter (CompanyID, ModuleType, LastCounter)
SELECT lc.CompanyID, N'i', lc.LastCounter
FROM tb_LastCounter lc
WHERE lc.ModuleType = N'Invoice'
  AND NOT EXISTS (
      SELECT 1 FROM tb_LastCounter x
      WHERE x.CompanyID = lc.CompanyID AND x.ModuleType = N'i');

INSERT INTO tb_LastCounter (CompanyID, ModuleType, LastCounter)
SELECT DISTINCT lc.CompanyID, N'p', 0
FROM tb_LastCounter lc
WHERE NOT EXISTS (
      SELECT 1 FROM tb_LastCounter x
      WHERE x.CompanyID = lc.CompanyID AND x.ModuleType = N'p');

INSERT INTO tb_LastCounter (CompanyID, ModuleType, LastCounter)
SELECT DISTINCT lc.CompanyID, N'd', 0
FROM tb_LastCounter lc
WHERE NOT EXISTS (
      SELECT 1 FROM tb_LastCounter x
      WHERE x.CompanyID = lc.CompanyID AND x.ModuleType = N'd');
