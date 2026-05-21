-- Manual integration seed: sample CRM + DEMO estimates + item bodies (SQL equivalent of registration seeds).
-- Usage: set @companyId and @userId, then execute.

DECLARE @companyId int = 2174;
DECLARE @userId int = (SELECT TOP 1 userid FROM tb_user WHERE companyid = @companyId AND isadmin = 1 ORDER BY userid);

IF @userId IS NULL
BEGIN
	RAISERROR('Set @companyId to a company with an admin user (register via Sign Up first).', 16, 1);
	RETURN;
END

DECLARE @clientId int, @contactId bigint, @addressId bigint, @deptId bigint = 0;
DECLARE @statusId int = (
	SELECT TOP 1 StatusID FROM tb_EstimateStatus
	WHERE companyid = @companyId AND ISNULL(IsDeleted,0)=0 AND ISNULL(Estimate,0)=1
	ORDER BY ISNULL(EstimateDefault,0) DESC, StatusID);

IF NOT EXISTS (SELECT 1 FROM tb_client WHERE companyID = @companyId AND companytype = N'Customer' AND clientname = N'Test Customer' AND ISNULL(isdelete,0)=0)
BEGIN
	INSERT INTO tb_client (companyID, companytype, clientname, isdelete, createDate, AddressID)
	VALUES (@companyId, N'Customer', N'Test Customer', 0, GETDATE(), 0);
	SET @clientId = SCOPE_IDENTITY();
END
ELSE
	SELECT @clientId = clientid FROM tb_client WHERE companyID = @companyId AND clientname = N'Test Customer' AND ISNULL(isdelete,0)=0;

IF NOT EXISTS (SELECT 1 FROM tb_contact WHERE ClientID = @clientId AND companyID = @companyId AND ISNULL(isDelete,0)=0)
BEGIN
	INSERT INTO tb_contact (companyID, ClientID, FirstName, LastName, DefaultContact, isDelete, createDate)
	VALUES (@companyId, @clientId, N'John', N'Doe', 1, 0, GETDATE());
	SET @contactId = SCOPE_IDENTITY();
END
ELSE
	SELECT TOP 1 @contactId = contactId FROM tb_contact WHERE ClientID = @clientId AND companyID = @companyId AND ISNULL(isDelete,0)=0 ORDER BY contactId;

SELECT TOP 1 @deptId = DeptID FROM tb_Department WHERE CompanyID = @companyId AND CustomerID = @clientId AND ISNULL(IsDeleted,0)=0 ORDER BY DeptID;
IF @deptId IS NULL SET @deptId = 0;

-- Demo estimates (headers + items + details) — skip if already present
DECLARE @types TABLE (Seq int, Code char(1), Title nvarchar(80));
INSERT INTO @types VALUES
	(1,'S',N'Sample - Sheet Fed Digital'),
	(2,'L',N'Sample - Sheet Fed Offset'),
	(3,'F',N'Sample - Large Format'),
	(4,'O',N'Sample - Outwork'),
	(5,'U',N'Sample - Other Cost'),
	(6,'W',N'Sample - Warehouse'),
	(7,'Q',N'Sample - Quick Quote');

DECLARE @seq int, @code char(1), @title nvarchar(80), @estId bigint, @itemId bigint, @estNum nvarchar(20);

DECLARE c CURSOR LOCAL FAST_FORWARD FOR SELECT Seq, Code, Title FROM @types ORDER BY Seq;
OPEN c;
FETCH NEXT FROM c INTO @seq, @code, @title;
WHILE @@FETCH_STATUS = 0
BEGIN
	SET @estNum = N'DEMO-' + RIGHT(N'000' + CAST(@seq AS nvarchar(10)), 3);
	IF NOT EXISTS (SELECT 1 FROM tb_estimate WHERE CompanyID = @companyId AND EstimateNumber = @estNum AND ISNULL(IsDeleted,0)=0)
	BEGIN
		-- Prefer PC_estimate_insert_new_stage1 from SeedSampleEstimatesForCompany.ps1.
		-- Direct insert requires non-null Header/Footer and other defaults:
		INSERT INTO tb_estimate (
			CompanyID, UserID, CustomerID, AttentionID, Address, Header, Footer, OrderNumber,
			EstimateTitle, EstimateNumber, StatusID, EstimateDate, ValidFor, DeliveryAddress,
			IsForInvoice, IsConvertedToJob, ModifiedBy, CreatedDate, ModifiedDate, IsDeleted,
			Comments, AddressType, SalesPerson, EstimatorId, IsArchive, HasDeliveryNote, HasPurchaseOrder,
			IsCopied, TemNameLastCounter, AccountCodeID, IsFromWebStore, IsReduced, DepartmentID)
		VALUES (
			@companyId, @userId, @clientId, @contactId, 0, N'', N'', N'',
			@title, @estNum, @statusId, GETDATE(), 14, 0,
			0, 0, @userId, GETDATE(), GETDATE(), 0,
			N'Registration sample estimate', N'A', @userId, @userId, 0, 0, 0,
			0, 0, 0, 0, 0, @deptId);
		SET @estId = SCOPE_IDENTITY();

		INSERT INTO tb_estimateitem (EstimateID, EstimateType, IsDeleted, IsParentItem, ParentItemID, CreatedDate)
		VALUES (@estId, @code, 0, 1, 0, GETDATE());
		SET @itemId = SCOPE_IDENTITY();

		IF NOT EXISTS (SELECT 1 FROM tb_EstimateItemDetails WHERE EstimateItemID = @itemId)
			INSERT INTO tb_EstimateItemDetails (EstimateID, EstimateItemID, EstimateType)
			VALUES (@estId, @itemId, @code);
	END
	FETCH NEXT FROM c INTO @seq, @code, @title;
END
CLOSE c; DEALLOCATE c;

PRINT 'Created/verified DEMO estimates for company ' + CAST(@companyId AS varchar(20));
PRINT 'Run app RepairNewCompanySetup or re-register to apply C# item-body seeds (tb_EstSingleItem, etc.).';
