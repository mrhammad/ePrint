/*
  Invoice creation (progress_to_invoice) fixes for new tenants:
  - Get_PaymentDetails_From_EstimateID: clients without payment terms return NULL from PC_PaymentTermDays_Select
  - Default invoice status: flag Ready for Invoice for invoice module
*/
SET NOCOUNT ON;

DECLARE @CompanyId INT = NULL; -- e.g. 2165, or NULL for all

UPDATE s SET Invoice = 1, InvoiceDefault = 1
FROM dbo.tb_EstimateStatus s
WHERE (@CompanyId IS NULL OR s.companyid = @CompanyId)
  AND s.StatusTitle = N'Ready for Invoice'
  AND NOT EXISTS (
      SELECT 1 FROM dbo.tb_EstimateStatus x
      WHERE x.companyid = s.companyid AND x.Invoice = 1);

SELECT companyid, StatusID, StatusTitle, Invoice, InvoiceDefault
FROM dbo.tb_EstimateStatus
WHERE (@CompanyId IS NULL OR companyid = @CompanyId)
  AND StatusTitle = N'Ready for Invoice';
