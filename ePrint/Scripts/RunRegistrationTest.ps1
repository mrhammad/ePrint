# End-to-end registration test using built ePrint.dll
$ErrorActionPreference = 'Stop'
$bin = 'd:\Globo Technologies\ePrint\MyFirstProject\ePrint\bin'

$resolveHandler = {
    param($sender, $e)
    $name = ($e.Name -split ',')[0]
    $path = Join-Path $bin ($name + '.dll')
    if (Test-Path $path) { return [System.Reflection.Assembly]::LoadFrom($path) }
    return $null
}
[System.AppDomain]::CurrentDomain.add_AssemblyResolve($resolveHandler) | Out-Null

$asm = [System.Reflection.Assembly]::LoadFrom((Join-Path $bin 'ePrint.dll'))
$regType = $asm.GetType('nmsCommon.registrationClass')
if (-not $regType) { throw 'Could not load nmsCommon.registrationClass' }

$email = "regtest_{0:yyyyMMddHHmmss}@globotech.test" -f (Get-Date)
Write-Host "Registering $email"

$reg = [Activator]::CreateInstance($regType)
$now = [DateTime]::Now
$guid = [guid]::NewGuid().ToString('N').Substring(0, 50)

$companyId = $regType.GetMethod('RegisterNew').Invoke($reg, @(
    'Australia', '', 'Auto Reg Test LLC', '', '', '', 1, 5, 'Sign Up', '',
    1, $now, $now, 0, 1, $now.AddDays(14), 'English', 'AUD', 0, 115, 'dd/mm/yyyy',
    $email, 0, 14, $guid
))
Write-Host "RegisterNew returned: $companyId"
if ([int]$companyId -le 0) { throw 'RegisterNew failed' }

$regType.GetMethod('RegisterAdminUser').Invoke($reg, @($companyId, $email, 'testpass123', 'Auto', 'Test', '', 115))
Write-Host 'Admin user created'

try {
    $regType.GetMethod('CompleteNewCompanySetup').Invoke($reg, @([int]$companyId, 115, 'dd/mm/yyyy'))
    Write-Host "CompleteNewCompanySetup OK for company $companyId"
}
catch {
    Write-Host "CompleteNewCompanySetup FAILED: $($_.Exception.InnerException.Message)"
    Write-Host $_.Exception.ToString()
    throw
}

$connStr = 'Data Source=localhost;Initial Catalog=eprint_demo;User ID=sa;Password=P@ssword883104;'
$conn = New-Object System.Data.SqlClient.SqlConnection $connStr
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT
  (SELECT COUNT(*) FROM tb_CustomizeView WHERE CompanyID=@cid AND ISNULL(isDeleted,0)=0) CustomizeViews,
  (SELECT COUNT(*) FROM tb_clientcustomize WHERE companyId=@cid) ClientCustomize,
  (SELECT COUNT(*) FROM tb_client WHERE companyID=@cid AND companytype='Customer' AND ISNULL(isdelete,0)=0) Customers,
  (SELECT COUNT(*) FROM tb_user WHERE companyid=@cid) Users,
  (SELECT COUNT(*) FROM tb_EstimateStatus WHERE companyid=@cid) EstimateStatuses
"@
$cmd.Parameters.AddWithValue('@cid', [int]$companyId) | Out-Null
$r = $cmd.ExecuteReader()
if ($r.Read()) {
    Write-Host "CustomizeViews=$($r['CustomizeViews']) ClientCustomize=$($r['ClientCustomize']) Customers=$($r['Customers']) Users=$($r['Users']) EstimateStatuses=$($r['EstimateStatuses'])"
}
$r.Close(); $conn.Close()
Write-Host 'SUCCESS - company' $companyId 'email' $email
