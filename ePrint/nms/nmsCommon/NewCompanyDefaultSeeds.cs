using System;
using System.Data.SqlClient;

namespace nmsCommon
{
	/// <summary>
	/// Built-in seed data for new company registration. Does not read template rows from the database.
	/// </summary>
	internal static class NewCompanyDefaultSeeds
	{
		public static void ApplyAll(int companyId, commonClass cmn)
		{
			if (companyId <= 0 || cmn == null)
			{
				return;
			}

			SqlConnection connection = cmn.openConnection();
			ApplyAll(companyId, connection);
		}

		public static void ApplyAll(int companyId, SqlConnection connection)
		{
			ApplyAll(companyId, connection, 102, "dd/mm/yyyy");
		}

		public static void ApplyAll(int companyId, SqlConnection connection, int timezoneId, string dateFormat)
		{
			if (companyId <= 0 || connection == null)
			{
				return;
			}

			RegistrationBootstrapSeeds.Apply(companyId, connection);
			ApplyStatuses(companyId, connection);
			ApplyLookupAndEstimateSettings(companyId, connection);
			ApplyWarehouseCodeCounters(companyId, connection);
			ApplyRegionalAndLanguageSettings(companyId, connection, timezoneId, dateFormat);
			ApplyThemeSettings(companyId, connection);
			ApplyPlantSettings(companyId, connection);
			ApplyCustomizeViews(companyId, connection);
		}

		/// <summary>
		/// UI theme and image folder (crm_selecttheme). Without this, strImagepath is empty and grid icons 404.
		/// </summary>
		public static void ApplyThemeSettings(int companyId, SqlConnection connection)
		{
			if (companyId <= 0 || connection == null)
			{
				return;
			}

			const string sql = @"
IF NOT EXISTS (SELECT 1 FROM tb_ThemeSetting WHERE CompanyID = @companyId)
	INSERT INTO tb_ThemeSetting (ImageFolder, theme, CompanyID, CreatedDate)
	VALUES (N'images', N'Theme1', @companyId, GETDATE());";

			Execute(companyId, connection, sql);
		}

		/// <summary>
		/// Seeds company language options (US/Canada English, UK English) and UK regional defaults
		/// used by Settings &gt; Regional Settings and estimate press loading.
		/// </summary>
		private static void ApplyRegionalAndLanguageSettings(int companyId, SqlConnection connection, int timezoneId, string dateFormat)
		{
			int fiscalYear = DateTime.Now.Year;
			if (DateTime.Now.Month < 7)
			{
				fiscalYear--;
			}
			DateTime fiscalFrom = new DateTime(fiscalYear, 7, 1);
			DateTime fiscalTo = new DateTime(fiscalYear + 1, 6, 1);

			const string sql = @"
IF NOT EXISTS (SELECT 1 FROM tb_Languages WHERE CompanyID = @companyId AND Languages = N'US/Canada English' AND IsDeleted = 0)
	INSERT INTO tb_Languages (CompanyID, Languages, CreatedDate, IsDeleted)
	VALUES (@companyId, N'US/Canada English', GETDATE(), 0);

IF NOT EXISTS (SELECT 1 FROM tb_Languages WHERE CompanyID = @companyId AND Languages = N'UK English' AND IsDeleted = 0)
	INSERT INTO tb_Languages (CompanyID, Languages, CreatedDate, IsDeleted)
	VALUES (@companyId, N'UK English', GETDATE(), 0);

DECLARE @ukLanguageId int;
SELECT @ukLanguageId = LanguageID FROM tb_Languages
WHERE CompanyID = @companyId AND Languages = N'UK English' AND IsDeleted = 0;

IF NOT EXISTS (SELECT 1 FROM tb_RegionalSettings WHERE CompanyID = @companyId AND IsDeleted = 0)
BEGIN
	INSERT INTO tb_RegionalSettings (
		CompanyID, LanguageID, Colour, Organisation, State, Centre, PostCode, Metre, Weight, PaperMeasure,
		PageTitle, CompanyTitle, CreatedDate, IsDeleted, DateFormat, TimeZoneID, Roundoff, FisCalFrom, FisCalTo,
		IsDisplayCostCentre, GeneralWeight, PaperMaterial)
	SELECT
		@companyId, @ukLanguageId, N'Color', N'Organisation', N'State', N'Centre', N'Post Code', N'Metre', N'gsm', N'mm',
		c.companyname, c.companyname, GETDATE(), 0, @dateFormat, @timezoneId, 2, @fiscalFrom, @fiscalTo,
		1, N'lbs', N'Micron'
	FROM tb_company c WHERE c.companyid = @companyId;
END
ELSE
BEGIN
	UPDATE rs SET
		LanguageID = @ukLanguageId,
		Colour = ISNULL(NULLIF(RTRIM(rs.Colour), N''), N'Color'),
		Organisation = ISNULL(NULLIF(RTRIM(rs.Organisation), N''), N'Organisation'),
		State = ISNULL(NULLIF(RTRIM(rs.State), N''), N'State'),
		Centre = ISNULL(NULLIF(RTRIM(rs.Centre), N''), N'Centre'),
		PostCode = ISNULL(NULLIF(RTRIM(rs.PostCode), N''), N'Post Code'),
		Metre = ISNULL(NULLIF(RTRIM(rs.Metre), N''), N'Metre'),
		Weight = ISNULL(NULLIF(RTRIM(rs.Weight), N''), N'gsm'),
		PaperMeasure = ISNULL(NULLIF(RTRIM(rs.PaperMeasure), N''), N'mm'),
		GeneralWeight = ISNULL(NULLIF(RTRIM(rs.GeneralWeight), N''), N'lbs'),
		PaperMaterial = ISNULL(NULLIF(RTRIM(rs.PaperMaterial), N''), N'Micron'),
		PageTitle = ISNULL(NULLIF(RTRIM(rs.PageTitle), N''), c.companyname),
		CompanyTitle = ISNULL(NULLIF(RTRIM(rs.CompanyTitle), N''), c.companyname),
		DateFormat = ISNULL(NULLIF(RTRIM(rs.DateFormat), N''), @dateFormat),
		TimeZoneID = CASE WHEN rs.TimeZoneID IS NULL OR rs.TimeZoneID = 0 THEN @timezoneId ELSE rs.TimeZoneID END,
		IsDisplayCostCentre = 1,
		FisCalFrom = ISNULL(rs.FisCalFrom, @fiscalFrom),
		FisCalTo = ISNULL(rs.FisCalTo, @fiscalTo)
	FROM tb_RegionalSettings rs
	INNER JOIN tb_company c ON c.companyid = rs.CompanyID
	WHERE rs.CompanyID = @companyId AND rs.IsDeleted = 0;
END";

			using (SqlCommand command = new SqlCommand(sql, connection))
			{
				command.Parameters.AddWithValue("@companyId", companyId);
				command.Parameters.AddWithValue("@timezoneId", timezoneId);
				command.Parameters.AddWithValue("@dateFormat", dateFormat ?? "dd/mm/yyyy");
				command.Parameters.AddWithValue("@fiscalFrom", fiscalFrom);
				command.Parameters.AddWithValue("@fiscalTo", fiscalTo);
				command.ExecuteNonQuery();
			}
		}

		/// <summary>
		/// Auto-increment counters for inventory codes (type i) and related warehouse sequences (c, s).
		/// Required by inventory_add Page_Load via PC_warehouse_code_select.
		/// </summary>

		private static void ApplyWarehouseCodeCounters(int companyId, SqlConnection connection)
		{
			const string sql = @"
IF NOT EXISTS (SELECT 1 FROM tb_WareHouseCode WHERE CompanyID = @companyId AND Type = 'i')
	INSERT INTO tb_WareHouseCode (CompanyID, Type, LastCount, CreatedDate) VALUES (@companyId, 'i', 10000000, GETDATE());
IF NOT EXISTS (SELECT 1 FROM tb_WareHouseCode WHERE CompanyID = @companyId AND Type = 'c')
	INSERT INTO tb_WareHouseCode (CompanyID, Type, LastCount, CreatedDate) VALUES (@companyId, 'c', 10000000, GETDATE());
IF NOT EXISTS (SELECT 1 FROM tb_WareHouseCode WHERE CompanyID = @companyId AND Type = 's')
	INSERT INTO tb_WareHouseCode (CompanyID, Type, LastCount, CreatedDate) VALUES (@companyId, 's', 10000000, GETDATE());
";
			Execute(companyId, connection, sql);
		}

		/// <summary>
		/// Inserts list/grid views (tb_CustomizeView) for Customer, Estimate, Job, Invoice, etc.
		/// Proof views are created separately via PC_CustomizeViewIfNotExist.
		/// </summary>
		public static void ApplyCustomizeViews(int companyId, SqlConnection connection)
		{
			if (companyId <= 0 || connection == null)
			{
				return;
			}

			Execute(companyId, connection, CustomizeViewsSql);
		}

		private const string CustomizeViewInsertColumns = @"
CompanyID, ViewName, ColumnNames, condition1, condition2, condition3, condition4, condition5,
operator1, operator2, operator3, operator4, operator5, value1, value2, value3, value4, value5,
isDeleted, CreatedBy, UpdatedBy, isDefault, SortedBy, SortDirection, PageName,
isShowAllRecords, iszerothview, CondnalOpertr1, CondnalOpertr2, CondnalOpertr3, CondnalOpertr4, CustomerType,
IsItemSelected, RecordsToDisplay";

		private const string CustomizeViewDefaults = @"
N'none', N'none', N'none', N'none', N'none',
N'None', N'None', N'None', N'None', N'None', N'', N'', N'', N'', N'',
0, 0, 0, ";

		// Full column lists from reference tenant (2144); do not truncate (256-char cuts produced invalid names like Deliv).
		private const string JobDefaultViewColumns =
			@"EstimateType,DownloadTemplate,JobNumber,EstimateTitle,CustomerID,AttentionID,SalesPerson,JobDate,EstimateValue_ExcGst,EstimateValue,ProductionDate,Comments,PONumber,ItemValueExcTax,ItemValueInTax,ItemTaxValue,ItemProfitMarginValue,ItemGrossProfitValue,JobStatus,DeliveryDate,CompletionDate,CustomDate1,CustomDate2,CustomDate3,CustomDate4,CustomDate5,Priority,sinceStatusUpdate,sinceEmailed,Archive,IsFromWebStore,OrderID,ProformaInvoice,Paid,EstItemCoun,";

		private const string InvoiceDefaultViewColumns =
			@"ChooseTemplate,InvoiceNumber,EstimateTitle,CustomerID,AttentionID,CustomerOrderNumber,CreatedDate,EstimateValue_ExcGst,Comments,InvoiceStatus,[Job Number],Priority,sinceStatusUpdate,sinceEmailed,CustomDate1,Archive,CustomDate2,IsFromWebStore,OrderID,EstItemCoun,";

		private const string WebstoreOrderDefaultViewColumns =
			@"OrderNumber,CustomerID,SalesPerson,OrderTitle,StatusID,OrderedDate,FTP,CreatedDate,OrderValue,DeliveryAddress,Comments,OrderedFor,OrderedBy,Approved,PaymentType,ItemArtwork,DefaultTemplate,ChooseTemplate,DownloadTemplate,sinceStatusUpdate,sinceEmailed,Archive,CustomDate1,CustomDate2,CustomDate3,EstItemCoun,IsCompletlyConvertedToJob,IsArchived,IsDeletedJob,estimateid,";

		private const string CustomizeViewsSql = @"
IF NOT EXISTS (SELECT 1 FROM tb_CustomizeView WHERE CompanyID = @companyId AND PageName = N'customer' AND ViewName = N'ALL' AND ISNULL(isDeleted, 0) = 0)
INSERT INTO tb_CustomizeView (" + CustomizeViewInsertColumns + @") VALUES (
@companyId, N'ALL', N'Name,AccountNumber,Type,AccountStatus,SalesPerson,DefaultContactName,DefaultContactEmail,DefaultContactPhone,DefaultContactMobile,', " + CustomizeViewDefaults + @"0, N'Name', N'asc', N'customer', 0, 1, N'And', N'And', N'And', N'And', N'', 0, N'');

IF NOT EXISTS (SELECT 1 FROM tb_CustomizeView WHERE CompanyID = @companyId AND PageName = N'customer' AND ViewName = N'Estore' AND ISNULL(isDeleted, 0) = 0)
INSERT INTO tb_CustomizeView (" + CustomizeViewInsertColumns + @") VALUES (
@companyId, N'Estore', N'Name,AccountNumber,Type,AccountStatus,SalesPerson,DefaultContactName,DefaultContactEmail,DefaultContactPhone,DefaultContactMobile,', " + CustomizeViewDefaults + @"0, N'Name', N'asc', N'customer', 0, 1, N'And', N'And', N'And', N'And', N'', 0, N'');

IF NOT EXISTS (SELECT 1 FROM tb_CustomizeView WHERE CompanyID = @companyId AND PageName = N'Estimate' AND ViewName = N'Default View' AND ISNULL(isDeleted, 0) = 0)
INSERT INTO tb_CustomizeView (" + CustomizeViewInsertColumns + @") VALUES (
@companyId, N'Default View', N'ChooseTemplate,EstimateNumber,EstimateTitle,CustomerID,AttentionID,EstimateDate,EstimateValue,EstimateStatus,EstimateType,EstItemCoun,IsArchive,IsConvertedToJob,ISDeletedJob,', " + CustomizeViewDefaults + @"1, N'EstimateNumber', N'desc', N'Estimate', 0, 1, N'And', N'And', N'And', N'And', N'', 0, N'Live');

IF NOT EXISTS (SELECT 1 FROM tb_CustomizeView WHERE CompanyID = @companyId AND PageName = N'Estimate' AND ViewName = N'Archived Records View' AND ISNULL(isDeleted, 0) = 0)
INSERT INTO tb_CustomizeView (" + CustomizeViewInsertColumns + @") VALUES (
@companyId, N'Archived Records View', N'ChooseTemplate,EstimateNumber,EstimateTitle,CustomerID,AttentionID,SalesPerson,EstimateDate,EstimateValue,Comments,EstimateStatus,EstItemCoun,IsArchive,IsConvertedToJob,ISDeletedJob,', " + CustomizeViewDefaults + @"0, N'EstimateNumber', N'desc', N'Estimate', 0, 1, N'And', N'And', N'And', N'And', N'', 0, N'Archive');

IF NOT EXISTS (SELECT 1 FROM tb_CustomizeView WHERE CompanyID = @companyId AND PageName = N'Estimate' AND ViewName = N'Item View' AND ISNULL(isDeleted, 0) = 0)
INSERT INTO tb_CustomizeView (" + CustomizeViewInsertColumns + @") VALUES (
@companyId, N'Item View', N'ChooseTemplate,EstimateNumber,EstimateTitle,ItemTitle,CustomerID,AttentionID,SalesPerson,EstimateDate,EstimateValue,Comments,EstimateStatus,ItemQuantity1,ItemQuantity2,ItemQuantity3,ItemQuantity4,EstItemCoun,IsArchive,IsConvertedToJob,ISDeletedJob,', " + CustomizeViewDefaults + @"0, N'EstimateNumber', N'desc', N'Estimate', 0, 1, N'And', N'And', N'And', N'And', N'', 1, N'Live');

IF NOT EXISTS (SELECT 1 FROM tb_CustomizeView WHERE CompanyID = @companyId AND PageName = N'job' AND ViewName = N'Default View' AND ISNULL(isDeleted, 0) = 0)
INSERT INTO tb_CustomizeView (" + CustomizeViewInsertColumns + @") VALUES (
@companyId, N'Default View', N'" + JobDefaultViewColumns + @"', " + CustomizeViewDefaults + @"1, N'JobDate', N'desc', N'job', 0, 1, N'And', N'And', N'And', N'And', N'', 1, N'Live');

IF NOT EXISTS (SELECT 1 FROM tb_CustomizeView WHERE CompanyID = @companyId AND PageName = N'job' AND ViewName = N'Archived Records View' AND ISNULL(isDeleted, 0) = 0)
INSERT INTO tb_CustomizeView (" + CustomizeViewInsertColumns + @") VALUES (
@companyId, N'Archived Records View', N'DownloadTemplate,JobNumber,EstimateTitle,CustomerID,AttentionID,SalesPerson,JobDate,EstimateValue_ExcGst,ProductionDate,DeliveryDate,Comments,JobStatus,IsFromWebStore,OrderID,ProformaInvoice,Paid,EstItemCoun,', " + CustomizeViewDefaults + @"0, N'JobDate', N'desc', N'job', 0, 1, N'And', N'And', N'And', N'And', N'', 0, N'Archive');

IF NOT EXISTS (SELECT 1 FROM tb_CustomizeView WHERE CompanyID = @companyId AND PageName = N'job' AND ViewName = N'Item View' AND ISNULL(isDeleted, 0) = 0)
INSERT INTO tb_CustomizeView (" + CustomizeViewInsertColumns + @") VALUES (
@companyId, N'Item View', N'DownloadTemplate,JobNumber,EstimateTitle,ItemTitle,CustomerID,AttentionID,SalesPerson,JobDate,EstimateValue_ExcGst,ProductionDate,DeliveryDate,Comments,JobStatus,IsFromWebStore,OrderID,ProformaInvoice,Paid,EstItemCoun,', " + CustomizeViewDefaults + @"0, N'DeliveryDate', N'desc', N'job', 0, 1, N'And', N'And', N'And', N'And', N'', 1, N'Live');

IF NOT EXISTS (SELECT 1 FROM tb_CustomizeView WHERE CompanyID = @companyId AND PageName = N'invoice' AND ViewName = N'Default View' AND ISNULL(isDeleted, 0) = 0)
INSERT INTO tb_CustomizeView (" + CustomizeViewInsertColumns + @") VALUES (
@companyId, N'Default View', N'" + InvoiceDefaultViewColumns + @"', " + CustomizeViewDefaults + @"1, N'InvoiceNumber', N'desc', N'invoice', 0, 1, N'And', N'And', N'And', N'And', N'', 0, N'Live');

IF NOT EXISTS (SELECT 1 FROM tb_CustomizeView WHERE CompanyID = @companyId AND PageName = N'invoice' AND ViewName = N'Archive View' AND ISNULL(isDeleted, 0) = 0)
INSERT INTO tb_CustomizeView (" + CustomizeViewInsertColumns + @") VALUES (
@companyId, N'Archive View', N'ChooseTemplate,InvoiceNumber,EstimateTitle,CustomerID,AttentionID,CustomerOrderNumber,CreatedDate,EstimateValue_ExcGst,Comments,InvoiceStatus,IsFromWebStore,OrderID,EstItemCoun,', " + CustomizeViewDefaults + @"0, N'InvoiceNumber', N'desc', N'invoice', 0, 1, N'And', N'And', N'And', N'And', N'', 0, N'Archive');

IF NOT EXISTS (SELECT 1 FROM tb_CustomizeView WHERE CompanyID = @companyId AND PageName = N'purchase' AND ViewName = N'Default View' AND ISNULL(isDeleted, 0) = 0)
INSERT INTO tb_CustomizeView (" + CustomizeViewInsertColumns + @") VALUES (
@companyId, N'Default View', N'ChooseTemplate,PONO,JobNumber,JobTitle,SupplierName,PODate,POPrice,Comments,Status,ItemTitle,sinceStatusUpdate,sinceEmailed,CustomDate1,CustomDate2,CustomDate3,Archive,EstItemCoun,', " + CustomizeViewDefaults + @"1, N'PONO', N'desc', N'purchase', 0, 1, N'And', N'And', N'And', N'And', N'', 1, N'Live');

IF NOT EXISTS (SELECT 1 FROM tb_CustomizeView WHERE CompanyID = @companyId AND PageName = N'deliverynote' AND ViewName = N'Default View' AND ISNULL(isDeleted, 0) = 0)
INSERT INTO tb_CustomizeView (" + CustomizeViewInsertColumns + @") VALUES (
@companyId, N'Default View', N'ChooseTemplate,DeliveryNumber,JobNumber,JobTitle,CustomerID,OrderNo,[Consignment Number],[Carrier Information],Comments,Status,sinceStatusUpdate,sinceEmailed,CustomDate1,CustomDate2,Archive,EstItemCoun,', " + CustomizeViewDefaults + @"1, N'DeliveryNumber', N'desc', N'deliverynote', 0, 1, N'And', N'And', N'And', N'And', N'', 0, N'Live');

IF NOT EXISTS (SELECT 1 FROM tb_CustomizeView WHERE CompanyID = @companyId AND PageName = N'inventory' AND ViewName = N'Default View' AND ISNULL(isDeleted, 0) = 0)
INSERT INTO tb_CustomizeView (" + CustomizeViewInsertColumns + @") VALUES (
@companyId, N'Default View', N'InventoryCode,InventoryName,Description,CustomStockType,customheight,SupplierName,Cost,UnitPrice,AvailableQuantity,Action,', " + CustomizeViewDefaults + @"1, N'InventoryName', N'asc', N'inventory', 0, 1, N'And', N'And', N'And', N'And', N'', 1, N'Live');

IF NOT EXISTS (SELECT 1 FROM tb_CustomizeView WHERE CompanyID = @companyId AND PageName = N'InventorySelectView' AND ViewName = N'Default View' AND ISNULL(isDeleted, 0) = 0)
INSERT INTO tb_CustomizeView (" + CustomizeViewInsertColumns + @") VALUES (
@companyId, N'Default View', N'InventoryCode,InventoryName,Cost,SupplierName,UnitPrice,Description,', " + CustomizeViewDefaults + @"1, N'', N'asc', N'InventorySelectView', 0, 1, N'And', N'And', N'And', N'And', N'', 0, N'Live');

IF NOT EXISTS (SELECT 1 FROM tb_CustomizeView WHERE CompanyID = @companyId AND PageName = N'accounts' AND ViewName = N'Default View' AND ISNULL(isDeleted, 0) = 0)
INSERT INTO tb_CustomizeView (" + CustomizeViewInsertColumns + @") VALUES (
@companyId, N'Default View', N'AccountName,ClientName,AccountPrefix,CreatedBy,DefaultContactID', " + CustomizeViewDefaults + @"1, N'AccountName', N'asc', N'accounts', 0, 1, N'And', N'And', N'And', N'And', N'', 0, N'Live');

IF NOT EXISTS (SELECT 1 FROM tb_CustomizeView WHERE CompanyID = @companyId AND PageName = N'supplier' AND ViewName = N'Default View' AND ISNULL(isDeleted, 0) = 0)
INSERT INTO tb_CustomizeView (" + CustomizeViewInsertColumns + @") VALUES (
@companyId, N'Default View', N'Name,Type,AccountStatus,BusinessTelephone,BusinessEmail,', " + CustomizeViewDefaults + @"0, N'', N'asc', N'supplier', 0, 1, N'And', N'And', N'And', N'And', N'', 0, N'Live');

IF NOT EXISTS (SELECT 1 FROM tb_CustomizeView WHERE CompanyID = @companyId AND PageName = N'prospect' AND ViewName = N'Default View' AND ISNULL(isDeleted, 0) = 0)
INSERT INTO tb_CustomizeView (" + CustomizeViewInsertColumns + @") VALUES (
@companyId, N'Default View', N'Name,Type,AccountStatus,BusinessTelephone,BusinessEmail,', " + CustomizeViewDefaults + @"0, N'', N'asc', N'prospect', 0, 1, N'And', N'And', N'And', N'And', N'', 0, N'Live');

IF NOT EXISTS (SELECT 1 FROM tb_CustomizeView WHERE CompanyID = @companyId AND PageName = N'productcatalogue' AND ViewName = N'Default View' AND ISNULL(isDeleted, 0) = 0)
INSERT INTO tb_CustomizeView (" + CustomizeViewInsertColumns + @") VALUES (
@companyId, N'Default View', N'CategoryName,ItemTitle,Description,AllocatedCustomer,ProductType,ItemCode,Supplier,Action,', " + CustomizeViewDefaults + @"1, N'CategoryName', N'asc', N'productcatalogue', 0, 1, N'And', N'And', N'And', N'And', N'', 1, N'');

IF NOT EXISTS (SELECT 1 FROM tb_CustomizeView WHERE CompanyID = @companyId AND PageName = N'webstoreorder' AND ViewName = N'Default View' AND ISNULL(isDeleted, 0) = 0)
INSERT INTO tb_CustomizeView (" + CustomizeViewInsertColumns + @") VALUES (
@companyId, N'Default View', N'" + WebstoreOrderDefaultViewColumns + @"', " + CustomizeViewDefaults + @"1, N'', N'asc', N'webstoreorder', 0, 1, N'And', N'And', N'And', N'And', N'', 1, N'Live');";

		public static void ApplyStatuses(int companyId, SqlConnection connection)
		{
			const string sql = @"
IF NOT EXISTS (SELECT 1 FROM tb_EstimateStatus WHERE companyid = @companyId)
BEGIN
	INSERT INTO tb_EstimateStatus (
		CompanyID, StatusTitle, UserFriendlyName, IsDefault, Estimate, EstimateDefault, Job, JobDefault,
		Invoice, InvoiceDefault, Delivery, DeliveryDefault, Purchase, PurchaseDefault, Orders, OrdersDefault)
	VALUES
		(@companyId, N'In Progress', N'In Progress', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
		(@companyId, N'Completed', N'Completed', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
		(@companyId, N'Ready for Invoice', N'Ready for Invoice', 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0),
		(@companyId, N'On Hold', N'On Hold', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
		(@companyId, N'Approved', N'Approved', 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0),
		(@companyId, N'Not Approved', N'Not Approved', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
		(@companyId, N'Press', N'Press', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
		(@companyId, N'Requested', N'Requested', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
		(@companyId, N'In Production', N'In Production', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
		(@companyId, N'RFQ', N'RFQ', 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
		(@companyId, N'Cancelled', N'Cancelled', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
		(@companyId, N'New Del. Note', N'New Del. Note', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0),
		(@companyId, N'Awaiting Authorization', N'Awaiting Authorization', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0),
		(@companyId, N'Locked', N'Locked', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
END
ELSE
BEGIN
	IF NOT EXISTS (SELECT 1 FROM tb_EstimateStatus WHERE companyid = @companyId AND Purchase = 1)
		UPDATE tb_EstimateStatus SET Purchase = 1, PurchaseDefault = 1
		WHERE companyid = @companyId AND StatusTitle = N'Awaiting Authorization';
	IF NOT EXISTS (SELECT 1 FROM tb_EstimateStatus WHERE companyid = @companyId AND Delivery = 1)
		UPDATE tb_EstimateStatus SET Delivery = 1, DeliveryDefault = 1
		WHERE companyid = @companyId AND StatusTitle = N'New Del. Note';
	IF NOT EXISTS (SELECT 1 FROM tb_EstimateStatus WHERE companyid = @companyId AND Invoice = 1)
		UPDATE tb_EstimateStatus SET Invoice = 1, InvoiceDefault = 1
		WHERE companyid = @companyId AND StatusTitle = N'Ready for Invoice';
END
IF NOT EXISTS (SELECT 1 FROM tb_AccountStatus WHERE CompanyID = @companyId)
	INSERT INTO tb_AccountStatus (CompanyID, StatusTitle) VALUES (@companyId, N'Accounts Clear')
IF NOT EXISTS (SELECT 1 FROM tb_contractstatus WHERE companyid = @companyId)
	INSERT INTO tb_contractstatus (contractstatus, languagename, companyid) VALUES (N'Active', N'English', @companyId)
IF NOT EXISTS (SELECT 1 FROM tb_assetstatus WHERE companyid = @companyId)
	INSERT INTO tb_assetstatus (assetstatus, companyid, languagename) VALUES (N'Active', @companyId, N'English')
IF NOT EXISTS (SELECT 1 FROM tb_leadstatus WHERE companyid = @companyId)
	INSERT INTO tb_leadstatus (leadstatusname, companyid, languagename) VALUES (N'New', @companyId, N'English')
IF NOT EXISTS (SELECT 1 FROM tb_taskstatus WHERE companyID = @companyId)
	INSERT INTO tb_taskstatus (taskStatus, companyID, languagename) VALUES (N'Open', @companyId, N'English')
IF NOT EXISTS (SELECT 1 FROM tb_ticketstatus WHERE companyid = @companyId)
	INSERT INTO tb_ticketstatus (companyid, ticketstatus, languagename) VALUES (@companyId, N'Open', N'English')
IF NOT EXISTS (SELECT 1 FROM tb_solutionstatus WHERE companyid = @companyId)
	INSERT INTO tb_solutionstatus (companyid, solutionStatus, languagename) VALUES (@companyId, N'Draft', N'English')
IF NOT EXISTS (SELECT 1 FROM tb_campaignStatus WHERE companyId = @companyId)
	INSERT INTO tb_campaignStatus (companyId, campaignStatus, languagename) VALUES (@companyId, N'Planned', N'English')";

			Execute(companyId, connection, sql);
		}

		public static void ApplyLookupAndEstimateSettings(int companyId, SqlConnection connection)
		{
			const string sql = @"
IF NOT EXISTS (SELECT 1 FROM tb_Numbering WHERE CompanyID = @companyId)
	INSERT INTO tb_Numbering (CompanyID, Estimates, Jobs, Invoices, Purchases, Delivery, [Type])
	VALUES (@companyId, 0, 0, 0, 0, 0, N'')
IF NOT EXISTS (SELECT 1 FROM tb_markup WHERE CompanyID = @companyId)
BEGIN
	INSERT INTO tb_markup (CompanyID, MarkupName, MarkupRate) VALUES
		(@companyId, N'0%', 0),
		(@companyId, N'5%', 5),
		(@companyId, N'10%', 10)
END
IF NOT EXISTS (SELECT 1 FROM tb_taxrates WHERE CompanyID = @companyId AND ISNULL(IsDeleted, 0) = 0)
BEGIN
	INSERT INTO tb_taxrates (CompanyID, TaxName, TaxRate, CreatedDate, IsDeleted) VALUES
		(@companyId, N'Tax 1', 0, GETDATE(), 0),
		(@companyId, N'Tax 2', 17.5, GETDATE(), 0)
END
IF NOT EXISTS (SELECT 1 FROM tb_SystemMarkup WHERE CompanyID = @companyId)
	INSERT INTO tb_SystemMarkup (CompanyID, Paper, PrintBroker, Inks, InventoryItems, OtherCosts, MarkupID, TaxID, RoundUpTotals)
	SELECT @companyId, 10, 30, 0, 30, 0,
		(SELECT TOP 1 MarkupID FROM tb_markup WHERE CompanyID = @companyId ORDER BY MarkupID),
		(SELECT TOP 1 TaxID FROM tb_taxrates WHERE CompanyID = @companyId AND ISNULL(IsDeleted, 0) = 0 ORDER BY TaxID),
		0
IF NOT EXISTS (SELECT 1 FROM tb_stockcategory WHERE CompanyID = @companyId AND CategoryCode = N'Paper' AND ISNULL(IsDeleted, 0) = 0)
	INSERT INTO tb_stockcategory (
		CompanyID, CategoryCode, CategoryName, Description, IsWeight, IsColor, IsItemCustomSize, IsItemPaperSize,
		IsCoatingType, IsCoated, IsExposure, IsProcessingCharge, CreatedDate, IsDeleted)
	VALUES (@companyId, N'Paper', N'Paper', N'Paper stock', 1, 0, 1, 1, 0, 0, 0, 0, GETDATE(), 0)
IF NOT EXISTS (SELECT 1 FROM tb_stockcategory WHERE CompanyID = @companyId AND CategoryCode = N'Inks' AND ISNULL(IsDeleted, 0) = 0)
	INSERT INTO tb_stockcategory (
		CompanyID, CategoryCode, CategoryName, Description, IsWeight, IsColor, IsItemCustomSize, IsItemPaperSize,
		IsCoatingType, IsCoated, IsExposure, IsProcessingCharge, CreatedDate, IsDeleted)
	VALUES (@companyId, N'Inks', N'Inks', N'Ink stock', 0, 1, 0, 0, 0, 0, 0, 0, GETDATE(), 0)
IF NOT EXISTS (SELECT 1 FROM tb_stockcategory WHERE CompanyID = @companyId AND CategoryCode = N'Plates' AND ISNULL(IsDeleted, 0) = 0)
	INSERT INTO tb_stockcategory (
		CompanyID, CategoryCode, CategoryName, Description, IsWeight, IsColor, IsItemCustomSize, IsItemPaperSize,
		IsCoatingType, IsCoated, IsExposure, IsProcessingCharge, CreatedDate, IsDeleted)
	VALUES (@companyId, N'Plates', N'Plates', N'Plates', 0, 0, 1, 0, 0, 0, 0, 0, GETDATE(), 0)
IF NOT EXISTS (SELECT 1 FROM tb_papersize WHERE companyid = @companyId AND PaperSizeName = N'A4' AND ISNULL(IsDeleted, 0) = 0)
	INSERT INTO tb_papersize (PaperSizeName, CompanyID, Height, Width, OrderSize, CreatedDate, IsDeleted, OrderNumber)
	VALUES (N'A4', @companyId, 210, 297, N'No', GETDATE(), 0, 1)
IF NOT EXISTS (SELECT 1 FROM tb_papersize WHERE companyid = @companyId AND PaperSizeName = N'SRA3' AND ISNULL(IsDeleted, 0) = 0)
	INSERT INTO tb_papersize (PaperSizeName, CompanyID, Height, Width, OrderSize, CreatedDate, IsDeleted, OrderNumber)
	VALUES (N'SRA3', @companyId, 320, 450, N'No', GETDATE(), 0, 2)
IF NOT EXISTS (SELECT 1 FROM tb_defaultsettings WHERE CompanyID = @companyId AND ISNULL(IsDeleted, 0) = 0)
	INSERT INTO tb_defaultsettings (CompanyID, DefaultPriceForWholePack, IsDeleted, DefaultEstimateType, ValidFor, Roundoff, OutworkMarkuptype)
	VALUES (@companyId, 0, 0, N'SheetFedDigital', 0, 2, 0)
IF NOT EXISTS (SELECT 1 FROM tb_OtherCostCategory WHERE CompanyID = @companyId AND ISNULL(IsDeleted, 0) = 0)
	INSERT INTO tb_OtherCostCategory (CompanyID, OtherCostCategoryName, PreStatus, JobcardCategory)
	SELECT @companyId, N'Admin',
		(SELECT TOP 1 StatusID FROM tb_EstimateStatus WHERE companyid = @companyId ORDER BY StatusID),
		N''
IF NOT EXISTS (SELECT 1 FROM tb_OtherCost WHERE CompanyID = @companyId AND OtherCostName = N'Sample Admin Cost' AND ISNULL(IsDeleted, 0) = 0)
	INSERT INTO tb_OtherCost (
		CompanyID, OtherCostName, Description, OtherCostCategoryID, CalculationType, CostTimeBasedID,
		SupplierID, PerHourCost, Profit, Minimum, CreatedDate, IsDeleted, Formula, AccountCodeID)
	SELECT @companyId, N'Sample Admin Cost', N'Sample admin charge for new tenants',
		(SELECT TOP 1 OtherCostCategoryID FROM tb_OtherCostCategory WHERE CompanyID = @companyId AND ISNULL(IsDeleted, 0) = 0 ORDER BY OtherCostCategoryID),
		N'f', 0, 0, 0, 0, 0, GETDATE(), 0, N'', 0
IF NOT EXISTS (SELECT 1 FROM tb_ItemDescription WHERE CompanyID = @companyId)
BEGIN
	INSERT INTO tb_ItemDescription (CompanyID, EstimateType, DatabaseFieldName, ScreenName, IsChecked, DisplayOrder) VALUES
		(@companyId, N'L', N'ItemTitle', N'Item Title', 1, 1),
		(@companyId, N'L', N'Description', N'Item Description', 1, 2),
		(@companyId, N'L', N'Artwork', N'Artwork', 1, 3),
		(@companyId, N'L', N'Colour', N'Colour', 1, 4),
		(@companyId, N'L', N'Size', N'Size', 1, 5),
		(@companyId, N'S', N'ItemTitle', N'Item Title', 1, 1),
		(@companyId, N'S', N'Description', N'Item Description', 1, 2),
		(@companyId, N'O', N'ItemTitle', N'Item Title', 1, 1),
		(@companyId, N'O', N'Description', N'Item Description', 1, 2),
		(@companyId, N'O', N'Artwork', N'Artwork', 1, 3),
		(@companyId, N'O', N'Colour', N'Colour', 1, 4),
		(@companyId, N'O', N'Size', N'Size', 1, 5),
		(@companyId, N'O', N'Material', N'Material', 1, 6),
		(@companyId, N'O', N'Delivery', N'Delivery', 1, 7),
		(@companyId, N'O', N'Finishing', N'Finishing', 1, 8),
		(@companyId, N'O', N'Proofs', N'Proofs', 1, 9),
		(@companyId, N'O', N'Packing', N'Packing', 1, 10),
		(@companyId, N'O', N'Notes', N'Notes', 1, 11),
		(@companyId, N'O', N'Instructions', N'Instructions', 1, 12)
END
ELSE IF NOT EXISTS (SELECT 1 FROM tb_ItemDescription WHERE CompanyID = @companyId AND EstimateType = N'O' AND DatabaseFieldName = N'Artwork')
BEGIN
	INSERT INTO tb_ItemDescription (CompanyID, EstimateType, DatabaseFieldName, ScreenName, IsChecked, DisplayOrder) VALUES
		(@companyId, N'O', N'Artwork', N'Artwork', 1, 3),
		(@companyId, N'O', N'Colour', N'Colour', 1, 4),
		(@companyId, N'O', N'Size', N'Size', 1, 5),
		(@companyId, N'O', N'Material', N'Material', 1, 6),
		(@companyId, N'O', N'Delivery', N'Delivery', 1, 7),
		(@companyId, N'O', N'Finishing', N'Finishing', 1, 8),
		(@companyId, N'O', N'Proofs', N'Proofs', 1, 9),
		(@companyId, N'O', N'Packing', N'Packing', 1, 10),
		(@companyId, N'O', N'Notes', N'Notes', 1, 11),
		(@companyId, N'O', N'Instructions', N'Instructions', 1, 12);
	UPDATE tb_ItemDescription SET DisplayOrder = 1 WHERE CompanyID = @companyId AND EstimateType = N'O' AND DatabaseFieldName = N'ItemTitle' AND DisplayOrder IS NULL;
	UPDATE tb_ItemDescription SET DisplayOrder = 2 WHERE CompanyID = @companyId AND EstimateType = N'O' AND DatabaseFieldName = N'Description' AND DisplayOrder IS NULL;
END
IF NOT EXISTS (SELECT 1 FROM tb_CustomerCode WHERE CompanyID = @companyId)
	INSERT INTO tb_CustomerCode (CompanyID, LastCounter) VALUES (@companyId, 0)
IF NOT EXISTS (SELECT 1 FROM tb_lastCounter WHERE CompanyID = @companyId)
BEGIN
	INSERT INTO tb_lastCounter (CompanyID, ModuleType, LastCounter) VALUES
		(@companyId, N'e', 0),
		(@companyId, N'j', 0),
		(@companyId, N'i', 0),
		(@companyId, N'p', 0),
		(@companyId, N'd', 0),
		(@companyId, N'o', 0),
		(@companyId, N'Estimate', 0),
		(@companyId, N'Job', 0),
		(@companyId, N'Invoice', 0)
END
IF NOT EXISTS (SELECT 1 FROM tb_LastCounter WHERE CompanyID = @companyId AND ModuleType = N'p')
	INSERT INTO tb_LastCounter (CompanyID, ModuleType, LastCounter) VALUES (@companyId, N'p', 0);
IF NOT EXISTS (SELECT 1 FROM tb_LastCounter WHERE CompanyID = @companyId AND ModuleType = N'd')
	INSERT INTO tb_LastCounter (CompanyID, ModuleType, LastCounter) VALUES (@companyId, N'd', 0);
IF NOT EXISTS (SELECT 1 FROM tb_LastCounter WHERE CompanyID = @companyId AND ModuleType = N'o')
	INSERT INTO tb_LastCounter (CompanyID, ModuleType, LastCounter) VALUES (@companyId, N'o', 0);
IF NOT EXISTS (SELECT 1 FROM tb_accountingCode WHERE CompanyID = @companyId)
	INSERT INTO tb_accountingCode (CompanyID, Code, Description, IsDefault, InUse) VALUES (@companyId, N'4000', N'Sales', 1, 1)
IF NOT EXISTS (SELECT 1 FROM tb_frmemailsettings WHERE CompanyID = @companyId)
	INSERT INTO tb_frmemailsettings (CompanyID, FromEmail) VALUES (@companyId, N'')
IF NOT EXISTS (SELECT 1 FROM tb_WarehouseLocation WHERE CompanyID = @companyId AND ISNULL(IsDeleted, 0) = 0)
	INSERT INTO tb_WarehouseLocation (
		CompanyID, LocationName, Address, City, State, Zipcode, Country, Telephone, Isdefault, Inuse, IsDeleted)
	VALUES (@companyId, N'Main', N'123 Warehouse St', N'Sydney', N'NSW', N'2000', N'Australia', N'', 1, 1, 0)";

			Execute(companyId, connection, sql);
		}

		/// <summary>
		/// Seeds one default plant per estimate family: Sheet Fed Offset (litho), Sheet Fed Digital, Large Format.
		/// Values are hardcoded (based on company 2144 templates); does not read from the database at runtime.
		/// </summary>
		public static void ApplyPlantSettings(int companyId, SqlConnection connection)
		{
			const string sql = @"
DECLARE @paperCategoryId bigint, @inkCategoryId bigint, @plateCategoryId bigint;
DECLARE @printSheetId int, @jobSizeId int;
DECLARE @guillotineId bigint, @largeGuillotineId bigint;
DECLARE @paperInventoryId bigint, @inkInventoryId bigint, @plateInventoryId bigint;
DECLARE @pressId bigint, @digitalPressId bigint, @largePressId bigint, @clickChargeLookupId bigint;

SELECT @paperCategoryId = CategoryID FROM tb_stockcategory WHERE CompanyID = @companyId AND CategoryCode = N'Paper' AND ISNULL(IsDeleted, 0) = 0;
SELECT @inkCategoryId = CategoryID FROM tb_stockcategory WHERE CompanyID = @companyId AND CategoryCode = N'Inks' AND ISNULL(IsDeleted, 0) = 0;
SELECT @plateCategoryId = CategoryID FROM tb_stockcategory WHERE CompanyID = @companyId AND CategoryCode = N'Plates' AND ISNULL(IsDeleted, 0) = 0;

IF @paperCategoryId IS NULL
BEGIN
	INSERT INTO tb_stockcategory (CompanyID, CategoryCode, CategoryName, Description, IsWeight, IsColor, IsItemCustomSize, IsItemPaperSize, IsCoatingType, IsCoated, IsExposure, IsProcessingCharge, CreatedDate, IsDeleted)
	VALUES (@companyId, N'Paper', N'Paper', N'Paper stock', 1, 0, 1, 1, 0, 0, 0, 0, GETDATE(), 0);
	SET @paperCategoryId = SCOPE_IDENTITY();
END
IF @inkCategoryId IS NULL
BEGIN
	INSERT INTO tb_stockcategory (CompanyID, CategoryCode, CategoryName, Description, IsWeight, IsColor, IsItemCustomSize, IsItemPaperSize, IsCoatingType, IsCoated, IsExposure, IsProcessingCharge, CreatedDate, IsDeleted)
	VALUES (@companyId, N'Inks', N'Inks', N'Ink stock', 0, 1, 0, 0, 0, 0, 0, 0, GETDATE(), 0);
	SET @inkCategoryId = SCOPE_IDENTITY();
END
IF @plateCategoryId IS NULL
BEGIN
	INSERT INTO tb_stockcategory (CompanyID, CategoryCode, CategoryName, Description, IsWeight, IsColor, IsItemCustomSize, IsItemPaperSize, IsCoatingType, IsCoated, IsExposure, IsProcessingCharge, CreatedDate, IsDeleted)
	VALUES (@companyId, N'Plates', N'Plates', N'Plates', 0, 0, 1, 0, 0, 0, 0, 0, GETDATE(), 0);
	SET @plateCategoryId = SCOPE_IDENTITY();
END

IF NOT EXISTS (SELECT 1 FROM tb_papersize WHERE companyid = @companyId AND PaperSizeName = N'SRA3' AND ISNULL(IsDeleted, 0) = 0)
	INSERT INTO tb_papersize (PaperSizeName, CompanyID, Height, Width, OrderSize, CreatedDate, IsDeleted, OrderNumber) VALUES (N'SRA3', @companyId, 320, 450, N'No', GETDATE(), 0, 1);
IF NOT EXISTS (SELECT 1 FROM tb_papersize WHERE companyid = @companyId AND PaperSizeName = N'A4' AND ISNULL(IsDeleted, 0) = 0)
	INSERT INTO tb_papersize (PaperSizeName, CompanyID, Height, Width, OrderSize, CreatedDate, IsDeleted, OrderNumber) VALUES (N'A4', @companyId, 210, 297, N'No', GETDATE(), 0, 2);

SELECT @printSheetId = PaperSizeID FROM tb_papersize WHERE companyid = @companyId AND PaperSizeName = N'SRA3' AND ISNULL(IsDeleted, 0) = 0;
SELECT @jobSizeId = PaperSizeID FROM tb_papersize WHERE companyid = @companyId AND PaperSizeName = N'A4' AND ISNULL(IsDeleted, 0) = 0;
IF @printSheetId IS NULL SELECT TOP 1 @printSheetId = PaperSizeID FROM tb_papersize WHERE companyid = @companyId AND ISNULL(IsDeleted, 0) = 0 ORDER BY PaperSizeID;
IF @jobSizeId IS NULL SET @jobSizeId = @printSheetId;

IF NOT EXISTS (SELECT 1 FROM tb_Guillotine WHERE CompanyID = @companyId AND GuillotineName = N'Sample Guillotine' AND ISNULL(IsDeleted, 0) = 0)
BEGIN
	INSERT INTO tb_Guillotine (CompanyID, GuillotineName, Description, MinSheetHeight, MinSheetWidth, MaxSheetHeight, MaxSheetWidth, MaxSheetWeight, SetUpCharge, CostPerCut, MinCharge, MarkUp, PaperWeight1, MaxSheets1, PaperWeight2, MaxSheets2, PaperWeight3, MaxSheets3, CreatedDate, IsDeleted, DefaultFirstTrim, DefaultSecondTrim, IsLarge, JobCut)
	VALUES (@companyId, N'Sample Guillotine', N'Default sheet trim', 50, 50, 500, 500, 400, 0, 0.3, 0, 0, 100, 500, 200, 300, 400, 200, GETDATE(), 0, 1, 1, 0, 0);
	SET @guillotineId = SCOPE_IDENTITY();
END
ELSE
	SELECT @guillotineId = GuillotineID FROM tb_Guillotine WHERE CompanyID = @companyId AND GuillotineName = N'Sample Guillotine' AND ISNULL(IsDeleted, 0) = 0;

IF NOT EXISTS (SELECT 1 FROM tb_Guillotine WHERE CompanyID = @companyId AND GuillotineName = N'Sample Cutting Table' AND ISNULL(IsDeleted, 0) = 0)
BEGIN
	INSERT INTO tb_Guillotine (CompanyID, GuillotineName, Description, MinSheetHeight, MinSheetWidth, MaxSheetHeight, MaxSheetWidth, MaxSheetWeight, SetUpCharge, CostPerCut, MinCharge, MarkUp, PaperWeight1, MaxSheets1, PaperWeight2, MaxSheets2, PaperWeight3, MaxSheets3, CreatedDate, IsDeleted, DefaultFirstTrim, DefaultSecondTrim, IsLarge, JobCut)
	VALUES (@companyId, N'Sample Cutting Table', N'Default large format trim', 50, 50, 500, 500, 400, 0, 0.3, 0, 0, 100, 500, 200, 300, 400, 200, GETDATE(), 0, 1, 1, 1, 0);
	SET @largeGuillotineId = SCOPE_IDENTITY();
END
ELSE
	SELECT @largeGuillotineId = GuillotineID FROM tb_Guillotine WHERE CompanyID = @companyId AND GuillotineName = N'Sample Cutting Table' AND ISNULL(IsDeleted, 0) = 0;

SELECT @paperInventoryId = InventoryID FROM tb_inventory WHERE CompanyID = @companyId AND InventoryCode = N'PAPER-130' AND ISNULL(IsDeleted, 0) = 0;
IF @paperInventoryId IS NULL
BEGIN
	INSERT INTO tb_inventory (CompanyID, InventoryName, Description, InventoryCode, InventoryCategoryID, InventorySubCategoryID, Location, SupplierID, InStock, ReorderLevel, ReOrderQuantity, CreatedDate, IsDeleted, IsArchived, AllocatedQty, AvailableQty)
	VALUES (@companyId, N'Sample Paper 130gsm', N'Starter sheet for estimates', N'PAPER-130', @paperCategoryId, 0, N'Main', 0, 0, 0, 0, GETDATE(), 0, 0, 0, 0);
	SET @paperInventoryId = SCOPE_IDENTITY();
	INSERT INTO tb_inventoryproperties (InventoryID, Cost, PerQuantity, PackedIn, PackedPrice, ProcessCharge, SellingPrice, CostPerReel, PaperSizeID, Height, Width, WidthType, Length, LengthType, BasisWeight, Coated, Colour, PaperType, InkAbsorption, WashupCounter, Yield, YieldType, CreatedDate, IsDeleted, PackedInType)
	VALUES (@paperInventoryId, 1, 1000, 1, 1, 0, 1, 0, @printSheetId, 450, 320, N'mm', 0, N'mm', 130, 0, N'', N'sheet', 0, 0, 0, N'', GETDATE(), 0, N'');
END

SELECT @inkInventoryId = InventoryID FROM tb_inventory WHERE CompanyID = @companyId AND InventoryCode = N'INK-1' AND ISNULL(IsDeleted, 0) = 0;
IF @inkInventoryId IS NULL
BEGIN
	INSERT INTO tb_inventory (CompanyID, InventoryName, Description, InventoryCode, InventoryCategoryID, InventorySubCategoryID, Location, SupplierID, InStock, ReorderLevel, ReOrderQuantity, CreatedDate, IsDeleted, IsArchived, AllocatedQty, AvailableQty)
	VALUES (@companyId, N'Sample Process Ink', N'Starter ink', N'INK-1', @inkCategoryId, 0, N'Main', 0, 0, 0, 0, GETDATE(), 0, 0, 0, 0);
	SET @inkInventoryId = SCOPE_IDENTITY();
	INSERT INTO tb_inventoryproperties (InventoryID, Cost, PerQuantity, PackedIn, PackedPrice, ProcessCharge, SellingPrice, CostPerReel, PaperSizeID, Height, Width, WidthType, Length, LengthType, BasisWeight, Coated, Colour, PaperType, InkAbsorption, WashupCounter, Yield, YieldType, CreatedDate, IsDeleted, PackedInType)
	VALUES (@inkInventoryId, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, N'', 0, N'', 0, 0, N'', N'', 0, 0, 0, N'', GETDATE(), 0, N'');
END

SELECT @plateInventoryId = InventoryID FROM tb_inventory WHERE CompanyID = @companyId AND InventoryCode = N'PLATE-1' AND ISNULL(IsDeleted, 0) = 0;
IF @plateInventoryId IS NULL
BEGIN
	INSERT INTO tb_inventory (CompanyID, InventoryName, Description, InventoryCode, InventoryCategoryID, InventorySubCategoryID, Location, SupplierID, InStock, ReorderLevel, ReOrderQuantity, CreatedDate, IsDeleted, IsArchived, AllocatedQty, AvailableQty)
	VALUES (@companyId, N'Sample Plate', N'Starter plate', N'PLATE-1', @plateCategoryId, 0, N'Main', 0, 0, 0, 0, GETDATE(), 0, 0, 0, 0);
	SET @plateInventoryId = SCOPE_IDENTITY();
	INSERT INTO tb_inventoryproperties (InventoryID, Cost, PerQuantity, PackedIn, PackedPrice, ProcessCharge, SellingPrice, CostPerReel, PaperSizeID, Height, Width, WidthType, Length, LengthType, BasisWeight, Coated, Colour, PaperType, InkAbsorption, WashupCounter, Yield, YieldType, CreatedDate, IsDeleted, PackedInType)
	VALUES (@plateInventoryId, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, N'', 0, N'', 0, 0, N'', N'', 0, 0, 0, N'', GETDATE(), 0, N'');
END

UPDATE ip SET PaperType = N'sheet'
FROM tb_inventoryproperties ip INNER JOIN tb_inventory i ON ip.InventoryID = i.InventoryID
INNER JOIN tb_stockcategory sc ON sc.CategoryID = i.InventoryCategoryID AND sc.CompanyID = i.CompanyID
WHERE i.CompanyID = @companyId AND sc.CategoryName = N'Paper' AND ISNULL(RTRIM(ip.PaperType), N'') = N'';

-- Sheet Fed Offset (litho)
IF NOT EXISTS (SELECT 1 FROM tb_LithoPress WHERE CompanyID = @companyId AND ISNULL(IsDeleted, 0) = 0)
BEGIN
	INSERT INTO tb_LithoPress (CompanyID, LithoPressName, Description, MaxImgHeight, MaxImgWidth, MaxSheetWeight, PrintImageHeight, PrintImageWidth, GutterHorizontal, GutterVertical, SpoilageSheets, RunningSpoilage, PaperID, PrintSheetID, JobSizeID, GuillotineID, SetupCharge, MinCharge, MarkUp, PlateID, MakeReadyPerPlate, MakeReadyPerPlateCheck, WashupChargePerColour, WashupChargePerColourCheck, MethodName, HourlyChargeRate, ColourUnits, DefaultColour, DefaultInkCoverageSide, IsDefaultPress, CreatedDate, InkType, IsDeleted, AccountCodeID, UnitOfMeasure, SetupChargeWork_n_Turn, SetupChargeWork_n_Tumble, MakeReadyWork_n_Turn, MakeReadyWork_n_Tumble, isPressPerfect)
	VALUES (@companyId, N'Sample Offset Press', N'Default sheet-fed offset press', 340, 540, 450, 8, 8, 5, 5, 0, 0, @paperInventoryId, @printSheetId, @jobSizeId, @guillotineId, 5, 150, 10, @plateInventoryId, 5, 0, 5, 1, N'SpeedWeight Lookup', 100, N'5', N'4', 75, 1, GETDATE(), N'Y', 0, 0, 1000, 5, 5, 5, 5, 0);
	SET @pressId = SCOPE_IDENTITY();
	INSERT INTO tb_LithoInk (LithoPressID, InkID, CreatedDate) VALUES (@pressId, @inkInventoryId, GETDATE());
	INSERT INTO tb_lithoSpeedWeightMatrix (CompanyID, PressID, GSM, Sheets, SheetsPerHour, CreatedDate) VALUES
		(@companyId, @pressId, 115, 2500, 9000, GETDATE()),
		(@companyId, @pressId, 115, 5000, 9000, GETDATE()),
		(@companyId, @pressId, 115, 10000, 9000, GETDATE());
END

-- Sheet Fed Digital
IF NOT EXISTS (SELECT 1 FROM tb_DigitalPress WHERE CompanyID = @companyId AND ISNULL(IsDeleted, 0) = 0)
BEGIN
	INSERT INTO tb_ClickChargeLookup (BlackChargeableSheets, ColorChargeableSheets, ChargeableSheets, CreatedDate, IsDeleted)
	VALUES (1, 1, 1, GETDATE(), 0);
	SET @clickChargeLookupId = SCOPE_IDENTITY();

	INSERT INTO tb_DigitalPress (CompanyID, DigitalPressName, Description, MaxImgHeight, MaxImgWidth, MaxSheetWeight, PrintImageHeight, PrintImageWidth, GutterHorizontal, GutterVertical, SpoilageSheets, RunningSpoilage, PaperID, PrintSheetID, JobSizeID, GuillotineID, SetupCharge, MinCharge, MarkUp, MethodName, MethodID, IsBlackFlatternClick, IsBlackSumClick, IsColorFlatternClick, IsColorSumClick, CreatedDate, IsDeleted, IsDefaultPress, CalculationType, AccountCodeID, UnitOfMeasure)
	VALUES (@companyId, N'Sample Digital Press', N'Default sheet-fed digital press', 100, 100, 100, 0, 0, 5, 5, 5, 5, @paperInventoryId, @printSheetId, @jobSizeId, @guillotineId, 5, 5, 10, N'ClickChargeLookup', @clickChargeLookupId, 0, 0, 0, 0, GETDATE(), 0, 1, 0, 0, 1000);
END

-- Large Format
IF NOT EXISTS (SELECT 1 FROM tb_LargeFormatPress WHERE CompanyID = @companyId AND ISNULL(IsDeleted, 0) = 0)
BEGIN
	INSERT INTO tb_LargeFormatPress (CompanyID, PressName, Description, MinWebWIdth, MaxWebWidth, MaxSheetWeight, GripSideOrientation, GripDepth, SideGutterDepth, PaperType, SetUpSpoilage, SetUpSpoilageInTerms, RunningSpoilage, PaperSizeID, SheetSizeID, JobSizeID, GuillotineID, IsPerfecting, SetupCharge, MinRunningCharge, MarkUp, PrintPerHourLow, PrintPerHourMedium, PrintPerHourHigh, PerHourCharge, CoverageSide1, CoverageSide2, IsDeleted, IsDefaultPress, PrintImageHeight, PrintImageWidth, GutterHorizontal, GutterVertical, InkType, AccountCodeID, UnitOfMeasure, Material2, Material3, Material4, Material5, WhiteInkCoverageSide1, WhiteInkCoverageSide2, CreatedDate, isFullSheet, CalculationType, SetUpSpoilage_Sqm)
	VALUES (@companyId, N'Sample Wide Format Press', N'Default large format press', 210, 1600, 300, 0, 10, 5, N'sheet', 0, N'meters', 0, @paperInventoryId, 0, 0, @largeGuillotineId, 0, 5, 5, 10, 15, 6.5, 3.5, 60, 100, 1, 0, 1, 0, 0, 5, 5, N'Y', 0, 1000, 0, 0, 0, 0, 0, 0, GETDATE(), 1, NULL, 0);
	SET @largePressId = SCOPE_IDENTITY();
	INSERT INTO tb_LargeFormatInk (LargeFormatPressID, InkID, IswhiteInk, CreatedDate) VALUES (@largePressId, @inkInventoryId, 0, GETDATE());
END";

			Execute(companyId, connection, sql);
		}

		private static void Execute(int companyId, SqlConnection connection, string sql)
		{
			using (SqlCommand command = new SqlCommand(sql, connection))
			{
				command.Parameters.AddWithValue("@companyId", companyId);
				command.ExecuteNonQuery();
			}
		}
	}
}
