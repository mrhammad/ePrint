-- PixelPrint360 branding (Globo Technologies) — replace legacy Hexicom product name in MIS app settings.
-- Run against eprint_master. HostName must match Web.config HostName (e.g. demo.eprintsoftware.com for localhost dev).

USE eprint_master;
GO

UPDATE tb_MIS_AppSettings
SET CompanyName = N'PixelPrint360'
WHERE CompanyName IS NOT NULL
  AND CompanyName LIKE N'%hexicom%';
GO

-- Optional: set for localhost dev host if still missing or empty
UPDATE tb_MIS_AppSettings
SET CompanyName = N'PixelPrint360'
WHERE (HostName = N'demo.eprintsoftware.com' OR Host1 = N'demo.eprintsoftware.com')
  AND (CompanyName IS NULL OR LTRIM(RTRIM(CompanyName)) = N'');
GO
