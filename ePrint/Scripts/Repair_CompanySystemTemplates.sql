-- System Templates are applied via built-in seed SQL (not a live company copy at runtime).
-- Preferred: after deploy, call registrationClass.RepairSystemTemplates(companyId) from the app.
-- Or execute the embedded seed through the same code path as new registration.

PRINT 'Use: new registrationClass().RepairSystemTemplates(@targetCompanyId) after building the site.';
PRINT 'Seed file: nms/nmsCommon/SeedData/SystemTemplatesRegistration.sql (embedded in the web assembly).';
