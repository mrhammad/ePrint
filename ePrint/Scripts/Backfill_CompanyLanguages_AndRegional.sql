-- Backfill tb_Languages (US/Canada English + UK English) and UK regional defaults
-- for companies created before registration seeding was updated.
-- Run per company or set @companyId to 0 to process all companies missing languages.

DECLARE @companyId int = 0; -- set to target company, or 0 for all missing
DECLARE @timezoneId int = 102;
DECLARE @dateFormat nvarchar(20) = N'dd/mm/yyyy';
DECLARE @fiscalYear int = YEAR(GETDATE());
IF MONTH(GETDATE()) < 7 SET @fiscalYear = @fiscalYear - 1;
DECLARE @fiscalFrom datetime = DATEFROMPARTS(@fiscalYear, 7, 1);
DECLARE @fiscalTo datetime = DATEFROMPARTS(@fiscalYear + 1, 6, 1);

DECLARE @targets TABLE (CompanyID int PRIMARY KEY);
INSERT INTO @targets (CompanyID)
SELECT c.companyid
FROM tb_company c
WHERE c.companyid > 0
  AND (@companyId = 0 OR c.companyid = @companyId)
  AND NOT EXISTS (
    SELECT 1 FROM tb_Languages l
    WHERE l.CompanyID = c.companyid AND l.Languages = N'UK English' AND l.IsDeleted = 0);

DECLARE @cid int;
DECLARE c CURSOR LOCAL FAST_FORWARD FOR SELECT CompanyID FROM @targets;
OPEN c;
FETCH NEXT FROM c INTO @cid;
WHILE @@FETCH_STATUS = 0
BEGIN
    IF NOT EXISTS (SELECT 1 FROM tb_Languages WHERE CompanyID = @cid AND Languages = N'US/Canada English' AND IsDeleted = 0)
        INSERT INTO tb_Languages (CompanyID, Languages, CreatedDate, IsDeleted)
        VALUES (@cid, N'US/Canada English', GETDATE(), 0);

    IF NOT EXISTS (SELECT 1 FROM tb_Languages WHERE CompanyID = @cid AND Languages = N'UK English' AND IsDeleted = 0)
        INSERT INTO tb_Languages (CompanyID, Languages, CreatedDate, IsDeleted)
        VALUES (@cid, N'UK English', GETDATE(), 0);

    DECLARE @ukLanguageId int;
    SELECT @ukLanguageId = LanguageID FROM tb_Languages
    WHERE CompanyID = @cid AND Languages = N'UK English' AND IsDeleted = 0;

    IF NOT EXISTS (SELECT 1 FROM tb_RegionalSettings WHERE CompanyID = @cid AND IsDeleted = 0)
        INSERT INTO tb_RegionalSettings (
            CompanyID, LanguageID, Colour, Organisation, State, Centre, PostCode, Metre, Weight, PaperMeasure,
            PageTitle, CompanyTitle, CreatedDate, IsDeleted, DateFormat, TimeZoneID, Roundoff, FisCalFrom, FisCalTo,
            IsDisplayCostCentre, GeneralWeight, PaperMaterial)
        SELECT @cid, @ukLanguageId, N'Color', N'Organisation', N'State', N'Centre', N'Post Code', N'Metre', N'gsm', N'mm',
            co.companyname, co.companyname, GETDATE(), 0, @dateFormat, @timezoneId, 2, @fiscalFrom, @fiscalTo, 1, N'lbs', N'Micron'
        FROM tb_company co WHERE co.companyid = @cid;
    ELSE
        UPDATE rs SET
            LanguageID = @ukLanguageId,
            Weight = ISNULL(NULLIF(RTRIM(rs.Weight), N''), N'gsm'),
            PaperMeasure = ISNULL(NULLIF(RTRIM(rs.PaperMeasure), N''), N'mm'),
            Metre = ISNULL(NULLIF(RTRIM(rs.Metre), N''), N'Metre'),
            GeneralWeight = ISNULL(NULLIF(RTRIM(rs.GeneralWeight), N''), N'lbs'),
            PaperMaterial = ISNULL(NULLIF(RTRIM(rs.PaperMaterial), N''), N'Micron')
        FROM tb_RegionalSettings rs
        WHERE rs.CompanyID = @cid AND rs.IsDeleted = 0;

    FETCH NEXT FROM c INTO @cid;
END
CLOSE c;
DEALLOCATE c;
