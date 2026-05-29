# Seeds four reference estimates from company 2144 (EST-0000619, 0617, 0613, 0611).
# Usage: .\SeedReferenceEstimatesForCompany.ps1 -CompanyId 2174

param(
    [Parameter(Mandatory = $true)]
    [int]$CompanyId
)

$ErrorActionPreference = 'Stop'
$sourceCompanyId = 2144
$marker = 'Registration reference estimate (company 2144)'
$sourceNumbers = @('EST-0000619', 'EST-0000617', 'EST-0000613', 'EST-0000611')

$projectRoot = Split-Path $PSScriptRoot -Parent
$webConfig = Join-Path $projectRoot 'Web.config'
$connStr = ([xml](Get-Content $webConfig)).configuration.connectionStrings.add |
    Where-Object { $_.name -eq 'CRMConnectionString' } | Select-Object -ExpandProperty connectionString
if ([string]::IsNullOrWhiteSpace($connStr)) {
    $connStr = 'Data Source=localhost;Initial Catalog=eprint_demo;User ID=sa;Password=P@ssword883104;'
}

function Get-Scalar($connection, $sql, $params) {
    $cmd = $connection.CreateCommand()
    $cmd.CommandText = $sql
    foreach ($p in $params.GetEnumerator()) { [void]$cmd.Parameters.AddWithValue($p.Key, $p.Value) }
    return $cmd.ExecuteScalar()
}

$conn = New-Object System.Data.SqlClient.SqlConnection $connStr
$conn.Open()

$exists = [int](Get-Scalar $conn "SELECT COUNT(1) FROM tb_estimate WHERE CompanyID=@cid AND ISNULL(IsDeleted,0)=0 AND Comments LIKE @m" @{ cid = $CompanyId; m = "%$marker%" })
if ($exists -gt 0) {
    Write-Host "Reference estimates already seeded for company $CompanyId"
    exit 0
}

$adminId = [int](Get-Scalar $conn 'SELECT TOP 1 userid FROM tb_user WHERE companyid=@cid AND isadmin=1 ORDER BY userid' @{ cid = $CompanyId })
$clientId = [int](Get-Scalar $conn "SELECT TOP 1 clientid FROM tb_client WHERE companyID=@cid AND companytype=N'Customer' AND ISNULL(isdelete,0)=0 ORDER BY clientid" @{ cid = $CompanyId })
$contactId = [long](Get-Scalar $conn "SELECT TOP 1 contactId FROM tb_contact WHERE companyID=@cid AND ClientID=@clientId AND ISNULL(isDelete,0)=0 ORDER BY contactId" @{ cid = $CompanyId; clientId = $clientId })
$deptId = [int](Get-Scalar $conn "SELECT TOP 1 ISNULL(DeptID,0) FROM tb_Department WHERE CompanyID=@cid AND CustomerID=@clientId AND ISNULL(IsDeleted,0)=0 ORDER BY DeptID" @{ cid = $CompanyId; clientId = $clientId })
$digitalPress = [long](Get-Scalar $conn "SELECT TOP 1 DigitalPressID FROM tb_DigitalPress WHERE CompanyID=@cid AND ISNULL(IsDeleted,0)=0 ORDER BY ISNULL(IsDefaultPress,0) DESC" @{ cid = $CompanyId })
$largePress = [long](Get-Scalar $conn "SELECT TOP 1 PressID FROM tb_LargeFormatPress WHERE CompanyID=@cid AND ISNULL(IsDeleted,0)=0 ORDER BY ISNULL(IsDefaultPress,0) DESC" @{ cid = $CompanyId })
$paperId = [long](Get-Scalar $conn "SELECT TOP 1 InventoryID FROM tb_inventory WHERE CompanyID=@cid AND InventoryCode=N'PAPER-130' AND ISNULL(IsDeleted,0)=0" @{ cid = $CompanyId })
$guillotineId = [long](Get-Scalar $conn "SELECT TOP 1 GuillotineID FROM tb_Guillotine WHERE CompanyID=@cid AND GuillotineName=N'Sample Guillotine' AND ISNULL(IsDeleted,0)=0" @{ cid = $CompanyId })
$largeGuillotineId = [long](Get-Scalar $conn "SELECT TOP 1 GuillotineID FROM tb_Guillotine WHERE CompanyID=@cid AND GuillotineName=N'Sample Cutting Table' AND ISNULL(IsDeleted,0)=0" @{ cid = $CompanyId })
$taxId = [int](Get-Scalar $conn "SELECT TOP 1 TaxID FROM tb_taxrates WHERE CompanyID=@cid AND ISNULL(IsDeleted,0)=0 ORDER BY TaxID" @{ cid = $CompanyId })
$now = Get-Date

foreach ($num in $sourceNumbers) {
    $srcId = [long](Get-Scalar $conn "SELECT TOP 1 EstimateID FROM tb_estimate WHERE CompanyID=@src AND EstimateNumber=@num AND ISNULL(IsDeleted,0)=0" @{ src = $sourceCompanyId; num = $num })
    if ($srcId -le 0) { Write-Warning "Source $num not found on $sourceCompanyId"; continue }

    $ins = $conn.CreateCommand()
    $ins.CommandType = [System.Data.CommandType]::StoredProcedure
    $ins.CommandText = 'PC_estimate_copy_estimate_insert_new'
    [void]$ins.Parameters.AddWithValue('@CompanyID', $CompanyId)
    [void]$ins.Parameters.AddWithValue('@Old_EstimateID', $srcId)
    [void]$ins.Parameters.AddWithValue('@DirectJObOrInvoice', '')
    [void]$ins.Parameters.AddWithValue('@UserID', $adminId)
    [void]$ins.Parameters.AddWithValue('@Date', $now)
    [void]$ins.Parameters.AddWithValue('@IsHandy', $false)
    [void]$ins.Parameters.AddWithValue('@Pgtype', '')
    [void]$ins.Parameters.AddWithValue('@EstimatePrefix', 'EST-')
    [void]$ins.Parameters.AddWithValue('@ModuleID', 0)
    $ret = $ins.Parameters.Add('@New_EstimateID', [System.Data.SqlDbType]::BigInt)
    $ret.Direction = [System.Data.ParameterDirection]::Output
    $ins.ExecuteNonQuery() | Out-Null
    $newId = [long]$ins.Parameters['@New_EstimateID'].Value
    if ($newId -le 0) { Write-Warning "Header copy failed for $num"; continue }

    $copy = $conn.CreateCommand()
    $copy.CommandType = [System.Data.CommandType]::StoredProcedure
    $copy.CommandText = 'pc_estimate_copy_all'
    [void]$copy.Parameters.AddWithValue('@CompanyID', $CompanyId)
    [void]$copy.Parameters.AddWithValue('@ModuleID', $srcId)
    [void]$copy.Parameters.AddWithValue('@NewEstimateID', $newId)
    [void]$copy.Parameters.AddWithValue('@pgType', 'estimate')
    [void]$copy.Parameters.AddWithValue('@Date', $now)
    [void]$copy.Parameters.AddWithValue('@IsHandy', $false)
    [void]$copy.Parameters.AddWithValue('@DirectJObOrInvoice', '')
    [void]$copy.Parameters.AddWithValue('@IsNewCustomer', 0)
    [void]$copy.Parameters.AddWithValue('@JobPrefix', 'JOB-')
    [void]$copy.Parameters.AddWithValue('@InvoicePrefix', 'INV-')
    $inv = $copy.Parameters.Add('@InvoiceOrJobID', [System.Data.SqlDbType]::BigInt)
    $inv.Direction = [System.Data.ParameterDirection]::Output
    $copy.ExecuteNonQuery() | Out-Null

    $fix = $conn.CreateCommand()
    $fix.CommandText = @"
UPDATE tb_estimate SET CompanyID=@cid, CustomerID=@client, AttentionID=@contact, DepartmentID=@dept,
    InvoiceAddressID=@client, SalesPerson=@admin, EstimatorId=@admin, Comments=@marker, ModifiedBy=@admin, ModifiedDate=GETDATE()
WHERE EstimateID=@newId;
UPDATE esi SET PressID=@digital, PaperID=@paper, GuillotineID=CASE WHEN @guillotine>0 THEN @guillotine ELSE esi.GuillotineID END
FROM tb_EstimateSingleItem esi INNER JOIN tb_estimateitem ei ON ei.EstimateItemID=esi.EstimateItemID
WHERE ei.EstimateID=@newId AND ei.EstimateType=N'S';
UPDATE eli SET PressID=@large, PaperID=@paper, GuillotineID=CASE WHEN @largeGuillotine>0 THEN @largeGuillotine ELSE eli.GuillotineID END
FROM tb_EstimateLargeItem eli INNER JOIN tb_estimateitem ei ON ei.EstimateItemID=eli.EstimateItemID
WHERE ei.EstimateID=@newId AND ei.EstimateType IN (N'L',N'F');
UPDATE wh SET WarehouseTypeID=CASE WHEN @paper>0 THEN @paper ELSE wh.WarehouseTypeID END
FROM tb_EstWarehouseItem wh INNER JOIN tb_estimateitem ei ON ei.EstimateItemID=wh.EstimateItemID
WHERE ei.EstimateID=@newId AND ei.EstimateType=N'W';
INSERT INTO tb_EstTotalPriceDetails (EstimateID, EstimateItemID, EstimateType, SectionID, TotalCostExMarkup1, TotalCostExMarkup2, TotalCostExMarkup3, TotalCostExMarkup4,
    TotalMarkupPrice1, TotalMarkupPrice2, TotalMarkupPrice3, TotalMarkupPrice4, TotalCostInMarkup1, TotalCostInMarkup2, TotalCostInMarkup3, TotalCostInMarkup4,
    TotalProfitMarginPercentage1, TotalProfitMarginPercentage2, TotalProfitMarginPercentage3, TotalProfitMarginPercentage4,
    TotalProfitMarginPrice1, TotalProfitMarginPrice2, TotalProfitMarginPrice3, TotalProfitMarginPrice4,
    TotalSubTotal1, TotalSubTotal2, TotalSubTotal3, TotalSubTotal4, TotalPricePerUnit1, TotalPricePerUnit2, TotalPricePerUnit3, TotalPricePerUnit4,
    TotalTaxID1, TotalTaxID2, TotalTaxID3, TotalTaxID4, TotalTaxPercentage1, TotalTaxPercentage2, TotalTaxPercentage3, TotalTaxPercentage4,
    TotalTaxPrice1, TotalTaxPrice2, TotalTaxPrice3, TotalTaxPrice4, TotalSellingPrice1, TotalSellingPrice2, TotalSellingPrice3, TotalSellingPrice4,
    TotalGrossProfitPercentage1, TotalGrossProfitPercentage2, TotalGrossProfitPercentage3, TotalGrossProfitPercentage4,
    TotalGrossProfitPrice1, TotalGrossProfitPrice2, TotalGrossProfitPrice3, TotalGrossProfitPrice4,
    IsSubTotalLocked, TotalQty1, TotalQty2, TotalQty3, TotalQty4, OrderItemShipping, QTYDescription1, QTYDescription2, QTYDescription3, QTYDescription4, CreatedDate,
    SellingPricePerSQM1, SellingPricePerSQM2, SellingPricePerSQM3, SellingPricePerSQM4, SubTotalPricePerUnit1, SubTotalPricePerUnit2, SubTotalPricePerUnit3, SubTotalPricePerUnit4)
SELECT @newId, newItem.EstimateItemID, src.EstimateType, src.SectionID, src.TotalCostExMarkup1, src.TotalCostExMarkup2, src.TotalCostExMarkup3, src.TotalCostExMarkup4,
    src.TotalMarkupPrice1, src.TotalMarkupPrice2, src.TotalMarkupPrice3, src.TotalMarkupPrice4, src.TotalCostInMarkup1, src.TotalCostInMarkup2, src.TotalCostInMarkup3, src.TotalCostInMarkup4,
    src.TotalProfitMarginPercentage1, src.TotalProfitMarginPercentage2, src.TotalProfitMarginPercentage3, src.TotalProfitMarginPercentage4,
    src.TotalProfitMarginPrice1, src.TotalProfitMarginPrice2, src.TotalProfitMarginPrice3, src.TotalProfitMarginPrice4,
    src.TotalSubTotal1, src.TotalSubTotal2, src.TotalSubTotal3, src.TotalSubTotal4, src.TotalPricePerUnit1, src.TotalPricePerUnit2, src.TotalPricePerUnit3, src.TotalPricePerUnit4,
    CASE WHEN @tax>0 THEN @tax ELSE src.TotalTaxID1 END, CASE WHEN @tax>0 THEN @tax ELSE src.TotalTaxID2 END, CASE WHEN @tax>0 THEN @tax ELSE src.TotalTaxID3 END, CASE WHEN @tax>0 THEN @tax ELSE src.TotalTaxID4 END,
    src.TotalTaxPercentage1, src.TotalTaxPercentage2, src.TotalTaxPercentage3, src.TotalTaxPercentage4, src.TotalTaxPrice1, src.TotalTaxPrice2, src.TotalTaxPrice3, src.TotalTaxPrice4,
    src.TotalSellingPrice1, src.TotalSellingPrice2, src.TotalSellingPrice3, src.TotalSellingPrice4,
    src.TotalGrossProfitPercentage1, src.TotalGrossProfitPercentage2, src.TotalGrossProfitPercentage3, src.TotalGrossProfitPercentage4,
    src.TotalGrossProfitPrice1, src.TotalGrossProfitPrice2, src.TotalGrossProfitPrice3, src.TotalGrossProfitPrice4,
    src.IsSubTotalLocked, src.TotalQty1, src.TotalQty2, src.TotalQty3, src.TotalQty4, src.OrderItemShipping, src.QTYDescription1, src.QTYDescription2, src.QTYDescription3, src.QTYDescription4, GETDATE(),
    src.SellingPricePerSQM1, src.SellingPricePerSQM2, src.SellingPricePerSQM3, src.SellingPricePerSQM4, src.SubTotalPricePerUnit1, src.SubTotalPricePerUnit2, src.SubTotalPricePerUnit3, src.SubTotalPricePerUnit4
FROM tb_EstTotalPriceDetails src
INNER JOIN tb_estimateitem oldItem ON oldItem.EstimateItemID = src.EstimateItemID AND oldItem.EstimateID = @srcId
INNER JOIN tb_estimateitem newItem ON newItem.EstimateID = @newId AND newItem.EstimateType = oldItem.EstimateType AND ISNULL(newItem.IsDeleted,0)=0
WHERE NOT EXISTS (SELECT 1 FROM tb_EstTotalPriceDetails x WHERE x.EstimateItemID = newItem.EstimateItemID);
UPDATE dest SET dest.EstimateValue = src.EstimateValue, dest.EstimateSubTotal = src.EstimateSubTotal
FROM tb_estimate dest INNER JOIN tb_estimate src ON src.EstimateID = @srcId WHERE dest.EstimateID = @newId;
"@
    [void]$fix.Parameters.AddWithValue('@cid', $CompanyId)
    [void]$fix.Parameters.AddWithValue('@client', $clientId)
    [void]$fix.Parameters.AddWithValue('@contact', $contactId)
    [void]$fix.Parameters.AddWithValue('@dept', $deptId)
    [void]$fix.Parameters.AddWithValue('@admin', $adminId)
    [void]$fix.Parameters.AddWithValue('@marker', $marker)
    [void]$fix.Parameters.AddWithValue('@newId', $newId)
    [void]$fix.Parameters.AddWithValue('@digital', $digitalPress)
    [void]$fix.Parameters.AddWithValue('@large', $(if ($largePress -gt 0) { $largePress } else { $digitalPress }))
    [void]$fix.Parameters.AddWithValue('@paper', $paperId)
    [void]$fix.Parameters.AddWithValue('@guillotine', $guillotineId)
    [void]$fix.Parameters.AddWithValue('@largeGuillotine', $largeGuillotineId)
    [void]$fix.Parameters.AddWithValue('@tax', $taxId)
    [void]$fix.Parameters.AddWithValue('@srcId', $srcId)
    $fix.ExecuteNonQuery() | Out-Null

    $title = Get-Scalar $conn 'SELECT EstimateTitle FROM tb_estimate WHERE EstimateID=@id' @{ id = $newId }
    Write-Host "Seeded $num -> estimate $newId ($title)"
}

$count = Get-Scalar $conn "SELECT COUNT(*) FROM tb_estimate WHERE CompanyID=@cid AND Comments LIKE @m AND ISNULL(IsDeleted,0)=0" @{ cid = $CompanyId; m = "%$marker%" }
Write-Host "Reference estimates on company ${CompanyId}: $count"
$conn.Close()
