# Seeds DEMO sample estimates using stored procedures (Web.config CRM connection).
# Usage: .\SeedSampleEstimatesForCompany.ps1 -CompanyId 2174

param(
    [Parameter(Mandatory = $true)]
    [int]$CompanyId
)

$ErrorActionPreference = 'Stop'
$projectRoot = Split-Path $PSScriptRoot -Parent
$webConfig = Join-Path $projectRoot 'Web.config'
$connStr = ([xml](Get-Content $webConfig)).configuration.connectionStrings.add |
    Where-Object { $_.name -eq 'CRMConnectionString' } | Select-Object -ExpandProperty connectionString
if ([string]::IsNullOrWhiteSpace($connStr)) {
    $connStr = 'Data Source=localhost;Initial Catalog=eprint_demo;User ID=sa;Password=P@ssword883104;'
}

function Invoke-SpNonQuery($connection, $spName, $params) {
    $cmd = $connection.CreateCommand()
    $cmd.CommandType = [System.Data.CommandType]::StoredProcedure
    $cmd.CommandText = $spName
    foreach ($p in $params.GetEnumerator()) {
        [void]$cmd.Parameters.AddWithValue($p.Key, $p.Value)
    }
    $cmd.ExecuteNonQuery() | Out-Null
}

function Get-Scalar($connection, $sql, $params) {
    $cmd = $connection.CreateCommand()
    $cmd.CommandText = $sql
    foreach ($p in $params.GetEnumerator()) {
        [void]$cmd.Parameters.AddWithValue($p.Key, $p.Value)
    }
    return $cmd.ExecuteScalar()
}

$conn = New-Object System.Data.SqlClient.SqlConnection $connStr
$conn.Open()

$adminId = [int](Get-Scalar $conn 'SELECT TOP 1 userid FROM tb_user WHERE companyid=@cid AND isadmin=1 ORDER BY userid' @{ cid = $CompanyId })
if ($adminId -le 0) { throw "No admin user for company $CompanyId" }

$statusId = [int](Get-Scalar $conn "SELECT TOP 1 StatusID FROM tb_EstimateStatus WHERE companyid=@cid AND ISNULL(IsDeleted,0)=0 AND ISNULL(Estimate,0)=1 ORDER BY ISNULL(EstimateDefault,0) DESC, StatusID" @{ cid = $CompanyId })
$clientId = [int](Get-Scalar $conn "SELECT TOP 1 clientid FROM tb_client WHERE companyID=@cid AND companytype=N'Customer' AND ISNULL(isdelete,0)=0 ORDER BY clientid" @{ cid = $CompanyId })
$contactId = [long](Get-Scalar $conn "SELECT TOP 1 contactId FROM tb_contact WHERE companyID=@cid AND ClientID=@clientId AND ISNULL(isDelete,0)=0 ORDER BY CASE WHEN ISNULL(DefaultContact,0)=1 THEN 0 ELSE 1 END, contactId" @{ cid = $CompanyId; clientId = $clientId })
$deptId = [long](Get-Scalar $conn "SELECT TOP 1 DeptID FROM tb_Department WHERE CompanyID=@cid AND CustomerID=@clientId AND ISNULL(IsDeleted,0)=0 ORDER BY DeptID" @{ cid = $CompanyId; clientId = $clientId })
$validFor = [int](Get-Scalar $conn "SELECT TOP 1 ISNULL(ValidFor,14) FROM tb_defaultsettings WHERE CompanyID=@cid" @{ cid = $CompanyId })
if ($validFor -le 0) { $validFor = 14 }

$types = @(
    @{ Seq = 1; Code = 'S'; Title = 'Sample - Sheet Fed Digital' },
    @{ Seq = 2; Code = 'L'; Title = 'Sample - Sheet Fed Offset' },
    @{ Seq = 3; Code = 'F'; Title = 'Sample - Large Format' },
    @{ Seq = 4; Code = 'O'; Title = 'Sample - Outwork' },
    @{ Seq = 5; Code = 'U'; Title = 'Sample - Other Cost' },
    @{ Seq = 6; Code = 'W'; Title = 'Sample - Warehouse' },
    @{ Seq = 7; Code = 'Q'; Title = 'Sample - Quick Quote' }
)

$now = Get-Date
foreach ($t in $types) {
    $estNum = 'DEMO-' + ('{0:000}' -f $t.Seq)
    $exists = Get-Scalar $conn 'SELECT COUNT(1) FROM tb_estimate WHERE CompanyID=@cid AND EstimateNumber=@num AND ISNULL(IsDeleted,0)=0' @{ cid = $CompanyId; num = $estNum }
    if ([int]$exists -gt 0) {
        Write-Host "Skip $estNum (exists)"
        continue
    }

    $estCmd = $conn.CreateCommand()
    $estCmd.CommandType = [System.Data.CommandType]::StoredProcedure
    $estCmd.CommandText = 'PC_estimate_insert_new_stage1'
    $estParams = @{
        '@CompanyID' = $CompanyId; '@UserID' = $adminId; '@CustomerID' = $clientId; '@AttentionID' = $contactId
        '@Greeting' = ''; '@Company' = ''; '@Address' = 0; '@Header' = ''; '@Footer' = ''
        '@SalesPerson' = $adminId; '@EstimateTitle' = $t.Title; '@EstimateNumber' = $estNum; '@OrderNumber' = ''
        '@StatusID' = $statusId; '@EstimateDate' = $now; '@ValidFor' = $validFor; '@DeliveryAddress' = 0
        '@IsConvertedToJob' = $false; '@ModifiedDate' = $now; '@ModifiedBy' = $adminId; '@EstimateID' = 0
        '@IsForInvoice' = $false; '@AddressType' = 'A'; '@DeliveryAddressType' = 'A'; '@CurrentEstNo' = 0
        '@EstimatedArtwork' = $now; '@EstimatedDelivery' = $now; '@PageType' = 'estimate'
        '@EstProofDate' = $now; '@EstApprovalDate' = $now; '@EstProductionDate' = $now; '@EstCompletionDate' = $now
        '@InvoiceAddressID' = 0; '@DepartmentID' = $deptId; '@CostCentreID' = 0; '@EstimatorId' = $adminId
        '@Comments' = 'Registration sample estimate'; '@InvoiceContactId' = $contactId; '@priority' = ''
        '@CustomDate1' = [DBNull]::Value; '@CustomDate2' = [DBNull]::Value; '@CustomDate3' = [DBNull]::Value
        '@CustomDate4' = [DBNull]::Value; '@CustomDate5' = [DBNull]::Value
    }
    foreach ($p in $estParams.GetEnumerator()) { [void]$estCmd.Parameters.AddWithValue($p.Key, $p.Value) }
    $ret = $estCmd.Parameters.Add('@ReturnID', [System.Data.SqlDbType]::BigInt)
    $ret.Direction = [System.Data.ParameterDirection]::Output
    $estCmd.ExecuteNonQuery() | Out-Null
    $estimateId = [long]$estCmd.Parameters['@ReturnID'].Value
    if ($estimateId -le 0) { Write-Warning "Failed header $estNum"; continue }

    $itemCmd = $conn.CreateCommand()
    $itemCmd.CommandType = [System.Data.CommandType]::StoredProcedure
    $itemCmd.CommandText = 'PC_estimate_item_insert_new'
    [void]$itemCmd.Parameters.AddWithValue('@CompanyID', $CompanyId)
    [void]$itemCmd.Parameters.AddWithValue('@EstimateID', $estimateId)
    [void]$itemCmd.Parameters.AddWithValue('@EstimateType', $t.Code)
    [void]$itemCmd.Parameters.AddWithValue('@IsParentItem', $true)
    [void]$itemCmd.Parameters.AddWithValue('@ParentItemID', 0)
    [void]$itemCmd.Parameters.AddWithValue('@ProductID', 0)
    $itemRet = $itemCmd.Parameters.Add('@ReturnID', [System.Data.SqlDbType]::BigInt)
    $itemRet.Direction = [System.Data.ParameterDirection]::Output
    $itemCmd.ExecuteNonQuery() | Out-Null
    $itemId = [long]$itemCmd.Parameters['@ReturnID'].Value

    Invoke-SpNonQuery $conn 'PC_estimate_item_details_insert' @{
        '@CompanyID' = $CompanyId; '@EstimateID' = $estimateId; '@EstimateItemID' = $itemId; '@EstimateType' = $t.Code
    }

    Write-Host "Created $estNum ($($t.Code)) estimateId=$estimateId itemId=$itemId"
}

$conn.Close()

# Item bodies via SQL script
$backfill = Join-Path $PSScriptRoot 'Backfill_SampleEstimateItemBodies.sql'
$sql = (Get-Content $backfill -Raw) -replace '\$\(companyId\)', $CompanyId.ToString()
sqlcmd -S localhost -U sa -P 'P@ssword883104' -d eprint_demo -Q $sql | Out-Host
Write-Host 'Done.'
