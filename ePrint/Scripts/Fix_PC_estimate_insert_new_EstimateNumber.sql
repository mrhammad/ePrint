-- Fix new estimates not appearing on estimate list:
-- 1) PC_estimate_insert_new was inserting literal 0 for EstimateNumber (Get_Eprint_Number was commented out).
-- 2) VW_Estimate_View excludes rows where EstimateNumber IS NULL (NULL NOT IN (...)).
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

CREATE OR ALTER PROCEDURE [dbo].[PC_estimate_insert_new]
    @CompanyID int,
    @UserID int,
    @CustomerID int,
    @AttentionID bigint,
    @Greeting nvarchar(100),
    @Company nvarchar(100),
    @Address bigint,
    @Header nvarchar(MAX),
    @Footer nvarchar(MAX),
    @SalesPerson nvarchar(100),
    @EstimateTitle nvarchar(1000),
    @EstimateNumber nvarchar(25),
    @OrderNumber nvarchar(100),
    @StatusID int,
    @EstimateDate datetime,
    @ValidFor int,
    @DeliveryAddress bigint,
    @IsConvertedToJob bit,
    @ModifiedDate datetime,
    @ModifiedBy int,
    @EstimateID bigint,
    @IsForInvoice bit,
    @AddressType char(1),
    @DeliveryAddressType char(1),
    @CurrentEstNo bigint,
    @EstimatedArtwork datetime,
    @EstimatedDelivery datetime,
    @CreatedDate datetime,
    @IsDirectJob bit,
    @EstProofDate datetime,
    @EstApprovalDate datetime,
    @EstProductionDate datetime,
    @EstCompletionDate datetime,
    @InvoiceAddressID bigint,
    @DepartmentID bigint,
    @CostCentreID bigint,
    @EstimatorId INT,
    @Comments nvarchar(500),
    @InvoiceContactId bigint = 0,
    @priority nvarchar(20),
    @CustomDate1 datetime,
    @CustomDate2 datetime,
    @CustomDate3 datetime,
    @CustomDate4 datetime,
    @CustomDate5 datetime,
    @ReturnID bigint OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF (@CreatedDate IS NULL)
        SET @CreatedDate = '1/1/1900';

    IF (@EstimateID = 0)
    BEGIN
        DECLARE @RID bigint;
        DECLARE @AssignedEstimateNumber nvarchar(25);

        IF (@IsForInvoice = 1 OR @IsDirectJob = 1)
        BEGIN
            SET @StatusID = ISNULL((
                SELECT TOP 1 statusid
                FROM tb_estimatestatus
                WHERE estimatedefault = 1 AND isdeleted = 0 AND CompanyID = @CompanyID), 0);
        END

        IF (@DeliveryAddressType = '' OR @DeliveryAddressType IS NULL)
            SET @DeliveryAddressType = 'A';

        DECLARE @CounterModule nvarchar(10) = N'e';
        IF NOT EXISTS (SELECT 1 FROM tb_LastCounter WHERE CompanyID = @CompanyID AND ModuleType = N'e')
        BEGIN
            IF EXISTS (SELECT 1 FROM tb_LastCounter WHERE CompanyID = @CompanyID AND ModuleType = N'Estimate')
                SET @CounterModule = N'Estimate';
            ELSE
                INSERT INTO tb_LastCounter (CompanyID, ModuleType, LastCounter) VALUES (@CompanyID, N'e', 0);
        END

        SET @AssignedEstimateNumber = NULLIF(LTRIM(RTRIM(@EstimateNumber)), '');
        IF (@AssignedEstimateNumber IS NULL OR @AssignedEstimateNumber IN ('0', 'null', 'NULL'))
        BEGIN
            SET @AssignedEstimateNumber = dbo.Get_Eprint_Number(@CompanyID, @CounterModule, 'EST', 0);
        END
        IF (@AssignedEstimateNumber IS NULL OR @AssignedEstimateNumber IN ('0', 'null', 'NULL'))
        BEGIN
            DECLARE @NextCounter bigint = ISNULL((
                SELECT LastCounter FROM tb_LastCounter WHERE CompanyID = @CompanyID AND ModuleType = @CounterModule), 0) + 1;
            SET @AssignedEstimateNumber = N'EST-' + RIGHT(N'0000000' + CAST(@NextCounter AS nvarchar(7)), 7);
        END

        INSERT INTO tb_Estimate (
            CompanyID, UserID, CustomerID, AttentionID, Greeting, Company, Address, Header, Footer,
            SalesPerson, EstimateTitle, EstimateNumber, OrderNumber, StatusID, EstimateDate, ValidFor,
            DeliveryAddress, IsConvertedToJob, IsForInvoice, AddressType, DeliveryAddressType,
            EstimatedArtwork, EstimatedDelivery, CreatedDate, IsDirectJob, EstProofDate, EstApprovalDate,
            EstProductionDate, EstCompletionDate, InvoiceAddressID, DepartmentID, CostCentreID,
            EstimatorId, eStoreComments, InvoiceContactId, Comments, priority,
            EstCustomDate1, EstCustomDate2, EstCustomDate3, EstCustomDate4, EstCustomDate5)
        VALUES (
            @CompanyID, @UserID, @CustomerID, @AttentionID, @Greeting, @Company, @Address, @Header, @Footer,
            @SalesPerson, @EstimateTitle, @AssignedEstimateNumber, @OrderNumber, @StatusID, @EstimateDate, @ValidFor,
            @DeliveryAddress, @IsConvertedToJob, @IsForInvoice, @AddressType, @DeliveryAddressType,
            @EstimatedArtwork, @EstimatedDelivery, @CreatedDate, @IsDirectJob, @EstProofDate, @EstApprovalDate,
            @EstProductionDate, @EstCompletionDate, @InvoiceAddressID, @DepartmentID, @CostCentreID,
            @EstimatorId, @Comments, @InvoiceContactId, @Comments, @priority,
            @CustomDate1, @CustomDate2, @CustomDate3, @CustomDate4, @CustomDate5);

        SET @RID = IDENT_CURRENT('tb_Estimate');
        SET @ReturnID = @RID;

        UPDATE tb_LastCounter
        SET LastCounter = LastCounter + 1
        WHERE CompanyID = @CompanyID AND ModuleType = @CounterModule;
        IF @@ROWCOUNT = 0
            INSERT INTO tb_LastCounter (CompanyID, ModuleType, LastCounter) VALUES (@CompanyID, N'e', 1);
    END
    ELSE
    BEGIN
        UPDATE tb_Estimate
        SET CustomerID = @CustomerID,
            AttentionID = @AttentionID,
            Greeting = @Greeting,
            Company = @Company,
            Address = @Address,
            Header = @Header,
            Footer = @Footer,
            SalesPerson = @SalesPerson,
            EstimateTitle = @EstimateTitle,
            OrderNumber = @OrderNumber,
            StatusID = @StatusID,
            EstimateDate = @EstimateDate,
            ValidFor = @ValidFor,
            DeliveryAddress = @DeliveryAddress,
            ModifiedDate = @ModifiedDate,
            ModifiedBy = @ModifiedBy,
            AddressType = @AddressType,
            DeliveryAddressType = @DeliveryAddressType,
            EstimatedArtwork = @EstimatedArtwork,
            EstimatedDelivery = @EstimatedDelivery,
            CreatedDate = @CreatedDate,
            IsDirectJob = @IsDirectJob,
            EstProofDate = @EstProofDate,
            EstApprovalDate = @EstApprovalDate,
            EstProductionDate = @EstProductionDate,
            EstCompletionDate = @EstCompletionDate,
            InvoiceAddressID = @InvoiceAddressID,
            DepartmentID = @DepartmentID,
            CostCentreID = @CostCentreID,
            EstimatorId = @EstimatorId,
            eStoreComments = @Comments,
            Comments = @Comments,
            InvoiceContactId = @InvoiceContactId,
            priority = @priority,
            EstCustomDate1 = @CustomDate1,
            EstCustomDate2 = @CustomDate2,
            EstCustomDate3 = @CustomDate3,
            EstCustomDate4 = @CustomDate4,
            EstCustomDate5 = @CustomDate5
        WHERE EstimateID = @EstimateID;

        SET @RID = @EstimateID;
        SET @ReturnID = @RID;
    END
END
GO
