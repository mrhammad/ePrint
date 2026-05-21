$ErrorActionPreference = 'Stop'
$email = "fullreg_{0:yyyyMMddHHmmss}@globotech.test" -f (Get-Date)
$connStr = 'Data Source=localhost;Initial Catalog=eprint_demo;User ID=sa;Password=P@ssword883104;'
$conn = New-Object System.Data.SqlClient.SqlConnection $connStr
$conn.Open()

# 1. RegisterNew equivalent
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
IF EXISTS (SELECT 1 FROM tb_user WHERE email=@email) RAISERROR('exists',16,1);
INSERT INTO tb_company (country,lcid,companyName,address,city,zip,noofemployee,noofuser,hearFrom,comment,istrial,regdate,modifieddate,isnewsletter,isbusiness,expiredate,languagename,currency,datetimeformat,isgroupenabled,timezoneid,leadsHTMLEmail,marketingEmail,CreatedUserID,ExipredAfter,UniqueValue)
VALUES (N'Australia',N'',N'Full Reg Test',N'',N'',N'',1,5,N'Sign Up',N'',1,GETDATE(),GETDATE(),0,1,DATEADD(day,14,GETDATE()),N'English',N'AUD',N'dd/mm/yyyy',0,115,@email,@email,0,14,@uv);
SELECT CAST(SCOPE_IDENTITY() AS INT);
"@
$cmd.Parameters.AddWithValue('@email', $email) | Out-Null
$cmd.Parameters.AddWithValue('@uv', [guid]::NewGuid().ToString('N')) | Out-Null
$companyId = [int]$cmd.ExecuteScalar()
Write-Host "CompanyId=$companyId"

# 2. Admin user via SP
$cmd2 = $conn.CreateCommand()
$cmd2.CommandType = [System.Data.CommandType]::StoredProcedure
$cmd2.CommandText = 'crm_user_add_withAccessRights'
$cmd2.Parameters.AddWithValue('@companyid', $companyId) | Out-Null
$cmd2.Parameters.AddWithValue('@email', $email) | Out-Null
$cmd2.Parameters.AddWithValue('@password', 'x') | Out-Null
$cmd2.Parameters.AddWithValue('@firstname', 'Auto') | Out-Null
$cmd2.Parameters.AddWithValue('@lastname', 'Test') | Out-Null
$cmd2.Parameters.AddWithValue('@phone', '') | Out-Null
$cmd2.Parameters.AddWithValue('@jobtitle', 'Administrator') | Out-Null
$cmd2.Parameters.AddWithValue('@isadmin', 1) | Out-Null
$cmd2.Parameters.AddWithValue('@createdate', (Get-Date).ToString()) | Out-Null
$cmd2.Parameters.AddWithValue('@modifieddate', (Get-Date).ToString()) | Out-Null
$cmd2.Parameters.AddWithValue('@timezoneid', 115) | Out-Null
$cmd2.Parameters.AddWithValue('@ispasswordexpire', 0) | Out-Null
$cmd2.Parameters.AddWithValue('@expiredate', (Get-Date).AddYears(10).ToString()) | Out-Null
$cmd2.Parameters.AddWithValue('@groupid', 0) | Out-Null
$cmd2.Parameters.AddWithValue('@usertypeid', 0) | Out-Null
$cmd2.Parameters.AddWithValue('@iscorporateright', 1) | Out-Null
$cmd2.Parameters.AddWithValue('@verificationcode', '') | Out-Null
$cmd2.ExecuteNonQuery() | Out-Null
Write-Host 'Admin user OK'

# 3. Seeds from code files
$country = (Get-Content 'd:\Globo Technologies\ePrint\MyFirstProject\ePrint\nms\nmsCommon\CountryOptionValues.cs' -Raw)
if ($country -notmatch 'List\s*=\s*\r?\n\s*"([^"]+)"') { throw 'country' }
$countryList = $matches[1]
$rb = Get-Content 'd:\Globo Technologies\ePrint\MyFirstProject\ePrint\nms\nmsCommon\RegistrationBootstrapSeeds.cs' -Raw
$nc = Get-Content 'd:\Globo Technologies\ePrint\MyFirstProject\ePrint\nms\nmsCommon\NewCompanyDefaultSeeds.cs' -Raw

function Run-Sql($sql, $label) {
  $resolved = $sql.Replace('{COUNTRY_LIST}', $countryList.Replace("'","''"))
  $c = $conn.CreateCommand()
  $c.CommandText = $resolved
  $c.Parameters.AddWithValue('@companyId', $companyId) | Out-Null
  try { $c.ExecuteNonQuery() | Out-Null; Write-Host "$label OK" }
  catch { Write-Host "$label FAIL: $($_.Exception.Message)"; throw }
}

foreach ($n in @('LookupAndNavigationSql','ClientCustomizeSql','ContactCustomizeSql','CustomizeSubsectionSql')) {
  if ($rb -notmatch "private const string $n = @`"([\s\S]*?)`";") { throw $n }
  Run-Sql $matches[1] $n
}

foreach ($m in @('ApplyStatuses','ApplyLookupAndEstimateSettings','ApplyPlantSettings')) {
  if ($nc -notmatch "public static void $m[\s\S]*?const string sql = @`"([\s\S]*?)`";") { throw $m }
  Run-Sql $matches[1] $m
}

# CustomizeViews - build from parts
$cols = ($nc | Select-String -Pattern 'CustomizeViewInsertColumns = @"(?<s>[\s\S]*?)";' ).Matches[0].Groups['s'].Value
$defs = ($nc | Select-String -Pattern 'CustomizeViewDefaults = @"(?<s>[\s\S]*?)";' ).Matches[0].Groups['s'].Value
$body = ($nc | Select-String -Pattern 'CustomizeViewsSql = @"(?<s>[\s\S]*?)" \+ CustomizeViewInsertColumns' ).Matches[0].Groups['s'].Value
$tail = ($nc | Select-String -Pattern 'CustomizeViewDefaults \+ @"(?<s>[\s\S]*?)";' ).Matches[0].Groups['s'].Value
$cvSql = $body + $cols + $tail
Run-Sql $cvSql 'CustomizeViews'

# Regional + CRM_INSERT_DEFAULTVIEW + proof
$c = $conn.CreateCommand()
$c.CommandText = "IF NOT EXISTS (SELECT 1 FROM tb_RegionalSettings WHERE CompanyID=@companyId AND IsDeleted=0) INSERT INTO tb_RegionalSettings (CompanyID,LanguageID,DateFormat,TimeZoneID,Roundoff,IsDeleted,CreatedDate,FisCalFrom,FisCalTo,IsDisplayCostCentre,GeneralWeight) VALUES (@companyId,3,N'dd/mm/yyyy',115,2,0,GETDATE(),'2026-01-01','2026-12-01',0,'')"
$c.Parameters.AddWithValue('@companyId',$companyId)|Out-Null
$c.ExecuteNonQuery()|Out-Null
$c.CommandText = 'CRM_INSERT_DEFAULTVIEW'; $c.CommandType = [System.Data.CommandType]::StoredProcedure
$c.Parameters.Clear(); $c.Parameters.AddWithValue('@CompanyID',$companyId)|Out-Null
$c.ExecuteNonQuery()|Out-Null
$adminId = 0
$c.CommandType = [System.Data.CommandType]::Text
$c.CommandText = 'SELECT TOP 1 userid FROM tb_user WHERE companyid=@companyId AND isadmin=1'
$c.Parameters.Clear(); $c.Parameters.AddWithValue('@companyId',$companyId)|Out-Null
$adminId = [int]$c.ExecuteScalar()
$c.CommandType = [System.Data.CommandType]::StoredProcedure
$c.CommandText = 'PC_CustomizeViewIfNotExist'
$c.Parameters.Clear()
$c.Parameters.AddWithValue('@companyID',$companyId)|Out-Null
$c.Parameters.AddWithValue('@userID',$adminId)|Out-Null
$c.ExecuteNonQuery()|Out-Null
Write-Host 'Regional, default views, proof OK'

# Verify
$c.CommandType = [System.Data.CommandType]::Text
$c.CommandText = @"
SELECT
 (SELECT COUNT(*) FROM tb_CustomizeView WHERE CompanyID=@companyId AND ISNULL(isDeleted,0)=0) cv,
 (SELECT COUNT(*) FROM tb_clientcustomize WHERE companyId=@companyId) cc,
 (SELECT COUNT(*) FROM tb_EstimateStatus WHERE companyid=@companyId) es,
 (SELECT COUNT(*) FROM tb_LithoPress WHERE CompanyID=@companyId AND ISNULL(IsDeleted,0)=0) press
"@
$c.Parameters.Clear(); $c.Parameters.AddWithValue('@companyId',$companyId)|Out-Null
$r = $c.ExecuteReader(); $r.Read()
Write-Host "CustomizeViews=$($r['cv']) ClientCustomize=$($r['cc']) EstimateStatus=$($r['es']) Press=$($r['press'])"
$r.Close()
$conn.Close()
Write-Host "SUCCESS company=$companyId email=$email"
