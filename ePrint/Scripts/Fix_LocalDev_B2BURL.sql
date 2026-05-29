-- Local dev: all eStore URLs should point at ePrint.WebStore (http://localhost:2222/).
-- CRM on http://localhost:1111 resolves HostName from Web.config (usually demo.eprintsoftware.com).

USE eprint_master;
GO

-- CRM (MIS) – used by ConnectionClass.B2BURL / B2CURL for yellow key, account create, etc.
UPDATE dbo.tb_MIS_AppSettings
SET B2BURL = 'http://localhost:2222/',
    B2CURL = 'http://localhost:2222/'
WHERE HostName = 'demo.eprintsoftware.com';
GO

-- eStore (B2B) – used when WebStore (port 2222) boots; SitePath was still demo.eprintsoftware.com
UPDATE dbo.tb_B2B_AppSettings
SET SitePath = 'http://localhost:2222/',
    SecureSitePath = 'http://localhost:2222/document/securedoc/',
    PublicDocPath = 'http://localhost:2222/document/'
WHERE HostName = 'demo.eprintsoftware.com';
GO

-- Tenant CRM DB – per-account URL saved when B2B eStore account was created
USE eprint_demo;
GO

UPDATE dbo.tb_Accounts
SET StoreURL = 'http://localhost:2222/'
WHERE StoreURL LIKE '%demo.eprintsoftware.com%'
   OR StoreURL LIKE '%eprintsoftware.com/store/accounts%';
GO
