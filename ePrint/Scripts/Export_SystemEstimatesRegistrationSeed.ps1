# One-time export: builds built-in registration sample estimate seed SQL from reference DB (default company 2144).
# Output: nms/nmsCommon/SeedData/SystemEstimatesRegistration.sql

param(
    [int]$SourceCompanyId = 2144,
    [string[]]$EstimateNumbers = @(
        'EST-0000241', 'EST-0000281', 'EST-0000282', 'EST-0000284',
        'EST-0000285', 'EST-0000287', 'EST-0000298', 'EST-0000299'
    )
)

$ErrorActionPreference = 'Stop'
$projectRoot = Split-Path $PSScriptRoot -Parent
$outDir = Join-Path $projectRoot 'nms\nmsCommon\SeedData'
$outFile = Join-Path $outDir 'SystemEstimatesRegistration.sql'
New-Item -ItemType Directory -Force -Path $outDir | Out-Null

$webConfig = Join-Path $projectRoot 'Web.config'
$connStr = ([xml](Get-Content $webConfig)).configuration.connectionStrings.add |
    Where-Object { $_.name -eq 'CRMConnectionString' } | Select-Object -ExpandProperty connectionString
if ([string]::IsNullOrWhiteSpace($connStr)) {
    $connStr = 'Data Source=localhost;Initial Catalog=eprint_demo;User ID=sa;Password=P@ssword883104;'
}

function Escape-SqlNvarchar([string]$s) {
    if ($null -eq $s) { return 'NULL' }
    return "N'" + ($s -replace "'", "''") + "'"
}

function Default-ForType([string]$typeName) {
    switch -Regex ($typeName) {
        '^bit$' { return '0' }
        '^(nvarchar|nchar|ntext)$' { return "N''" }
        '^(varchar|char|text)$' { return "''" }
        '^(datetime|date|time|datetime2|smalldatetime)$' { return 'GETDATE()' }
        default { return '0' }
    }
}

function Sql-Value($reader, [string]$col, [string]$typeName = $null) {
    if (-not $reader.HasRows) { return Default-ForType $typeName }
    $v = $reader[$col]
    if ($v -eq [DBNull]::Value) {
        if ($typeName) { return Default-ForType $typeName }
        return 'NULL'
    }
    if ($v -is [bool]) { return $(if ($v) { 1 } else { 0 }) }
    if ($v -is [string]) { return (Escape-SqlNvarchar $v) }
    if ($v -is [byte[]]) { return 'NULL' }
    if ($v -is [DateTime]) { return "'" + $v.ToString('yyyy-MM-dd HH:mm:ss.fff') + "'" }
    if ($v -is [decimal] -or $v -is [double] -or $v -is [float]) { return $v.ToString([System.Globalization.CultureInfo]::InvariantCulture) }
    return $v.ToString()
}

function Sanitize-Var([string]$name) {
    $k = $name -replace '[^a-zA-Z0-9_]', '_'
    if ($k -match '^\d') { return "v_$k" }
    return $k
}

function Get-TableColumns($connStr, [string]$tableName) {
    $localConn = New-Object System.Data.SqlClient.SqlConnection $connStr
    $localConn.Open()
    try {
        $cmd = $localConn.CreateCommand()
        $cmd.CommandText = @"
SELECT c.name, c.is_identity, t.name AS type_name
FROM sys.columns c
INNER JOIN sys.types t ON c.user_type_id = t.user_type_id
WHERE c.object_id = OBJECT_ID(@tableName)
ORDER BY c.column_id
"@
        [void]$cmd.Parameters.AddWithValue('@tableName', $tableName)
        $r = $cmd.ExecuteReader()
        $cols = @()
        while ($r.Read()) {
            $cols += [pscustomobject]@{
                Name = $r['name'].ToString()
                IsIdentity = [bool]$r['is_identity']
                TypeName = $r['type_name'].ToString()
            }
        }
        $r.Close()
        return $cols
    }
    finally {
        $localConn.Close()
    }
}

function Export-InsertRow(
    $lines,
    [string]$tableName,
    $reader,
    $columns,
    [hashtable]$overrides,
    [string[]]$excludeColumns = @()
) {
    $insertCols = @()
    $insertVals = @()
    foreach ($col in $columns) {
        if ($col.IsIdentity) { continue }
        if ($excludeColumns -contains $col.Name) { continue }
        $insertCols += $col.Name
        if ($overrides.ContainsKey($col.Name)) {
            $insertVals += $overrides[$col.Name]
        }
        else {
            $insertVals += (Sql-Value $reader $col.Name $col.TypeName)
        }
    }
    $colList = ($insertCols | ForEach-Object { if ($_ -match '^(top|left|order|key)$') { "[$_]" } else { $_ } }) -join ', '
    $lines.Add("INSERT INTO $tableName ($colList)")
    $lines.Add('VALUES (' + ($insertVals -join ', ') + ');')
}

$conn = New-Object System.Data.SqlClient.SqlConnection $connStr
$conn.Open()
$lines = New-Object System.Collections.Generic.List[string]

$lines.Add('-- Built-in registration sample estimates (exported from company ' + $SourceCompanyId + ').')
$lines.Add('-- Re-run Scripts/Export_SystemEstimatesRegistrationSeed.ps1 to refresh.')
$lines.Add('SET NOCOUNT ON;')
$lines.Add('IF @companyId <= 0 OR @adminUserId <= 0 RETURN;')
$lines.Add("IF EXISTS (SELECT 1 FROM tb_estimate WHERE CompanyID = @companyId AND ISNULL(IsDeleted,0) = 0 AND Comments LIKE N'%Registration sample estimate (EST-0000299)%') RETURN;")
$lines.Add('')
$lines.Add('DECLARE @customerId int, @contactId bigint, @deptId int, @addressId int, @statusId int;')
$lines.Add('DECLARE @digitalPressId bigint, @lithoPressId bigint, @largePressId bigint, @paperId bigint;')
$lines.Add('DECLARE @printSheetSizeId int, @jobSizeId int, @guillotineId bigint, @largeGuillotineId bigint, @taxId int;')
$lines.Add('')
$lines.Add("SELECT TOP 1 @customerId = c.clientID, @contactId = ISNULL(ct.contactId,0), @deptId = ISNULL(d.DeptID,0), @addressId = ISNULL(NULLIF(c.AddressID,0), c.clientID)")
$lines.Add("FROM tb_client c")
$lines.Add("OUTER APPLY (SELECT TOP 1 contactId FROM tb_contact WHERE ClientID = c.clientID AND companyID = c.companyID AND ISNULL(isDelete,0)=0 ORDER BY CASE WHEN ISNULL(DefaultContact,0)=1 THEN 0 ELSE 1 END, contactId) ct")
$lines.Add("OUTER APPLY (SELECT TOP 1 DeptID FROM tb_Department WHERE CustomerID = c.clientID AND CompanyID = c.companyID AND ISNULL(IsDeleted,0)=0 ORDER BY DeptID) d")
$lines.Add("WHERE c.companyID = @companyId AND c.companytype = N'Customer' AND ISNULL(c.isdelete,0)=0")
$lines.Add("ORDER BY CASE WHEN LTRIM(RTRIM(c.clientname)) IN (N'Test Customer', N'Test%20Customer') THEN 0 ELSE 1 END, c.clientID;")
$lines.Add('IF @customerId IS NULL OR @customerId <= 0 RETURN;')
$lines.Add('')
$lines.Add('SELECT TOP 1 @statusId = StatusID FROM tb_EstimateStatus WHERE companyid = @companyId AND ISNULL(IsDeleted,0)=0 AND ISNULL(Estimate,0)=1 ORDER BY ISNULL(EstimateDefault,0) DESC, StatusID;')
$lines.Add('SELECT @digitalPressId = (SELECT TOP 1 DigitalPressID FROM tb_DigitalPress WHERE CompanyID=@companyId AND ISNULL(IsDeleted,0)=0 ORDER BY ISNULL(IsDefaultPress,0) DESC, DigitalPressID);')
$lines.Add('SELECT @lithoPressId = (SELECT TOP 1 LithoPressID FROM tb_LithoPress WHERE CompanyID=@companyId AND ISNULL(IsDeleted,0)=0 ORDER BY ISNULL(IsDefaultPress,0) DESC, LithoPressID);')
$lines.Add('SELECT @largePressId = (SELECT TOP 1 PressID FROM tb_LargeFormatPress WHERE CompanyID=@companyId AND ISNULL(IsDeleted,0)=0 ORDER BY ISNULL(IsDefaultPress,0) DESC, PressID);')
$lines.Add("SELECT @paperId = (SELECT TOP 1 InventoryID FROM tb_inventory WHERE CompanyID=@companyId AND InventoryCode=N'PAPER-130' AND ISNULL(IsDeleted,0)=0);")
$lines.Add("SELECT @printSheetSizeId = (SELECT TOP 1 PaperSizeID FROM tb_papersize WHERE companyid=@companyId AND PaperSizeName=N'SRA3' AND ISNULL(IsDeleted,0)=0);")
$lines.Add("SELECT @jobSizeId = (SELECT TOP 1 PaperSizeID FROM tb_papersize WHERE companyid=@companyId AND PaperSizeName=N'A4' AND ISNULL(IsDeleted,0)=0);")
$lines.Add("SELECT @guillotineId = (SELECT TOP 1 GuillotineID FROM tb_Guillotine WHERE CompanyID=@companyId AND GuillotineName=N'Sample Guillotine' AND ISNULL(IsDeleted,0)=0);")
$lines.Add("SELECT @largeGuillotineId = (SELECT TOP 1 GuillotineID FROM tb_Guillotine WHERE CompanyID=@companyId AND GuillotineName=N'Sample Cutting Table' AND ISNULL(IsDeleted,0)=0);")
$lines.Add('SELECT @taxId = (SELECT TOP 1 TaxID FROM tb_taxrates WHERE CompanyID=@companyId AND ISNULL(IsDeleted,0)=0 ORDER BY TaxID);')
$lines.Add('IF @jobSizeId IS NULL OR @jobSizeId <= 0 SET @jobSizeId = @printSheetSizeId;')
$lines.Add('IF @largeGuillotineId IS NULL OR @largeGuillotineId <= 0 SET @largeGuillotineId = @guillotineId;')
$lines.Add('IF @largePressId IS NULL OR @largePressId <= 0 SET @largePressId = @lithoPressId;')
$lines.Add('')

# Price catalogues used by C-type estimate lines
$pcCmd = $conn.CreateCommand()
$pcCmd.CommandText = @"
SELECT DISTINCT pc.*
FROM tb_PriceCatalogue pc
WHERE pc.CompanyID = @cid AND pc.PriceCatalogueID IN (
    SELECT DISTINCT epc.PriceCatalogueID
    FROM tb_EstPriceCatalogue epc
    INNER JOIN tb_estimateitem ei ON ei.EstimateItemID = epc.EstimateItemID
    INNER JOIN tb_estimate e ON e.EstimateID = ei.EstimateID
    WHERE e.CompanyID = @cid AND e.EstimateNumber IN ($(
        ($EstimateNumbers | ForEach-Object { Escape-SqlNvarchar $_ }) -join ','
    )) AND ISNULL(e.IsDeleted,0)=0
)
ORDER BY pc.PriceCatalogueID
"@
[void]$pcCmd.Parameters.AddWithValue('@cid', $SourceCompanyId)
$pcReader = $pcCmd.ExecuteReader()
$pcCols = Get-TableColumns $connStr 'tb_PriceCatalogue'
$pcIdToVar = @{}
while ($pcReader.Read()) {
    $srcPcId = [long]$pcReader['PriceCatalogueID']
    $itemCode = if ($pcReader['ItemCode'] -eq [DBNull]::Value) { "PC_$srcPcId" } else { $pcReader['ItemCode'].ToString() }
    $varName = '@pc_' + (Sanitize-Var $itemCode)
    $pcIdToVar[$srcPcId] = $varName
    $itemCodeSql = Escape-SqlNvarchar $itemCode
    $lines.Add("IF NOT EXISTS (SELECT 1 FROM tb_PriceCatalogue d WHERE d.CompanyID=@companyId AND d.ItemCode=$itemCodeSql AND ISNULL(d.IsDeleted,0)=0)")
    $lines.Add('BEGIN')
    $lines.Add("DECLARE $varName bigint;")
    $overrides = @{
        CompanyID = '@companyId'
        CreatedBy = '@adminUserId'
        ModifiedBy = '@adminUserId'
        CreateDate = 'GETDATE()'
        ModifiedDate = 'GETDATE()'
        OwnerID = '@adminUserId'
        PriceCatalogueCategoryID = '0'
        PriceCatalogueCategoryID_2 = '0'
        PriceCatalogueCategoryID_3 = '0'
        PriceCatalogueCategoryID_4 = '0'
        PriceCatalogueCategoryID_5 = '0'
        PriceCatalogueCategoryID_6 = '0'
        SupplierID = '0'
        PressId = '0'
    }
    Export-InsertRow $lines 'tb_PriceCatalogue' $pcReader $pcCols $overrides
    $lines.Add("SET $varName = SCOPE_IDENTITY();")
    $lines.Add('END')
    $lines.Add("ELSE SELECT $varName = d.PriceCatalogueID FROM tb_PriceCatalogue d WHERE d.CompanyID=@companyId AND d.ItemCode=$itemCodeSql AND ISNULL(d.IsDeleted,0)=0;")
    $lines.Add('')
}
$pcReader.Close()

$pcQtyCmd = $conn.CreateCommand()
$pcQtyCmd.CommandText = @"
SELECT q.*
FROM tb_PriceCatalogueQty q
INNER JOIN tb_PriceCatalogue pc ON pc.PriceCatalogueID = q.PriceCatalogueID
WHERE pc.CompanyID = @cid AND pc.PriceCatalogueID IN (
    SELECT DISTINCT epc.PriceCatalogueID
    FROM tb_EstPriceCatalogue epc
    INNER JOIN tb_estimateitem ei ON ei.EstimateItemID = epc.EstimateItemID
    INNER JOIN tb_estimate e ON e.EstimateID = ei.EstimateID
    WHERE e.CompanyID = @cid AND e.EstimateNumber IN ($(
        ($EstimateNumbers | ForEach-Object { Escape-SqlNvarchar $_ }) -join ','
    ))
)
ORDER BY q.PriceCatalogueQtyID
"@
[void]$pcQtyCmd.Parameters.AddWithValue('@cid', $SourceCompanyId)
$pcQtyCols = Get-TableColumns $connStr 'tb_PriceCatalogueQty'
$pcQtyReader = $pcQtyCmd.ExecuteReader()
while ($pcQtyReader.Read()) {
    $srcPcId = [long]$pcQtyReader['PriceCatalogueID']
    if (-not $pcIdToVar.ContainsKey($srcPcId)) { continue }
    $pcVar = $pcIdToVar[$srcPcId]
    $fromQty = $pcQtyReader['FromQuantity'].ToString()
    $toQty = $pcQtyReader['ToQuantity'].ToString()
    $lines.Add("IF NOT EXISTS (SELECT 1 FROM tb_PriceCatalogueQty q WHERE q.PriceCatalogueID = $pcVar AND q.FromQuantity = $fromQty AND q.ToQuantity = $toQty AND ISNULL(q.IsDeleted,0)=0)")
    $overrides = @{
        PriceCatalogueID = $pcVar
        CreatedDate = 'GETDATE()'
    }
    Export-InsertRow $lines 'tb_PriceCatalogueQty' $pcQtyReader $pcQtyCols $overrides
}
$pcQtyReader.Close()

$estCols = Get-TableColumns $connStr 'tb_estimate'
$itemCols = Get-TableColumns $connStr 'tb_estimateitem'
$singleCols = Get-TableColumns $connStr 'tb_EstimateSingleItem'
$largeCols = Get-TableColumns $connStr 'tb_EstimateLargeItem'
$whCols = Get-TableColumns $connStr 'tb_EstWarehouseItem'
$ocCols = Get-TableColumns $connStr 'tb_EstOtherCost'
$qqCols = Get-TableColumns $connStr 'tb_EstimateQuickQuote'
$epcCols = Get-TableColumns $connStr 'tb_EstPriceCatalogue'
$tpdCols = Get-TableColumns $connStr 'tb_EstTotalPriceDetails'
$eidCols = Get-TableColumns $connStr 'tb_EstimateItemDetails'
$estCalcCols = Get-TableColumns $connStr 'tb_EstimateCalculation'
$largeCalcCols = Get-TableColumns $connStr 'tb_EstLargeItemCalculation'

$bodyTables = @{
    'S' = @{ Table = 'tb_EstimateSingleItem'; Cols = $singleCols; Press = '@digitalPressId' }
    'L' = @{ Table = 'tb_EstimateLargeItem'; Cols = $largeCols; Press = '@largePressId' }
    'F' = @{ Table = 'tb_EstimateLargeItem'; Cols = $largeCols; Press = '@largePressId' }
    'W' = @{ Table = 'tb_EstWarehouseItem'; Cols = $whCols; Press = $null }
    'U' = @{ Table = 'tb_EstOtherCost'; Cols = $ocCols; Press = $null }
    'Q' = @{ Table = 'tb_EstimateQuickQuote'; Cols = $qqCols; Press = $null }
    'C' = @{ Table = 'tb_EstPriceCatalogue'; Cols = $epcCols; Press = $null }
}

foreach ($estNum in $EstimateNumbers) {
    $estCmd = $conn.CreateCommand()
    $estCmd.CommandText = 'SELECT * FROM tb_estimate WHERE CompanyID=@cid AND EstimateNumber=@num AND ISNULL(IsDeleted,0)=0'
    [void]$estCmd.Parameters.AddWithValue('@cid', $SourceCompanyId)
    [void]$estCmd.Parameters.AddWithValue('@num', $estNum)
    $estReader = $estCmd.ExecuteReader()
    if (-not $estReader.Read()) {
        $estReader.Close()
        Write-Warning "Estimate not found: $estNum"
        continue
    }

    $srcEstId = [long]$estReader['EstimateID']
    $estVar = '@est_' + (Sanitize-Var ($estNum -replace 'EST-', ''))
    $marker = "Registration sample estimate ($estNum)"
    $lines.Add('-- ' + $estNum)
    $lines.Add("DECLARE $estVar bigint;")
    $estOverrides = @{
        CompanyID = '@companyId'
        UserID = '@adminUserId'
        CustomerID = '@customerId'
        AttentionID = '@contactId'
        DepartmentID = '@deptId'
        InvoiceAddressID = '@addressId'
        DeliveryAddressID = '@addressId'
        Address = '@addressId'
        DeliveryAddress = '@addressId'
        SalesPerson = '@adminUserId'
        EstimatorId = '@adminUserId'
        ModifiedBy = '@adminUserId'
        StatusID = 'CASE WHEN @statusId > 0 THEN @statusId ELSE ' + (Sql-Value $estReader 'StatusID') + ' END'
        Comments = (Escape-SqlNvarchar $marker)
        EstimateNumber = 'NULL'
        CreatedDate = 'GETDATE()'
        ModifiedDate = 'GETDATE()'
        CostCentreID = '0'
        InvoiceContactId = '@contactId'
        TempAttentionID = '0'
        Footer = $(if ($estReader['Footer'] -eq [DBNull]::Value) { "N''" } else { Sql-Value $estReader 'Footer' })
    }
    Export-InsertRow $lines 'tb_estimate' $estReader $estCols $estOverrides
    $lines.Add("SET $estVar = SCOPE_IDENTITY();")
    $estReader.Close()

    $itemCmd = $conn.CreateCommand()
    $itemCmd.CommandText = @"
SELECT * FROM tb_estimateitem
WHERE EstimateID=@eid AND ISNULL(IsDeleted,0)=0
ORDER BY CASE WHEN ISNULL(ParentItemID,0)=0 THEN 0 ELSE 1 END, EstimateItemID
"@
    [void]$itemCmd.Parameters.AddWithValue('@eid', $srcEstId)
    $itemReader = $itemCmd.ExecuteReader()
    $itemRows = New-Object System.Collections.Generic.List[object]
    while ($itemReader.Read()) {
        $row = @{ EstimateItemID = [long]$itemReader['EstimateItemID'] }
        foreach ($col in $itemCols) {
            if (-not $col.IsIdentity) {
                $row[$col.Name] = $itemReader[$col.Name]
            }
        }
        $itemRows.Add($row)
    }
    $itemReader.Close()

    $itemIdMap = @{}
    foreach ($row in $itemRows) {
        $srcItemId = [long]$row['EstimateItemID']
        $itemVar = '@item_' + $srcItemId
        $itemIdMap[$srcItemId] = $itemVar
        $parentExpr = '0'
        if ($row['ParentItemID'] -ne $null -and $row['ParentItemID'] -ne [DBNull]::Value) {
            $parentId = [long]$row['ParentItemID']
            if ($parentId -gt 0 -and $itemIdMap.ContainsKey($parentId)) {
                $parentExpr = $itemIdMap[$parentId]
            }
        }
        $pcExpr = '0'
        if ($row['ProductCatalogueId'] -ne $null -and $row['ProductCatalogueId'] -ne [DBNull]::Value) {
            $pcId = [long]$row['ProductCatalogueId']
            if ($pcId -gt 0 -and $pcIdToVar.ContainsKey($pcId)) { $pcExpr = $pcIdToVar[$pcId] }
        }
        $isParentExpr = '0'
        if ($row['IsParentItem'] -ne $null -and $row['IsParentItem'] -ne [DBNull]::Value) {
            $isParentExpr = $(if ($row['IsParentItem']) { '1' } else { '0' })
        }
        $lines.Add("DECLARE $itemVar bigint;")
        $itemOverrides = @{
            EstimateID = $estVar
            ParentItemID = $parentExpr
            ProductCatalogueId = $pcExpr
            IsParentItem = $isParentExpr
            CreatedDate = 'GETDATE()'
            EstimateItemStatusID = 'CASE WHEN @statusId > 0 THEN @statusId ELSE ' + $(if ($null -eq $row['EstimateItemStatusID'] -or $row['EstimateItemStatusID'] -eq [DBNull]::Value) { '0' } else { $row['EstimateItemStatusID'].ToString() }) + ' END'
            AccountCodeID = '0'
        }
        $insertCols = @()
        $insertVals = @()
        foreach ($col in $itemCols) {
            if ($col.IsIdentity) { continue }
            $insertCols += $col.Name
            if ($itemOverrides.ContainsKey($col.Name)) {
                $insertVals += $itemOverrides[$col.Name]
            }
            else {
                $v = $row[$col.Name]
                if ($v -eq $null -or $v -eq [DBNull]::Value) { $insertVals += (Default-ForType $col.TypeName) }
                elseif ($v -is [bool]) { $insertVals += $(if ($v) { 1 } else { 0 }) }
                elseif ($v -is [string]) { $insertVals += (Escape-SqlNvarchar $v) }
                elseif ($v -is [DateTime]) { $insertVals += "'" + $v.ToString('yyyy-MM-dd HH:mm:ss.fff') + "'" }
                else { $insertVals += $v.ToString() }
            }
        }
        $colList = ($insertCols -join ', ')
        $lines.Add("INSERT INTO tb_estimateitem ($colList)")
        $lines.Add('VALUES (' + ($insertVals -join ', ') + ');')
        $lines.Add("SET $itemVar = SCOPE_IDENTITY();")
    }

    foreach ($row in $itemRows) {
        $srcItemId = [long]$row['EstimateItemID']
        $itemVar = $itemIdMap[$srcItemId]
        $type = $row['EstimateType'].ToString()
        if (-not $bodyTables.ContainsKey($type)) { continue }
        $bt = $bodyTables[$type]
        $bodyCmd = $conn.CreateCommand()
        $bodyCmd.CommandText = "SELECT * FROM $($bt.Table) WHERE EstimateItemID=@iid"
        [void]$bodyCmd.Parameters.AddWithValue('@iid', $srcItemId)
        $bodyReader = $bodyCmd.ExecuteReader()
        if ($bodyReader.Read()) {
            $bodyOverrides = @{
                EstimateItemID = $itemVar
                CreatedBy = '@adminUserId'
                ModifiedBy = '@adminUserId'
                CreatedDate = 'GETDATE()'
                ModifiedDate = 'GETDATE()'
            }
            if ($bt.Table -eq 'tb_EstimateSingleItem') {
                $bodyOverrides['PressID'] = $bt.Press
                $bodyOverrides['PaperID'] = 'CASE WHEN @paperId > 0 THEN @paperId ELSE 0 END'
                $bodyOverrides['PrintSheetSizeID'] = 'CASE WHEN @printSheetSizeId > 0 THEN @printSheetSizeId ELSE 0 END'
                $bodyOverrides['JobFlatSizeID'] = 'CASE WHEN @jobSizeId > 0 THEN @jobSizeId ELSE 0 END'
                $bodyOverrides['GuillotineID'] = 'CASE WHEN @guillotineId > 0 THEN @guillotineId ELSE ' + (Sql-Value $bodyReader 'GuillotineID') + ' END'
            }
            elseif ($bt.Table -eq 'tb_EstimateLargeItem') {
                $bodyOverrides['PressID'] = $bt.Press
                $bodyOverrides['PaperID'] = 'CASE WHEN @paperId > 0 THEN @paperId ELSE 0 END'
                $bodyOverrides['GuillotineID'] = 'CASE WHEN @largeGuillotineId > 0 THEN @largeGuillotineId ELSE ' + (Sql-Value $bodyReader 'GuillotineID') + ' END'
            }
            elseif ($bt.Table -eq 'tb_EstWarehouseItem') {
                $bodyOverrides['WarehouseTypeID'] = 'CASE WHEN @paperId > 0 THEN @paperId ELSE ' + (Sql-Value $bodyReader 'WarehouseTypeID') + ' END'
                $bodyOverrides['TaxID'] = 'CASE WHEN @taxId > 0 THEN @taxId ELSE ' + (Sql-Value $bodyReader 'TaxID') + ' END'
            }
            elseif ($bt.Table -eq 'tb_EstPriceCatalogue') {
                    $srcPc = [long]$bodyReader['PriceCatalogueID']
                    if ($pcIdToVar.ContainsKey($srcPc)) {
                        $bodyOverrides['PriceCatalogueID'] = $pcIdToVar[$srcPc]
                    }
                    $bodyOverrides['TaxID'] = 'CASE WHEN @taxId > 0 THEN @taxId ELSE ' + (Sql-Value $bodyReader 'TaxID') + ' END'
                }
            elseif ($bt.Table -eq 'tb_EstimateQuickQuote') {
                $bodyOverrides['CompanyID'] = '@companyId'
                $bodyOverrides['EstimateID'] = $estVar
                $bodyOverrides['TaxID'] = 'CASE WHEN @taxId > 0 THEN @taxId ELSE ' + (Sql-Value $bodyReader 'TaxID') + ' END'
                $bodyOverrides['AccountCodeID'] = '0'
            }
            elseif ($bt.Table -eq 'tb_EstOtherCost') {
                $bodyOverrides['OtherCostID'] = "COALESCE((SELECT TOP 1 OtherCostID FROM tb_OtherCost WHERE CompanyID = @companyId AND OtherCostName = N'Sample Admin Cost' AND ISNULL(IsDeleted,0) = 0), (SELECT TOP 1 OtherCostID FROM tb_OtherCost WHERE CompanyID = @companyId AND ISNULL(IsDeleted,0) = 0 ORDER BY OtherCostID), 0)"
                $bodyOverrides['TaxID'] = 'CASE WHEN @taxId > 0 THEN @taxId ELSE ' + (Sql-Value $bodyReader 'TaxID') + ' END'
            }
            Export-InsertRow $lines $bt.Table $bodyReader $bt.Cols $bodyOverrides
        }
        $bodyReader.Close()

        if ($type -eq 'S' -or $type -eq 'L') {
            $calcCmd = $conn.CreateCommand()
            $calcCmd.CommandText = 'SELECT * FROM tb_EstimateCalculation WHERE EstimateItemID=@iid AND ISNULL(IsDeleted,0)=0'
            [void]$calcCmd.Parameters.AddWithValue('@iid', $srcItemId)
            $calcReader = $calcCmd.ExecuteReader()
            $hasCalc = $calcReader.Read()
            if (-not $hasCalc) {
                $calcReader.Close()
                $fallbackCalcCmd = $conn.CreateCommand()
                if ($type -eq 'L') {
                    $fallbackCalcCmd.CommandText = @'
SELECT ec.* FROM tb_EstimateCalculation ec
INNER JOIN tb_EstLargeItemCalculation lc ON lc.EstimateCalculationID = ec.EstimateCalculationID
WHERE lc.EstimateItemID=@iid AND ISNULL(ec.IsDeleted,0)=0
'@
                }
                else {
                    $fallbackCalcCmd.CommandText = 'SELECT TOP 0 * FROM tb_EstimateCalculation'
                }
                [void]$fallbackCalcCmd.Parameters.AddWithValue('@iid', $srcItemId)
                $calcReader = $fallbackCalcCmd.ExecuteReader()
                $hasCalc = $calcReader.Read()
            }
            if ($hasCalc) {
                $calcVar = '@calc_' + $srcItemId
                $lines.Add("DECLARE $calcVar bigint;")
                $calcOverrides = @{ EstimateItemID = $itemVar; CreatedDate = 'GETDATE()' }
                Export-InsertRow $lines 'tb_EstimateCalculation' $calcReader $estCalcCols $calcOverrides
                $lines.Add("SET $calcVar = SCOPE_IDENTITY();")
            }
            $calcReader.Close()

            if ($type -eq 'L') {
                $lcCmd = $conn.CreateCommand()
                $lcCmd.CommandText = 'SELECT * FROM tb_EstLargeItemCalculation WHERE EstimateItemID=@iid AND ISNULL(IsDeleted,0)=0'
                [void]$lcCmd.Parameters.AddWithValue('@iid', $srcItemId)
                $lcReader = $lcCmd.ExecuteReader()
                if ($lcReader.Read()) {
                    $calcVar = '@calc_' + $srcItemId
                    $lcOverrides = @{
                        EstimateItemID = $itemVar
                        EstimateCalculationID = $calcVar
                        CreatedDate = 'GETDATE()'
                    }
                    Export-InsertRow $lines 'tb_EstLargeItemCalculation' $lcReader $largeCalcCols $lcOverrides
                }
                $lcReader.Close()
            }
        }
    }

    $eidCmd = $conn.CreateCommand()
    $eidCmd.CommandText = @"
SELECT d.* FROM tb_EstimateItemDetails d
INNER JOIN tb_estimateitem ei ON ei.EstimateItemID = d.EstimateItemID
WHERE ei.EstimateID = @eid
"@
    [void]$eidCmd.Parameters.AddWithValue('@eid', $srcEstId)
    $eidReader = $eidCmd.ExecuteReader()
    while ($eidReader.Read()) {
        $srcItemId = [long]$eidReader['EstimateItemID']
        if (-not $itemIdMap.ContainsKey($srcItemId)) { continue }
        $eidOverrides = @{
            EstimateID = $estVar
            EstimateItemID = $itemIdMap[$srcItemId]
            CreatedDate = 'GETDATE()'
        }
        Export-InsertRow $lines 'tb_EstimateItemDetails' $eidReader $eidCols $eidOverrides
    }
    $eidReader.Close()

    $tpdCmd = $conn.CreateCommand()
    $tpdCmd.CommandText = 'SELECT * FROM tb_EstTotalPriceDetails WHERE EstimateID=@eid'
    [void]$tpdCmd.Parameters.AddWithValue('@eid', $srcEstId)
    $tpdReader = $tpdCmd.ExecuteReader()
    while ($tpdReader.Read()) {
        $srcItemId = [long]$tpdReader['EstimateItemID']
        if (-not $itemIdMap.ContainsKey($srcItemId)) { continue }
        $tpdOverrides = @{
            EstimateID = $estVar
            EstimateItemID = $itemIdMap[$srcItemId]
            TotalTaxID1 = 'CASE WHEN @taxId > 0 THEN @taxId ELSE ' + (Sql-Value $tpdReader 'TotalTaxID1') + ' END'
            TotalTaxID2 = 'CASE WHEN @taxId > 0 THEN @taxId ELSE ' + (Sql-Value $tpdReader 'TotalTaxID2') + ' END'
            TotalTaxID3 = 'CASE WHEN @taxId > 0 THEN @taxId ELSE ' + (Sql-Value $tpdReader 'TotalTaxID3') + ' END'
            TotalTaxID4 = 'CASE WHEN @taxId > 0 THEN @taxId ELSE ' + (Sql-Value $tpdReader 'TotalTaxID4') + ' END'
            CreatedDate = 'GETDATE()'
        }
        Export-InsertRow $lines 'tb_EstTotalPriceDetails' $tpdReader $tpdCols $tpdOverrides
    }
    $tpdReader.Close()
    $lines.Add('')
}

$lines.Add('-- Ensure item detail rows exist (summary page QtyCount)')
$lines.Add('INSERT INTO tb_EstimateItemDetails (EstimateID, EstimateItemID, EstimateType, CreatedDate, IsDeleted)')
$lines.Add('SELECT ei.EstimateID, ei.EstimateItemID, ei.EstimateType, GETDATE(), 0')
$lines.Add('FROM tb_estimateitem ei')
$lines.Add('INNER JOIN tb_estimate e ON e.EstimateID = ei.EstimateID')
$lines.Add('WHERE e.CompanyID = @companyId AND ISNULL(ei.IsDeleted, 0) = 0')
$lines.Add("  AND e.Comments LIKE N'%Registration sample estimate (%'")
$lines.Add('  AND NOT EXISTS (SELECT 1 FROM tb_EstimateItemDetails d WHERE d.EstimateItemID = ei.EstimateItemID AND ISNULL(d.IsDeleted, 0) = 0);')
$lines.Add('')
$lines.Add('UPDATE d SET')
$lines.Add('  d.Qty1 = CASE WHEN ISNULL(tpd.TotalQty1, 0) > 0 THEN CAST(tpd.TotalQty1 AS int) ELSE 1 END,')
$lines.Add('  d.Qty2 = CASE WHEN ISNULL(tpd.TotalQty2, 0) > 0 THEN CAST(tpd.TotalQty2 AS int) ELSE 0 END,')
$lines.Add('  d.Qty3 = CASE WHEN ISNULL(tpd.TotalQty3, 0) > 0 THEN CAST(tpd.TotalQty3 AS int) ELSE 0 END,')
$lines.Add('  d.Qty4 = CASE WHEN ISNULL(tpd.TotalQty4, 0) > 0 THEN CAST(tpd.TotalQty4 AS int) ELSE 0 END')
$lines.Add('FROM tb_EstimateItemDetails d')
$lines.Add('INNER JOIN tb_estimateitem ei ON ei.EstimateItemID = d.EstimateItemID')
$lines.Add('INNER JOIN tb_estimate e ON e.EstimateID = ei.EstimateID')
$lines.Add('LEFT JOIN tb_EstTotalPriceDetails tpd ON tpd.EstimateItemID = ei.EstimateItemID')
$lines.Add('WHERE e.CompanyID = @companyId AND ISNULL(d.IsDeleted, 0) = 0')
$lines.Add("  AND e.Comments LIKE N'%Registration sample estimate (%';")
$lines.Add('')
$lines.Add('-- Assign estimate numbers from tenant counter')
$lines.Add(@'
DECLARE @counter bigint, @num nvarchar(50), @prefix nvarchar(20) = N'EST-', @eid bigint;
DECLARE est_cursor CURSOR LOCAL FAST_FORWARD FOR
    SELECT EstimateID FROM tb_estimate
    WHERE CompanyID = @companyId AND ISNULL(IsDeleted,0)=0
        AND Comments LIKE N'%Registration sample estimate (EST-%'
        AND (EstimateNumber IS NULL OR LTRIM(RTRIM(EstimateNumber)) = N'')
    ORDER BY EstimateID;
OPEN est_cursor;
FETCH NEXT FROM est_cursor INTO @eid;
WHILE @@FETCH_STATUS = 0
BEGIN
    SELECT @counter = ISNULL(LastCounter,0)+1 FROM tb_lastCounter WHERE CompanyID=@companyId AND ModuleType=N'Estimate';
    IF @counter IS NULL BEGIN SET @counter=1; INSERT INTO tb_lastCounter (CompanyID,ModuleType,LastCounter) VALUES (@companyId,N'Estimate',@counter); END
    ELSE UPDATE tb_lastCounter SET LastCounter=@counter WHERE CompanyID=@companyId AND ModuleType=N'Estimate';
    SET @num = @prefix + SUBSTRING(CAST(10000000+@counter AS varchar(20)),2,20);
    UPDATE tb_estimate SET EstimateNumber=@num WHERE EstimateID=@eid;
    FETCH NEXT FROM est_cursor INTO @eid;
END
CLOSE est_cursor; DEALLOCATE est_cursor;
'@)

$conn.Close()
[System.IO.File]::WriteAllLines($outFile, $lines, [System.Text.UTF8Encoding]::new($false))
Write-Host "Wrote $outFile ($([math]::Round((Get-Item $outFile).Length/1KB,1)) KB)"
