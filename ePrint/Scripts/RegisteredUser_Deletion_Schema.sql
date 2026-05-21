/*
================================================================================
  ePrint — Registered user / company deletion schema
================================================================================
  Database : CRM tenant DB (e.g. eprint_demo on localhost)
  Master DB: eprint_master — usually NOT touched for Sign Up on shared CRM DB

  Sign-up flow (app):
    crm_register_new          -> tb_company (+ rows copied from companyid = 0)
    crm_user_add_withAccessRights -> tb_user, tb_usertab, access rights
    CompleteNewCompanySetup   -> tb_RegionalSettings, NewCompanyDefaultSeeds, sample CRM

  App soft-delete (production):
    commonClass.DeleteThis      -> crm_user_delete
    commonClass.delete_company  -> crm_delete_company
    Settings UI                 -> PC_settings_user_delete

  There are NO foreign keys from tb_user/tb_company to child tables in SQL Server;
  all tenant data is scoped by companyid / CompanyID.

  USAGE:
    1. Set @Email (section A).
    2. Set @ExecuteSoftDelete = 1 OR @ExecuteHardDelete = 1 (default 0/0 = inspect ONLY).
    3. Execute entire script in SSMS.

  IMPORTANT: Running with both flags 0 only prints "Hard delete skipped" — no rows removed.

  Re-sign up after delete: use @ExecuteHardDelete = 1 (crm_register_new blocks if email still in tb_user).

  WARNING: Hard delete is irreversible. Take a backup first.
================================================================================
*/


/* =============================================================================
   A. PARAMETERS — set before running other sections
============================================================================= */

DECLARE @Email             NVARCHAR(300) = N'john@globo.com';
DECLARE @CompanyId         INT           = NULL;   -- or set 2153 directly
DECLARE @UserId            INT           = NULL;   -- or set 5618 directly
DECLARE @ProtectEmail      NVARCHAR(200) = NULL;

/* ACTION FLAGS — must set one of these to actually delete (default was inspect-only) */
DECLARE @ExecuteSoftDelete BIT = 0;   -- 1 = hide user (row stays in tb_user; sign-up may still block email)
DECLARE @ExecuteHardDelete BIT = 0;   -- 1 = remove rows from tb_user (+ full tenant unless @HardDeleteUserOnly=1)
DECLARE @HardDeleteUserOnly BIT = 0;  -- 1 with @ExecuteHardDelete=1: DELETE only this user; keep company/data


/* =============================================================================
   B. INSPECT — resolve tenant and registration state
============================================================================= */

IF @CompanyId IS NULL OR @UserId IS NULL
BEGIN
    SELECT TOP 1
        @UserId    = u.userid,
        @CompanyId = u.companyId
    FROM dbo.tb_user u
    WHERE u.email = @Email
       OR u.email LIKE N'%' + @Email + N'%'
    ORDER BY u.userid DESC;
END

SELECT
    u.userid,
    u.companyid,
    u.email,
    u.firstname,
    u.lastname,
    u.isadmin,
    u.isdelete   AS user_isdelete,
    u.isvalid    AS user_isvalid,
    c.companyName,
    c.isDelete   AS company_isdelete,
    c.istrial,
    c.regdate,
    c.LanguageConversionFile
FROM dbo.tb_user u
INNER JOIN dbo.tb_company c ON c.companyID = u.companyId
WHERE (@UserId IS NOT NULL AND u.userid = @UserId)
   OR (@CompanyId IS NOT NULL AND u.companyId = @CompanyId AND (@Email IS NULL OR u.email LIKE N'%' + @Email + N'%'));

IF @CompanyId IS NULL
BEGIN
    RAISERROR(N'No user/company found. Set @Email or @CompanyId.', 16, 1);
    RETURN;
END

IF @ExecuteSoftDelete = 0 AND @ExecuteHardDelete = 0
    PRINT N'*** NO DELETE RAN: set @ExecuteHardDelete = 1 (remove row) or @ExecuteSoftDelete = 1 (isdelete flag only). ***';

PRINT N'--- Resolved CompanyId = ' + CAST(@CompanyId AS NVARCHAR(20))
    + N', UserId = ' + ISNULL(CAST(@UserId AS NVARCHAR(20)), N'(null)');


/* =============================================================================
   CORE ENTITY REFERENCE (existing tables — not DDL to deploy)
=============================================================================

  tb_company
    PK: companyid (IDENTITY)
    Soft delete: isDelete = 1  (crm_delete_company)

  tb_user
    PK: userid (IDENTITY)
    FK (logical): companyid -> tb_company.companyid
    Soft delete: isdelete = 1
    Login: isdelete = 0, isvalid = 0 (crm_common_login_new)
    Sign-up duplicate check (crm_register_new): tb_user.email must not exist

  tb_usertab
    userid + companyid — menu/access; cleared on crm_user_delete (isaccessRight = 0)

  Related user tables (delete by companyid/userid if hard-wiping):
    tb_usertab, tb_userCustomize, tb_UserSettings, tb_userinfo,
    tb_groupUser, tb_assigntouser, tb_PublicUserSettings, tb_estoreUser_Visibility

============================================================================= */


/* =============================================================================
   C. SOFT DELETE (application-standard) — row remains in tb_user
============================================================================= */

IF @ExecuteSoftDelete = 1 AND @CompanyId IS NOT NULL AND @UserId IS NOT NULL
BEGIN
    EXEC dbo.PC_settings_user_delete @CompanyID = @CompanyId, @UserID = @UserId;

    UPDATE dbo.tb_usertab
    SET isaccessRight = 0
    WHERE userid = @UserId AND companyID = @CompanyId;

    -- Optional: flag whole company
    -- EXEC dbo.crm_delete_company @companyid = @CompanyId;

    PRINT N'Soft delete done for userid ' + CAST(@UserId AS NVARCHAR(20))
        + N' (row still in tb_user; isdelete=1). Set @ExecuteHardDelete=1 to remove row for re-sign-up.';
END
ELSE IF @ExecuteSoftDelete = 1
    PRINT N'Soft delete skipped: could not resolve @UserId / @CompanyId.';


/* =============================================================================
   STORED PROCEDURE DEFINITIONS (reference — already in database)
=============================================================================

---- crm_user_delete ----
CREATE PROCEDURE [dbo].[crm_user_delete]
    @companyID int,
    @userID int,
    @email NVARCHAR(200)
AS
BEGIN
    UPDATE tb_user SET isdelete = 1
    WHERE userid = @userID AND companyid = @companyID AND email != @email;
    UPDATE tb_userTab SET isaccessRight = 0
    WHERE userid = @userID AND companyid = @companyID;
END;
GO

---- crm_delete_company ----
CREATE PROCEDURE [dbo].[crm_delete_company]
    @companyid int
AS
    UPDATE tb_company SET isdelete = 1 WHERE companyid = @companyid;
GO

---- PC_settings_user_delete ----
CREATE PROCEDURE [dbo].[PC_settings_user_delete]
    @CompanyID int,
    @UserID int
AS
    UPDATE tb_user SET isdelete = 1 WHERE userid = @UserID;
GO

---- crm_register_new (returns new companyid; 0 if email exists in tb_user) ----
-- Creates tb_company row and copies template rows from companyid = 0:
--   tb_backendemailmessages, tb_installmentperiod, tb_scheduleType, tb_assetstatus,
--   tb_clienttype, tb_ownershiptype, tb_partnerRole, tb_role, tb_taskstatus,
--   tb_documentCategory, tb_customizesubsection, tb_lowernavigator, tb_uppernavigator,
--   tb_clientcustomize, tb_contactcustomize
-- Then: EXEC CRM_INSERT_DEFAULTVIEW @companyID

============================================================================= */


/* =============================================================================
   D. HARD DELETE — dev/test only (@ExecuteHardDelete = 1)
   Order: children with dependencies first, then users, then company.
============================================================================= */

IF @ExecuteHardDelete = 0
BEGIN
    PRINT N'Hard delete skipped. Set @ExecuteHardDelete = 1 to remove tb_user row(s).';
    GOTO HardDeleteDone;
END

IF @HardDeleteUserOnly = 1
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        DELETE FROM dbo.tb_usertab WHERE userid = @UserId AND companyID = @CompanyId;
        DELETE FROM dbo.tb_user WHERE userid = @UserId AND companyId = @CompanyId;
        COMMIT TRANSACTION;
        PRINT N'User-only hard delete: userid ' + CAST(@UserId AS NVARCHAR(20)) + N' removed from tb_user.';
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
    GOTO HardDeleteDone;
END

BEGIN TRANSACTION;

BEGIN TRY

    DECLARE @cid INT = @CompanyId;

    /* --- Sample CRM (SignUp SeedSampleCrmData) — adjust if you created more clients --- */
    /* tb_contact / tb_client use companyID; tb_CompanyAddress has ClientId only (no company column) */
    DELETE FROM dbo.tb_contact
    WHERE companyID = @cid AND ClientID IN (
        SELECT clientID FROM dbo.tb_client WHERE companyID = @cid AND clientName LIKE N'%Test Customer%'
    );

    DELETE ca
    FROM dbo.tb_CompanyAddress ca
    INNER JOIN dbo.tb_client cl ON cl.clientID = ca.ClientId
    WHERE cl.companyID = @cid;

    DELETE FROM dbo.tb_client
    WHERE companyID = @cid;

    /* --- Plant / inventory (NewCompanyDefaultSeeds) --- */
    DELETE m FROM dbo.tb_lithoSpeedWeightMatrix m
    INNER JOIN dbo.tb_LithoPress p ON p.LithoPressID = m.PressID
    WHERE p.CompanyID = @cid;

    DELETE li FROM dbo.tb_LithoInk li
    INNER JOIN dbo.tb_LithoPress p ON p.LithoPressID = li.LithoPressID
    WHERE p.CompanyID = @cid;

    DELETE FROM dbo.tb_LithoPress WHERE CompanyID = @cid;
    DELETE FROM dbo.tb_Guillotine WHERE CompanyID = @cid;

    DELETE ip FROM dbo.tb_inventoryproperties ip
    INNER JOIN dbo.tb_inventory i ON i.InventoryID = ip.InventoryID
    WHERE i.CompanyID = @cid;

    DELETE FROM dbo.tb_inventory WHERE CompanyID = @cid;

    /* --- Settings / lookups seeded in code --- */
    DELETE FROM dbo.tb_CustomizeView       WHERE CompanyID = @cid;
    DELETE FROM dbo.tb_WarehouseLocation   WHERE CompanyID = @cid;
    DELETE FROM dbo.tb_frmemailsettings    WHERE CompanyID = @cid;
    DELETE FROM dbo.tb_accountingCode      WHERE CompanyID = @cid;
    DELETE FROM dbo.tb_lastCounter          WHERE CompanyID = @cid;
    DELETE FROM dbo.tb_CustomerCode         WHERE CompanyID = @cid;
    DELETE FROM dbo.tb_ItemDescription      WHERE CompanyID = @cid;
    DELETE FROM dbo.tb_OtherCostCategory    WHERE CompanyID = @cid;
    DELETE FROM dbo.tb_defaultsettings      WHERE CompanyID = @cid;
    DELETE FROM dbo.tb_papersize            WHERE CompanyID = @cid;
    DELETE FROM dbo.tb_stockcategory        WHERE CompanyID = @cid;
    DELETE FROM dbo.tb_SystemMarkup         WHERE CompanyID = @cid;
    DELETE FROM dbo.tb_taxrates             WHERE CompanyID = @cid;
    DELETE FROM dbo.tb_markup               WHERE CompanyID = @cid;
    DELETE FROM dbo.tb_Numbering            WHERE CompanyID = @cid;
    DELETE FROM dbo.tb_EstimateStatus       WHERE CompanyID = @cid;
    DELETE FROM dbo.tb_AccountStatus        WHERE CompanyID = @cid;
    DELETE FROM dbo.tb_contractstatus       WHERE companyid = @cid;
    DELETE FROM dbo.tb_assetStatus          WHERE companyID = @cid;
    DELETE FROM dbo.tb_leadStatus           WHERE companyID = @cid;
    DELETE FROM dbo.tb_taskstatus           WHERE companyID = @cid;
    DELETE FROM dbo.tb_ticketStatus         WHERE companyId = @cid;
    DELETE FROM dbo.tb_solutionStatus       WHERE companyId = @cid;
    DELETE FROM dbo.tb_campaignStatus       WHERE companyId = @cid;
    DELETE FROM dbo.tb_RegionalSettings     WHERE CompanyID = @cid;

    /* --- crm_register_new template copies (companyid = 0 source) --- */
    DELETE FROM dbo.tb_contactcustomize     WHERE companyId = @cid;
    DELETE FROM dbo.tb_clientcustomize      WHERE companyId = @cid;
    DELETE FROM dbo.tb_upperNavigator       WHERE companyID = @cid;
    DELETE FROM dbo.tb_lowerNavigator       WHERE companyID = @cid;
    DELETE FROM dbo.tb_customizesubsection  WHERE companyID = @cid;
    DELETE FROM dbo.tb_documentCategory     WHERE companyID = @cid;
    DELETE FROM dbo.tb_role                 WHERE companyID = @cid;
    DELETE FROM dbo.tb_partnerRole          WHERE companyID = @cid;
    DELETE FROM dbo.tb_ownershiptype        WHERE companyid = @cid;
    DELETE FROM dbo.tb_clientType           WHERE companyID = @cid;
    DELETE FROM dbo.tb_scheduleType         WHERE companyID = @cid;
    DELETE FROM dbo.tb_installmentperiod    WHERE companyID = @cid;
    DELETE FROM dbo.tb_backendemailmessages WHERE companyID = @cid;

    /* --- User rows --- */
    DELETE FROM dbo.tb_usertab              WHERE companyID = @cid;
    DELETE FROM dbo.tb_userCustomize        WHERE companyId = @cid;
    DELETE FROM dbo.tb_UserSettings         WHERE CompanyID = @cid;
    DELETE FROM dbo.tb_userinfo             WHERE companyID = @cid;
    DELETE FROM dbo.tb_groupUser            WHERE companyid = @cid;
    DELETE FROM dbo.tb_assigntouser         WHERE companyid = @cid;
    DELETE FROM dbo.tb_user                 WHERE companyId = @cid;

    /* --- Remaining company-scoped tables (dynamic — uses actual column name from catalog) --- */
    DECLARE @sql       NVARCHAR(MAX) = N'';
    DECLARE @tbl       SYSNAME;
    DECLARE @companyCol SYSNAME;

    DECLARE cur CURSOR LOCAL FAST_FORWARD FOR
        SELECT DISTINCT t.name
        FROM sys.tables t
        INNER JOIN sys.columns c ON c.object_id = t.object_id
        WHERE c.name IN (N'companyid', N'CompanyID', N'companyId', N'companyID')
          AND t.name NOT IN (
              N'tb_company', N'tb_user', N'tb_usertab', N'tb_client', N'tb_contact',
              N'tb_CompanyAddress', N'tb_LithoPress', N'tb_LithoInk', N'tb_lithoSpeedWeightMatrix',
              N'tb_Guillotine', N'tb_inventory', N'tb_inventoryproperties'
          )
        ORDER BY t.name;

    OPEN cur;
    FETCH NEXT FROM cur INTO @tbl;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SELECT TOP 1 @companyCol = c.name
        FROM sys.columns c
        WHERE c.object_id = OBJECT_ID(QUOTENAME(N'dbo') + N'.' + QUOTENAME(@tbl))
          AND c.name IN (N'companyid', N'CompanyID', N'companyId', N'companyID')
        ORDER BY c.column_id;

        IF @companyCol IS NOT NULL
        BEGIN
            SET @sql = N'DELETE FROM dbo.' + QUOTENAME(@tbl)
                + N' WHERE ' + QUOTENAME(@companyCol) + N' = @cid;';

            BEGIN TRY
                EXEC sp_executesql @sql, N'@cid INT', @cid = @cid;
            END TRY
            BEGIN CATCH
                PRINT N'Skip or fix: ' + @tbl + N' — ' + ERROR_MESSAGE();
            END CATCH
        END

        SET @companyCol = NULL;
        FETCH NEXT FROM cur INTO @tbl;
    END
    CLOSE cur;
    DEALLOCATE cur;

    DELETE FROM dbo.tb_company WHERE companyID = @cid;

    COMMIT TRANSACTION;
    PRINT N'Hard delete completed for companyid ' + CAST(@cid AS NVARCHAR(20));

END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    THROW;
END CATCH

HardDeleteDone:

/* Verify tb_user row after run */
IF @Email IS NOT NULL
    SELECT userid, companyId, email, isdelete
    FROM dbo.tb_user
    WHERE email = @Email OR email LIKE N'%' + @Email + N'%';


/* =============================================================================
   E. GENERATE DELETE STATEMENTS (preview all company-scoped tables)
============================================================================= */

SELECT
    N'DELETE FROM dbo.' + QUOTENAME(t.name) + N' WHERE ' + QUOTENAME(c.name) + N' = '
        + CAST(@CompanyId AS NVARCHAR(20)) + N';' AS delete_statement
FROM sys.tables t
CROSS APPLY (
    SELECT TOP 1 col.name
    FROM sys.columns col
    WHERE col.object_id = t.object_id
      AND col.name IN (N'companyid', N'CompanyID', N'companyId', N'companyID')
    ORDER BY col.column_id
) c
WHERE t.name <> N'tb_company'
ORDER BY t.name;


/* =============================================================================
   F. TABLE INVENTORY — rows created by sign-up path
=============================================================================

  Layer 1 — Registration SP (crm_register_new)
    tb_company
    tb_backendemailmessages, tb_installmentperiod, tb_scheduleType, tb_assetstatus
    tb_clienttype, tb_ownershiptype, tb_partnerRole, tb_role, tb_taskstatus
    tb_documentCategory, tb_customizesubsection, tb_lowernavigator, tb_uppernavigator
    tb_clientcustomize, tb_contactcustomize
    (+ CRM_INSERT_DEFAULTVIEW)

  Layer 2 — Admin user (crm_user_add_withAccessRights)
    tb_user, tb_usertab (+ usertype/group as configured)

  Layer 3 — CompleteNewCompanySetup + NewCompanyDefaultSeeds
    tb_RegionalSettings
    tb_EstimateStatus, tb_AccountStatus, tb_contractstatus, tb_assetstatus (again if seeded),
    tb_leadstatus, tb_taskstatus, tb_ticketstatus, tb_solutionstatus, tb_campaignStatus
    tb_Numbering, tb_markup, tb_taxrates, tb_SystemMarkup, tb_stockcategory, tb_papersize
    tb_defaultsettings, tb_OtherCostCategory, tb_ItemDescription, tb_CustomerCode, tb_lastCounter
    tb_accountingCode, tb_frmemailsettings, tb_WarehouseLocation, tb_CustomizeView
    tb_Guillotine, tb_LithoPress, tb_LithoInk, tb_lithoSpeedWeightMatrix, tb_inventory, tb_inventoryproperties
    PC_CustomizeViewIfNotExist

  Layer 4 — SeedSampleCrmData
    tb_client, tb_CompanyAddress (or address via SP), department, tb_contact

  Layer 5 — Later usage (same companyid; delete if tenant used the app)
    tb_estimate, tb_job, tb_invoice, tb_purchase, documents, campaigns, etc.
    (~305 tables have companyid/CompanyID column in eprint_demo)

  Master DB (eprint_master) — only if you added host routing:
    tb_ClientInfo, tb_MIS_AppSettings (not created by Sign Up on shared CRM DB)

============================================================================= */
