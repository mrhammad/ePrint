$ErrorActionPreference = 'Stop'
$cs = Get-Content 'd:\Globo Technologies\ePrint\MyFirstProject\ePrint\nms\nmsCommon\NewCompanyDefaultSeeds.cs' -Raw
if ($cs -notmatch 'public static void ApplyPlantSettings[\s\S]*?const string sql = @"(?<s>[\s\S]*?)";') { throw 'sql not found' }
$sql = $Matches.s
$cid = 2175
$connStr = 'Data Source=localhost;Initial Catalog=eprint_demo;User ID=sa;Password=P@ssword883104;'
$conn = New-Object System.Data.SqlClient.SqlConnection $connStr
$conn.Open()
$ins = $conn.CreateCommand()
$ins.CommandText = "INSERT INTO tb_company (country,lcid,companyName,zip,noofemployee,noofuser,hearFrom,istrial,regdate,modifieddate,isnewsletter,isbusiness,expiredate,languagename,currency,datetimeformat,isgroupenabled,timezoneid,leadsHTMLEmail,marketingEmail,CreatedUserID,ExipredAfter,UniqueValue) VALUES (N'Australia',N'',N'Plant Test',N'',1,5,N'Sign Up',1,GETDATE(),GETDATE(),0,1,DATEADD(day,14,GETDATE()),N'English',N'AUD',N'dd/mm/yyyy',0,115,N't@t.com',N't@t.com',0,14,N'pt1'); SELECT CAST(SCOPE_IDENTITY() AS INT);"
$cid = [int]$ins.ExecuteScalar()
Write-Host "Company $cid"
$cmd = $conn.CreateCommand()
$cmd.CommandText = $sql
$cmd.Parameters.AddWithValue('@companyId', $cid) | Out-Null
$cmd.ExecuteNonQuery() | Out-Null
Write-Host 'ApplyPlantSettings OK'
$conn.Close()
