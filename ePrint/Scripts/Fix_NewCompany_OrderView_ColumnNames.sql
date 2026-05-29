/*
  Fix Orders list "Invalid column name 'Arc'" (truncated CustomizeView ColumnNames).
  Registration seed had webstoreorder Default View cut at 256 chars, ending with "Arch" instead of "Archive,...".
*/
SET NOCOUNT ON;

DECLARE @CompanyId INT = NULL; -- e.g. 2165, or NULL for all affected rows

DECLARE @WebstoreOrderDefaultViewColumns NVARCHAR(MAX) =
N'OrderNumber,CustomerID,SalesPerson,OrderTitle,StatusID,OrderedDate,FTP,CreatedDate,OrderValue,DeliveryAddress,Comments,OrderedFor,OrderedBy,Approved,PaymentType,ItemArtwork,DefaultTemplate,ChooseTemplate,DownloadTemplate,sinceStatusUpdate,sinceEmailed,Archive,CustomDate1,CustomDate2,CustomDate3,EstItemCoun,IsCompletlyConvertedToJob,IsArchived,IsDeletedJob,estimateid,';

UPDATE cv
SET ColumnNames = @WebstoreOrderDefaultViewColumns
FROM dbo.tb_CustomizeView cv
WHERE cv.PageName = N'webstoreorder'
  AND cv.ViewName = N'Default View'
  AND ISNULL(cv.isDeleted, 0) = 0
  AND (@CompanyId IS NULL OR cv.CompanyID = @CompanyId)
  AND (cv.ColumnNames LIKE N'%Arch' AND LEN(cv.ColumnNames) <= 260);

SELECT CompanyID, PageName, ViewName, LEN(ColumnNames) AS ColumnNamesLen, RIGHT(ColumnNames, 50) AS ColumnNamesTail
FROM dbo.tb_CustomizeView
WHERE PageName = N'webstoreorder'
  AND ViewName = N'Default View'
  AND ISNULL(isDeleted, 0) = 0
  AND (@CompanyId IS NULL OR CompanyID = @CompanyId)
ORDER BY CompanyID;
