/*
  Fix Jobs list "Invalid column name 'Deliv'" (truncated CustomizeView ColumnNames).
  Registration seed had job Default View cut at 256 chars, ending with "Delive" instead of "DeliveryDate,...".
*/
SET NOCOUNT ON;

DECLARE @CompanyId INT = NULL; -- e.g. 2165, or NULL for all affected rows

DECLARE @JobDefaultViewColumns NVARCHAR(MAX) =
N'EstimateType,DownloadTemplate,JobNumber,EstimateTitle,CustomerID,AttentionID,SalesPerson,JobDate,EstimateValue_ExcGst,EstimateValue,ProductionDate,Comments,PONumber,ItemValueExcTax,ItemValueInTax,ItemTaxValue,ItemProfitMarginValue,ItemGrossProfitValue,JobStatus,DeliveryDate,CompletionDate,CustomDate1,CustomDate2,CustomDate3,CustomDate4,CustomDate5,Priority,sinceStatusUpdate,sinceEmailed,Archive,IsFromWebStore,OrderID,ProformaInvoice,Paid,EstItemCoun,';

DECLARE @InvoiceDefaultViewColumns NVARCHAR(MAX) =
N'ChooseTemplate,InvoiceNumber,EstimateTitle,CustomerID,AttentionID,CustomerOrderNumber,CreatedDate,EstimateValue_ExcGst,Comments,InvoiceStatus,[Job Number],Priority,sinceStatusUpdate,sinceEmailed,CustomDate1,Archive,CustomDate2,IsFromWebStore,OrderID,EstItemCoun,';

UPDATE cv
SET ColumnNames = @JobDefaultViewColumns
FROM dbo.tb_CustomizeView cv
WHERE cv.PageName = N'job'
  AND cv.ViewName = N'Default View'
  AND ISNULL(cv.isDeleted, 0) = 0
  AND (@CompanyId IS NULL OR cv.CompanyID = @CompanyId)
  AND (cv.ColumnNames LIKE N'%Delive' OR LEN(cv.ColumnNames) <= 260);

UPDATE cv
SET ColumnNames = @InvoiceDefaultViewColumns
FROM dbo.tb_CustomizeView cv
WHERE cv.PageName = N'invoice'
  AND cv.ViewName = N'Default View'
  AND ISNULL(cv.isDeleted, 0) = 0
  AND (@CompanyId IS NULL OR cv.CompanyID = @CompanyId)
  AND (cv.ColumnNames LIKE N'%EstIte' OR LEN(cv.ColumnNames) <= 260);

SELECT CompanyID, PageName, ViewName, LEN(ColumnNames) AS ColumnNamesLen, RIGHT(ColumnNames, 40) AS ColumnNamesTail
FROM dbo.tb_CustomizeView
WHERE ISNULL(isDeleted, 0) = 0
  AND PageName IN (N'job', N'invoice')
  AND ViewName = N'Default View'
  AND (@CompanyId IS NULL OR CompanyID = @CompanyId)
ORDER BY CompanyID, PageName;
