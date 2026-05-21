# Simulates SignUp registration against eprint_demo
$ErrorActionPreference = 'Stop'
$connStr = 'Data Source=localhost;Initial Catalog=eprint_demo;User ID=sa;Password=P@ssword883104;'
$email = "autotest_{0:yyyyMMddHHmmss}@globotech.test" -f (Get-Date)
$companyName = "Auto Test Co"
$uniqueValue = [guid]::NewGuid().ToString('N').Substring(0, 50)
$now = Get-Date

Write-Host "Testing registration for $email"

$conn = New-Object System.Data.SqlClient.SqlConnection $connStr
$conn.Open()
try {
    $check = $conn.CreateCommand()
    $check.CommandText = 'SELECT TOP 1 1 FROM tb_user WHERE email = @email'
    $check.Parameters.AddWithValue('@email', $email) | Out-Null
    if ($check.ExecuteScalar()) { throw "Email already exists" }

    $insert = $conn.CreateCommand()
    $insert.CommandText = @"
INSERT INTO tb_company (
	country, lcid, companyName, address, city, zip, noofemployee, noofuser, hearFrom, comment,
	istrial, regdate, modifieddate, isnewsletter, isbusiness, expiredate, languagename, currency,
	datetimeformat, isgroupenabled, timezoneid, leadsHTMLEmail, marketingEmail, CreatedUserID,
	ExipredAfter, UniqueValue)
VALUES (
	@country, @lcid, @companyname, @address, @city, @zip, @noofemployee, @noofuser, @hearfrom, @comment,
	1, @regdate, @modifieddate, @isnewsletter, @isbusiness, @expiredate, @languagename, @currency,
	@datetimeformat, @isgroupenabled, @timezoneid, @email, @email, @createuserid, @expires, @UniqueValue);
SELECT CAST(SCOPE_IDENTITY() AS INT);
"@
    $insert.Parameters.AddWithValue('@country', 'Australia') | Out-Null
    $insert.Parameters.AddWithValue('@lcid', '') | Out-Null
    $insert.Parameters.AddWithValue('@companyname', $companyName) | Out-Null
    $insert.Parameters.AddWithValue('@address', '') | Out-Null
    $insert.Parameters.AddWithValue('@city', '') | Out-Null
    $insert.Parameters.AddWithValue('@zip', '') | Out-Null
    $insert.Parameters.AddWithValue('@noofemployee', 1) | Out-Null
    $insert.Parameters.AddWithValue('@noofuser', 5) | Out-Null
    $insert.Parameters.AddWithValue('@hearfrom', 'Sign Up') | Out-Null
    $insert.Parameters.AddWithValue('@comment', '') | Out-Null
    $insert.Parameters.AddWithValue('@regdate', $now) | Out-Null
    $insert.Parameters.AddWithValue('@modifieddate', $now) | Out-Null
    $insert.Parameters.AddWithValue('@isnewsletter', 0) | Out-Null
    $insert.Parameters.AddWithValue('@isbusiness', 1) | Out-Null
    $insert.Parameters.AddWithValue('@expiredate', $now.AddDays(14)) | Out-Null
    $insert.Parameters.AddWithValue('@languagename', 'English') | Out-Null
    $insert.Parameters.AddWithValue('@currency', 'AUD') | Out-Null
    $insert.Parameters.AddWithValue('@datetimeformat', 'dd/mm/yyyy') | Out-Null
    $insert.Parameters.AddWithValue('@isgroupenabled', 0) | Out-Null
    $insert.Parameters.AddWithValue('@timezoneid', 115) | Out-Null
    $insert.Parameters.AddWithValue('@email', $email) | Out-Null
    $insert.Parameters.AddWithValue('@createuserid', 0) | Out-Null
    $insert.Parameters.AddWithValue('@expires', 14) | Out-Null
    $insert.Parameters.AddWithValue('@UniqueValue', $uniqueValue) | Out-Null
    $companyId = [int]$insert.ExecuteScalar()
    Write-Host "Company created: $companyId"

    # Try loading built assembly and running seeds
    $dll = Get-ChildItem -Path "d:\Globo Technologies\ePrint\MyFirstProject\ePrint" -Recurse -Filter 'ePrint.dll' -ErrorAction SilentlyContinue | Sort-Object LastWriteTime -Descending | Select-Object -First 1
    if ($dll) {
        Write-Host "Using DLL: $($dll.FullName)"
        Add-Type -Path $dll.FullName -ErrorAction SilentlyContinue
    }
}
finally { $conn.Close() }
