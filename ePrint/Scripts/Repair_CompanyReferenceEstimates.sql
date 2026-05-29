-- Re-seed the four reference estimates from company 2144 for an existing tenant.
-- Requires: sample CRM customer, plant settings, and admin user.
-- Run from the app via registrationClass.RepairReferenceEstimates(companyId) after deploy, or register anew.

DECLARE @targetCompanyId int = 2174;

IF NOT EXISTS (SELECT 1 FROM tb_company WHERE companyid = @targetCompanyId)
BEGIN
	RAISERROR('Target company does not exist.', 16, 1);
	RETURN;
END

IF EXISTS (
	SELECT 1 FROM tb_estimate
	WHERE CompanyID = @targetCompanyId
		AND ISNULL(IsDeleted, 0) = 0
		AND Comments LIKE N'%Registration reference estimate%')
BEGIN
	PRINT 'Reference estimates already exist. Delete them first to re-run SQL-only repair, or use RepairReferenceEstimates in the app.';
	RETURN;
END

PRINT 'Use registrationClass.RepairReferenceEstimates(' + CAST(@targetCompanyId AS varchar(20)) + ') after building the site — copy uses PC_estimate_copy_estimate_insert_new and pc_estimate_copy_all.';
