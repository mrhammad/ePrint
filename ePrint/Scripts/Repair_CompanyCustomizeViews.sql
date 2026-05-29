-- Repair list views (tb_CustomizeView) for a tenant missing Customer/Estimate/Job grids.
-- Usage: set @targetCompanyId, optionally change @templateCompanyId (must have views seeded).

DECLARE @targetCompanyId int = 2174;
DECLARE @templateCompanyId int = 2186;

IF NOT EXISTS (SELECT 1 FROM tb_company WHERE companyid = @targetCompanyId)
BEGIN
	RAISERROR('Target company does not exist.', 16, 1);
	RETURN;
END

IF NOT EXISTS (SELECT 1 FROM tb_CustomizeView WHERE CompanyID = @templateCompanyId AND ISNULL(isDeleted, 0) = 0)
BEGIN
	RAISERROR('Template company has no CustomizeView rows. Use a company created after registration seeds.', 16, 1);
	RETURN;
END

INSERT INTO tb_CustomizeView (
	CompanyID, ViewName, ColumnNames, condition1, condition2, condition3, condition4, condition5,
	operator1, operator2, operator3, operator4, operator5, value1, value2, value3, value4, value5,
	isDeleted, CreatedBy, UpdatedBy, isDefault, SortedBy, SortDirection, PageName,
	isShowAllRecords, iszerothview, CondnalOpertr1, CondnalOpertr2, CondnalOpertr3, CondnalOpertr4, CustomerType,
	IsItemSelected, RecordsToDisplay)
SELECT
	@targetCompanyId, ViewName, ColumnNames, condition1, condition2, condition3, condition4, condition5,
	operator1, operator2, operator3, operator4, operator5, value1, value2, value3, value4, value5,
	isDeleted, CreatedBy, UpdatedBy, isDefault, SortedBy, SortDirection, PageName,
	isShowAllRecords, iszerothview, CondnalOpertr1, CondnalOpertr2, CondnalOpertr3, CondnalOpertr4, CustomerType,
	IsItemSelected, RecordsToDisplay
FROM tb_CustomizeView s
WHERE s.CompanyID = @templateCompanyId
	AND ISNULL(s.isDeleted, 0) = 0
	AND NOT EXISTS (
		SELECT 1
		FROM tb_CustomizeView d
		WHERE d.CompanyID = @targetCompanyId
			AND d.PageName = s.PageName
			AND d.ViewName = s.ViewName
			AND ISNULL(d.isDeleted, 0) = 0
	);

PRINT 'CustomizeView rows for company ' + CAST(@targetCompanyId AS varchar(20)) + ': ' +
	CAST((SELECT COUNT(*) FROM tb_CustomizeView WHERE CompanyID = @targetCompanyId AND ISNULL(isDeleted, 0) = 0) AS varchar(20));
