# New registration — seed data reference

Sign-up flow: `Login/SignUp.aspx` → `registrationClass` → SQL Server (`eprint_demo`).

**No new tables or migrations** — only INSERTs and stored procedures into existing tables.

---

## Execution order

```
1. RegisterNew (C#)              → tb_company row only (no copy from company 0)
2. crm_user_add_withAccessRights → tb_user, tb_usertab, access
3. CompleteNewCompanySetup
     a. tb_RegionalSettings
     b. tb_user / tb_company updates
     c. CRM_INSERT_DEFAULTVIEW
     d. NewCompanyDefaultSeeds.ApplyAll
        - RegistrationBootstrapSeeds (navigators, lookups, field layouts)
        - statuses, estimate settings, plant, CustomizeViews (all in code)
     e. PC_CustomizeViewIfNotExist (proof view)
     f. SeedSampleCrmData (sample customer — optional row)
```

**Source files**

| Step | File |
|------|------|
| Sign-up parameters | `Login/SignUp.aspx.cs` |
| Company + user | `nms/nmsCommon/registrationClass.cs` |
| Built-in SQL seeds | `nms/nmsCommon/NewCompanyDefaultSeeds.cs` |
| CRM bootstrap | `nms/nmsCommon/RegistrationBootstrapSeeds.cs` |
| Sample CRM | `registrationClass.SeedSampleCrmData()` |

---

## 1. Sign-up form → `RegisterNew` (C#)

**Called from:** `SignUp.aspx.cs` → `RegisterNew(...)` — inserts `tb_company` only; does not call `crm_register_new`.

| Parameter | Value (Sign Up page) |
|-----------|----------------------|
| country | Australia |
| lcid | (empty) |
| companyname | From form (SpecialEncode) |
| address, city, zip | (empty) |
| noofemployee | 1 |
| noofuser | 5 |
| hearfrom | Sign Up |
| istrail | 1 |
| languagename | English |
| currency | AUD |
| datetimeformat | DD/MM/YY |
| timezoneid | 115 |
| email | From form (SpecialEncode) |
| expires | 14 (trial days) |
| UniqueValue | New GUID (max 50 chars) |

**Creates:** `tb_company` row (returns new `companyID`).

**Also copies rows from template `companyid = 0` into the new company:**

| Target table |
|--------------|
| tb_backendemailmessages |
| tb_installmentperiod |
| tb_scheduleType |
| tb_assetstatus |
| tb_clienttype |
| tb_ownershiptype |
| tb_partnerRole |
| tb_role |
| tb_taskstatus |
| tb_documentCategory |
| tb_customizesubsection |
| tb_lowernavigator |
| tb_uppernavigator |
| tb_clientcustomize |
| tb_contactcustomize |

**Then:** `EXEC CRM_INSERT_DEFAULTVIEW @companyID` (legacy list views — see section 4).

---

## 2. Admin user → `crm_user_add_withAccessRights`

| Field | Value |
|-------|--------|
| jobtitle | Administrator |
| isadmin | 1 |
| iscorporateright | 1 |
| password | `commonClass.Encrypt(SpecialEncode(plainPassword))` |
| expiredate | now + 10 years |

**Creates:** `tb_user`, `tb_usertab`, menu/access rows (via SP).

---

## 3. `CompleteNewCompanySetup` (registrationClass.cs)

### 3a. Languages and regional settings

**Table:** `tb_Languages` (per company — powers the Regional Settings language dropdown)

| Languages |
|-----------|
| US/Canada English |
| UK English |

**Table:** `tb_RegionalSettings` (default profile uses **UK English**)

| Column | Value |
|--------|--------|
| LanguageID | FK to `tb_Languages` row **UK English** for this company |
| DateFormat | `dd/mm/yyyy` (or sign-up value) |
| TimeZoneID | From sign-up (default 102) |
| Colour / Organisation / State / Centre / PostCode | UK labels: Color, Organisation, State, Centre, Post Code |
| Metre / Weight / PaperMeasure | Metre, gsm, mm |
| GeneralWeight / PaperMaterial | lbs, Micron |
| PageTitle / CompanyTitle | `tb_company.companyname` |
| IsDisplayCostCentre | 1 |
| FisCalFrom / FisCalTo | July 1 → June 1 (fiscal year) |
| Roundoff | 2 |

### 3b. User / company updates

```sql
UPDATE tb_user SET DefaultLanding = 'Home' WHERE companyid = @companyId AND isadmin = 1
UPDATE tb_company SET LanguageConversionFile = 'English_TO_English' WHERE companyid = @companyId AND LanguageConversionFile IS NULL/empty
```

---

## 4. `CRM_INSERT_DEFAULTVIEW` (database SP)

Inserts **legacy** default views (not `tb_CustomizeView`):

| Table | Default view name |
|-------|-------------------|
| tb_leadViewValue | Default view |
| tb_clientviewvalue | Default view |
| tb_contactviewvalue | Default view |
| tb_campaignviewvalue | Default view |
| tb_solutionviewvalue | Default view |
| tb_opportunityviewvalue | Default view |
| tb_ticketviewvalue | Default view |
| tb_forecastviewvalue | (and more in full SP) |

---

## 5. `NewCompanyDefaultSeeds.cs` (built-in SQL)

All use `@companyId` = new tenant. **Idempotent:** `IF NOT EXISTS` before insert.

### 5a. ApplyStatuses

**tb_EstimateStatus** — 14 rows:

| StatusTitle | Notes |
|-------------|--------|
| In Progress | |
| Completed | |
| Ready for Invoice | |
| On Hold | |
| Approved | Job default |
| Not Approved | |
| Press | |
| Requested | |
| In Production | |
| RFQ | Estimate default |
| Cancelled | |
| New Del. Note | |
| Awaiting Authorization | |
| Locked | IsDefault = 1 |

**Other status tables (1 row each):**

| Table | Value |
|-------|--------|
| tb_AccountStatus | Accounts Clear |
| tb_contractstatus | Active |
| tb_assetstatus | Active |
| tb_leadstatus | New |
| tb_taskstatus | Open |
| tb_ticketstatus | Open |
| tb_solutionstatus | Draft |
| tb_campaignStatus | Planned |

### 5b. ApplyLookupAndEstimateSettings

| Table | Seed data |
|-------|-----------|
| tb_Numbering | Estimates/Jobs/Invoices/Purchases/Delivery = 0 |
| tb_markup | 0%, 5%, 10% |
| tb_taxrates | Tax 1 (0%), Tax 2 (17.5%) |
| tb_SystemMarkup | Paper 10%, PrintBroker 30%, links first markup/tax |
| tb_stockcategory | Paper, Inks, Plates |
| tb_papersize | A4 (210×297), SRA3 (320×450) |
| tb_defaultsettings | SheetFedDigital, Roundoff 2 |
| tb_OtherCostCategory | Admin (linked to first EstimateStatus) |
| tb_ItemDescription | Litho/Sheet/Outwork field labels (9 rows) |
| tb_CustomerCode | LastCounter 0 |
| tb_lastCounter | Estimate, Job, Invoice = 0 |
| tb_accountingCode | 4000 Sales (default) |
| tb_frmemailsettings | FromEmail empty |
| tb_WarehouseLocation | Main, Sydney NSW 2000 Australia |

### 5c. ApplyPlantSettings

Hardcoded in `NewCompanyDefaultSeeds.cs` (template based on company 2144; **no DB read** at registration). Ensures **at least one default plant per estimate family**:

| Estimate type | Plant table | Default name |
|---------------|-------------|--------------|
| Sheet Fed Offset | `tb_LithoPress` | Sample Offset Press |
| Sheet Fed Digital | `tb_DigitalPress` | Sample Digital Press (`ClickChargeLookup` method) |
| Large Format | `tb_LargeFormatPress` | Sample Wide Format Press |

**Shared stock & trim**

| Object | Name / detail |
|--------|----------------|
| tb_Guillotine | Sample Guillotine (sheet) |
| tb_Guillotine | Sample Cutting Table (`IsLarge` = 1) |
| tb_inventory | Sample Paper 130gsm (PAPER-130), `PaperType` = sheet |
| tb_inventory | Sample Process Ink (INK-1) |
| tb_inventory | Sample Plate (PLATE-1) |
| tb_LithoInk / tb_LargeFormatInk | Link press → ink |
| tb_lithoSpeedWeightMatrix | GSM 115 @ 9000 sheets/hr (litho) |
| tb_ClickChargeLookup | 1/1/1 chargeable sheets (digital) |

### 5d. ApplyCustomizeViews

**Hardcoded in** `NewCompanyDefaultSeeds.cs` — inserts into `tb_CustomizeView` with the new `@companyId` only (no read from company 0 or 2144).

| Setting | Value |
|---------|--------|
| Excludes | PageName = `proof` (proof view created separately via `PC_CustomizeViewIfNotExist`) |

**Page types seeded:** customer, Estimate, job, invoice, purchase, deliverynote, inventory, InventorySelectView, accounts, supplier, prospect, productcatalogue, webstoreorder, etc.

### 5e. RegistrationBootstrapSeeds.Apply

**Hardcoded in** `RegistrationBootstrapSeeds.cs` — replaces `crm_register_new` copy-from-company-0 for navigators, client/contact field layouts, lookups, and backend email stubs.

---

## 6. `PC_CustomizeViewIfNotExist`

**Creates:** proof module default view in `tb_CustomizeView` (PageName = proof).

---

## 7. `SeedSampleCrmData` (sample CRM — transactional)

**Does not seed estimates** — estimate list stays empty until user creates estimates.

| Entity | Values |
|--------|--------|
| Customer name | Test Customer |
| Alias | Test |
| Type | Customer |
| Account status | First `tb_AccountStatus.StatusID` for company |
| Account number | From `Account_Number_Generate(companyId, "A")` |
| Email | sample@testcustomer.local |
| Description | Sample customer created during registration. |
| Address | 123 Sample Street, Sydney NSW 2000, Australia |
| Phone | 02 9000 0000 |
| Contact | John Doe (alias John_Doe) |
| Department | Main |

**SPs used:** `PC_Company_InsertUpdate`, `CompanyDefaultAddress_InsertUpdate`, `departmentInsert`, `Contact_InsertUpdate`.

---

## What is NOT seeded

| Data | Notes |
|------|--------|
| tb_estimate | User creates via Estimates UI |
| tb_job / tb_invoice | Created in normal workflow |
| eprint_master.tb_ClientInfo | Not used for shared-DB sign-up |

---

## Repair / re-run seeds for an existing company

```csharp
// Full setup (regional, defaults, views, sample CRM)
new registrationClass().RepairNewCompanySetup(companyId, 115, "DD/MM/YY");

// Views only
new registrationClass().RepairCustomizeViews(companyId);
```

Or run SQL in `Scripts/RegisteredUser_Deletion_Schema.sql` (delete) then sign up again.

---

## Database template companies (no longer used at registration)

Registration no longer reads seed rows from company **0** or **2144**. Defaults live in `NewCompanyDefaultSeeds.cs` and `RegistrationBootstrapSeeds.cs`. `RegisterNew` inserts only the `tb_company` row in C#; `CompleteNewCompanySetup` applies all built-in seeds for the new `companyid`.
