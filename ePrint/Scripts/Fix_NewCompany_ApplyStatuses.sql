/*
  Repair tenants where sign-up failed during NewCompanyDefaultSeeds.ApplyStatuses
  (invalid multi-row INSERT column counts). Re-runs the corrected status seed only.
*/
SET NOCOUNT ON;

DECLARE @CompanyId INT = NULL; -- set e.g. 2174, or NULL for all incomplete tenants

IF OBJECT_ID('tempdb..#Incomplete') IS NOT NULL DROP TABLE #Incomplete;
SELECT c.companyid INTO #Incomplete
FROM dbo.tb_company c
WHERE (@CompanyId IS NULL OR c.companyid = @CompanyId)
	AND NOT EXISTS (SELECT 1 FROM dbo.tb_EstimateStatus es WHERE es.companyid = c.companyid);

SELECT companyid AS CompanyIdToRepair FROM #Incomplete ORDER BY companyid;

INSERT INTO dbo.tb_EstimateStatus (
	CompanyID, StatusTitle, UserFriendlyName, IsDefault, Estimate, EstimateDefault, Job, JobDefault,
	Invoice, InvoiceDefault, Delivery, DeliveryDefault, Purchase, PurchaseDefault, Orders, OrdersDefault)
SELECT c.companyid, v.StatusTitle, v.UserFriendlyName, v.IsDefault, v.Estimate, v.EstimateDefault, v.Job, v.JobDefault,
	v.Invoice, v.InvoiceDefault, v.Delivery, v.DeliveryDefault, v.Purchase, v.PurchaseDefault, v.Orders, v.OrdersDefault
FROM #Incomplete c
CROSS APPLY (VALUES
	(N'In Progress', N'In Progress', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
	(N'Completed', N'Completed', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
	(N'Ready for Invoice', N'Ready for Invoice', 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0),
	(N'On Hold', N'On Hold', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
	(N'Approved', N'Approved', 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0),
	(N'Not Approved', N'Not Approved', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
	(N'Press', N'Press', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
	(N'Requested', N'Requested', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
	(N'In Production', N'In Production', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
	(N'RFQ', N'RFQ', 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
	(N'Cancelled', N'Cancelled', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
	(N'New Del. Note', N'New Del. Note', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0),
	(N'Awaiting Authorization', N'Awaiting Authorization', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0),
	(N'Locked', N'Locked', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
) v(StatusTitle, UserFriendlyName, IsDefault, Estimate, EstimateDefault, Job, JobDefault,
	Invoice, InvoiceDefault, Delivery, DeliveryDefault, Purchase, PurchaseDefault, Orders, OrdersDefault);

-- Other single-row status tables (same as ApplyStatuses tail in C#)
INSERT INTO dbo.tb_AccountStatus (CompanyID, StatusTitle)
SELECT c.companyid, N'Accounts Clear' FROM #Incomplete c
WHERE NOT EXISTS (SELECT 1 FROM dbo.tb_AccountStatus a WHERE a.CompanyID = c.companyid);

INSERT INTO dbo.tb_contractstatus (contractstatus, languagename, companyid)
SELECT N'Active', N'English', c.companyid FROM #Incomplete c
WHERE NOT EXISTS (SELECT 1 FROM dbo.tb_contractstatus x WHERE x.companyid = c.companyid);

INSERT INTO dbo.tb_assetstatus (assetstatus, companyid, languagename)
SELECT N'Active', c.companyid, N'English' FROM #Incomplete c
WHERE NOT EXISTS (SELECT 1 FROM dbo.tb_assetstatus x WHERE x.companyid = c.companyid);

INSERT INTO dbo.tb_leadstatus (leadstatusname, companyid, languagename)
SELECT N'New', c.companyid, N'English' FROM #Incomplete c
WHERE NOT EXISTS (SELECT 1 FROM dbo.tb_leadstatus x WHERE x.companyid = c.companyid);

INSERT INTO dbo.tb_taskstatus (taskStatus, companyID, languagename)
SELECT N'Open', c.companyid, N'English' FROM #Incomplete c
WHERE NOT EXISTS (SELECT 1 FROM dbo.tb_taskstatus x WHERE x.companyID = c.companyid);

INSERT INTO dbo.tb_ticketstatus (companyid, ticketstatus, languagename)
SELECT c.companyid, N'Open', N'English' FROM #Incomplete c
WHERE NOT EXISTS (SELECT 1 FROM dbo.tb_ticketstatus x WHERE x.companyid = c.companyid);

INSERT INTO dbo.tb_solutionstatus (companyid, solutionStatus, languagename)
SELECT c.companyid, N'Draft', N'English' FROM #Incomplete c
WHERE NOT EXISTS (SELECT 1 FROM dbo.tb_solutionstatus x WHERE x.companyid = c.companyid);

INSERT INTO dbo.tb_campaignStatus (companyId, campaignStatus, languagename)
SELECT c.companyid, N'Planned', N'English' FROM #Incomplete c
WHERE NOT EXISTS (SELECT 1 FROM dbo.tb_campaignStatus x WHERE x.companyId = c.companyid);

PRINT 'Done. Re-run app sign-up repair (RepairNewCompanySetup) for customize views / CRM sample data if needed.';
