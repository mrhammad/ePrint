# Repairs tenants where sign-up created tb_company + tb_user but CompleteNewCompanySetup failed.
# Requires rebuilt ePrint.dll and TestCustomizeCompile.exe (build once via csc in this folder).
param(
    [int]$CompanyId = 0
)

$ErrorActionPreference = 'Stop'
$connStr = 'Data Source=localhost;Initial Catalog=eprint_demo;User ID=sa;Password=P@ssword883104;'
$exe = Join-Path $PSScriptRoot 'TestCustomizeCompile.exe'
if (-not (Test-Path $exe)) {
    $csc = & "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe" -latest -find "MSBuild\**\Bin\Roslyn\csc.exe" 2>$null | Select-Object -First 1
    if (-not $csc) { $csc = 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe' }
    $dll = Resolve-Path (Join-Path $PSScriptRoot '..\bin\ePrint.dll')
    & $csc /nologo /out:$exe /r:$dll (Join-Path $PSScriptRoot 'TestCustomizeCompile.cs') | Out-Null
}

$conn = New-Object System.Data.SqlClient.SqlConnection $connStr
$conn.Open()
$cmd = $conn.CreateCommand()
if ($CompanyId -gt 0) {
    $cmd.CommandText = 'SELECT @id'
    $cmd.Parameters.AddWithValue('@id', $CompanyId) | Out-Null
    $ids = @($CompanyId)
} else {
    $cmd.CommandText = @"
SELECT c.companyid
FROM tb_company c
WHERE EXISTS (SELECT 1 FROM tb_user u WHERE u.companyid = c.companyid)
  AND (
    NOT EXISTS (SELECT 1 FROM tb_EstimateStatus es WHERE es.companyid = c.companyid)
    OR NOT EXISTS (SELECT 1 FROM tb_CustomizeView v WHERE v.CompanyID = c.companyid AND ISNULL(v.isDeleted, 0) = 0)
  )
ORDER BY c.companyid"
    $reader = $cmd.ExecuteReader()
    $ids = @()
    while ($reader.Read()) { $ids += [int]$reader[0] }
    $reader.Close()
}

foreach ($id in $ids) {
    Write-Host "Repairing company $id ..."
    sqlcmd -S localhost -U sa -P 'P@ssword883104' -d eprint_demo -i (Join-Path $PSScriptRoot 'Fix_NewCompany_ApplyStatuses.sql') -v CompanyId = $id | Out-Null
    & $exe $id
    $c2 = $conn.CreateCommand()
    $c2.CommandText = 'EXEC CRM_INSERT_DEFAULTVIEW @CompanyID=@c; SELECT TOP 1 userid FROM tb_user WHERE companyid=@c AND isadmin=1 ORDER BY userid'
    $c2.Parameters.AddWithValue('@c', $id) | Out-Null
    $adminId = [int]$c2.ExecuteScalar()
    $c3 = $conn.CreateCommand()
    $c3.CommandType = [System.Data.CommandType]::StoredProcedure
    $c3.CommandText = 'PC_CustomizeViewIfNotExist'
    $c3.Parameters.AddWithValue('@companyID', $id) | Out-Null
    $c3.Parameters.AddWithValue('@userID', $adminId) | Out-Null
    $c3.ExecuteNonQuery() | Out-Null
    Write-Host "  Done (admin user $adminId)."
}
$conn.Close()
Write-Host 'Repair complete.'
