$outFile = Join-Path $PSScriptRoot '..\nms\nmsCommon\RegistrationBootstrapSeeds.cs'
$scripts = $PSScriptRoot

function GetSqlBlock($fileName) {
    $path = Join-Path $scripts $fileName
    if (-not (Test-Path $path)) { return '' }
    $lines = Get-Content $path | Where-Object { $_.Trim() -ne '' -and $_.Trim() -ne 'NULL' }
    return ($lines | ForEach-Object { "`t`t$_" }) -join "`n"
}

$clientSql = GetSqlBlock 'RegistrationBootstrap_Export.sql'
$contactSql = GetSqlBlock 'contactcustomize_export.sql'
$subSql = GetSqlBlock 'customizesub_export.sql'
$installSql = GetSqlBlock 'bootstrap_installment.sql'
$scheduleSql = GetSqlBlock 'bootstrap_schedule.sql'
$ownershipSql = GetSqlBlock 'bootstrap_ownership.sql'
$partnerSql = GetSqlBlock 'bootstrap_partner.sql'
$clientTypeSql = GetSqlBlock 'bootstrap_clienttype.sql'
$roleSql = GetSqlBlock 'bootstrap_role.sql'

$lookupBody = @"
		IF NOT EXISTS (SELECT 1 FROM tb_backendemailmessages WHERE companyID = @companyId)
		BEGIN
			DECLARE @welcomeMsg nvarchar(max) = N'<p>Welcome to Print Management Software,<br /><br />Thank you for registering.</p>';
			INSERT INTO tb_backendemailmessages (companyID, sectionname, languagename, message, registrationEmail, subject) VALUES
				(@companyId, N'Registration', N'English', @welcomeMsg, N'', N'Print Management Software Notification Mail'),
				(@companyId, N'Add User', N'English', @welcomeMsg, N'', N'Thank you for opting for Eprint Software'),
				(@companyId, N'Add New Company', N'English', @welcomeMsg, N'', N'Thank you for opting for Eprint Software'),
				(@companyId, N'Web To Ticket', N'English', @welcomeMsg, N'', N'Thank you for opting for Eprint Software'),
				(@companyId, N'Convert Lead', N'English', @welcomeMsg, N'', N'Thank you for opting for Eprint Software'),
				(@companyId, N'Add Task', N'English', @welcomeMsg, N'', N'Thank you for opting for Eprint Software'),
				(@companyId, N'Edit Task', N'English', @welcomeMsg, N'', N'Thank you for opting for Eprint Software'),
				(@companyId, N'Invalid Login attempts', N'English', @welcomeMsg, N'', N'Thank you for opting for eCRM247 solution');
		END
		IF NOT EXISTS (SELECT 1 FROM tb_installmentperiod WHERE companyid = @companyId)
		BEGIN
$installSql
		END
		IF NOT EXISTS (SELECT 1 FROM tb_scheduleType WHERE companyid = @companyId)
		BEGIN
$scheduleSql
		END
		IF NOT EXISTS (SELECT 1 FROM tb_ownershiptype WHERE companyid = @companyId)
		BEGIN
$ownershipSql
		END
		IF NOT EXISTS (SELECT 1 FROM tb_partnerRole WHERE companyID = @companyId)
		BEGIN
$partnerSql
		END
		IF NOT EXISTS (SELECT 1 FROM tb_clienttype WHERE companyid = @companyId)
		BEGIN
$clientTypeSql
		END
		IF NOT EXISTS (SELECT 1 FROM tb_role WHERE companyID = @companyId)
		BEGIN
$roleSql
		END
		IF NOT EXISTS (SELECT 1 FROM tb_lowernavigator WHERE companyid = @companyId)
		BEGIN
			INSERT INTO tb_lowernavigator (headername, ordernumber, companyid, colorcode, isDisplay) VALUES (N'New Lead', 2, @companyId, N'', 1);
			INSERT INTO tb_lowernavigator (headername, ordernumber, companyid, colorcode, isDisplay) VALUES (N'New Client', 3, @companyId, N'', 1);
			INSERT INTO tb_lowernavigator (headername, ordernumber, companyid, colorcode, isDisplay) VALUES (N'New Contact', 4, @companyId, N'', 1);
			INSERT INTO tb_lowernavigator (headername, ordernumber, companyid, colorcode, isDisplay) VALUES (N'New Opportunity', 5, @companyId, N'', 1);
			INSERT INTO tb_lowernavigator (headername, ordernumber, companyid, colorcode, isDisplay) VALUES (N'New Campaign', 7, @companyId, N'', 1);
			INSERT INTO tb_lowernavigator (headername, ordernumber, companyid, colorcode, isDisplay) VALUES (N'New Product', 8, @companyId, N'', 1);
			INSERT INTO tb_lowernavigator (headername, ordernumber, companyid, colorcode, isDisplay) VALUES (N'New Contract', 9, @companyId, N'', 1);
			INSERT INTO tb_lowernavigator (headername, ordernumber, companyid, colorcode, isDisplay) VALUES (N'New Ticket', 11, @companyId, N'', 1);
			INSERT INTO tb_lowernavigator (headername, ordernumber, companyid, colorcode, isDisplay) VALUES (N'New Solution', 12, @companyId, N'', 1);
			INSERT INTO tb_lowernavigator (headername, ordernumber, companyid, colorcode, isDisplay) VALUES (N'Recycle Bin', 13, @companyId, N'', 1);
		END
		IF NOT EXISTS (SELECT 1 FROM tb_uppernavigator WHERE companyid = @companyId)
		BEGIN
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'HOME', 0, @companyId, N'#2259D7', 1, N'', N'Home', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'CLIENTS', 1, @companyId, N'#2259D7', 1, N'', N'CRM', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'ESTIMATES', 2, @companyId, N'#2259D7', 1, N'', N'Estimates', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'JOBS', 3, @companyId, N'#2259D7', 1, N'', N'Jobs', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'PURCHASES', 4, @companyId, N'#2259D7', 1, N'', N'Purchases', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'DELIVERYNOTE', 5, @companyId, N'#2259D7', 1, N'', N'Delivery Note', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'INVOICES', 6, @companyId, N'#2259D7', 1, N'', N'Invoices', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'WAREHOUSE', 7, @companyId, N'#2259D7', 1, N'', N'Warehouse', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'DOCUMENTS', 8, @companyId, N'#2259D7', 1, N'', N'Documents', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'REPORTS', 9, @companyId, N'#2259D7', 1, N'', N'Reports', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'CAMPAIGN', 10, @companyId, N'#2259D7', 1, N'', N'Campaign', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'SETTINGS', 11, @companyId, N'#2259D7', 1, N'', N'Settings', N'#FFFFFF');
			INSERT INTO tb_uppernavigator (headername, ordernumber, companyid, colorcode, isdisplay, currentimage, screenname, forecolor) VALUES (N'PRODUCTCATALOGUE', 12, @companyId, N'#8484FF', 1, N'', N'Products', N'#FFFFFF');
		END
"@

$header = @'
using System.Data.SqlClient;

namespace nmsCommon
{
	/// <summary>Built-in CRM registration template. No runtime read from company 0 or 2144.</summary>
	internal static class RegistrationBootstrapSeeds
	{
		public static void Apply(int companyId, SqlConnection connection)
		{
			if (companyId <= 0 || connection == null)
			{
				return;
			}

			Execute(companyId, connection, LookupAndNavigationSql);
			Execute(companyId, connection, ClientCustomizeSql);
			Execute(companyId, connection, ContactCustomizeSql);
			Execute(companyId, connection, CustomizeSubsectionSql);
		}

		private static void Execute(int companyId, SqlConnection connection, string sql)
		{
			using (SqlCommand command = new SqlCommand(sql, connection))
			{
				command.Parameters.AddWithValue("@companyId", companyId);
				command.ExecuteNonQuery();
			}
		}

		private const string LookupAndNavigationSql = @"
'@

$footer = @'
";

		private const string ClientCustomizeSql = @"
		IF NOT EXISTS (SELECT 1 FROM tb_clientcustomize WHERE companyId = @companyId)
		BEGIN
'@ + "`n" + $clientSql + "`n`t`tEND";

$footer2 = @'
";

		private const string ContactCustomizeSql = @"
		IF NOT EXISTS (SELECT 1 FROM tb_contactcustomize WHERE companyId = @companyId)
		BEGIN
'@

# Fix footer construction - use string concat properly
$part1 = $header + $lookupBody + '";'
$part2 = "`n`n`t`tprivate const string ClientCustomizeSql = @`"`n`t`tIF NOT EXISTS (SELECT 1 FROM tb_clientcustomize WHERE companyId = @companyId)`n`t`tBEGIN`n" + $clientSql + "`n`t`tEND`";"
$part3 = "`n`n`t`tprivate const string ContactCustomizeSql = @`"`n`t`tIF NOT EXISTS (SELECT 1 FROM tb_contactcustomize WHERE companyId = @companyId)`n`t`tBEGIN`n" + $contactSql + "`n`t`tEND`";"
$part4 = "`n`n`t`tprivate const string CustomizeSubsectionSql = @`"`n`t`tIF NOT EXISTS (SELECT 1 FROM tb_customizesubsection WHERE companyid = @companyId)`n`t`tBEGIN`n" + $subSql + "`n`t`tEND`";"
$part5 = "`n`t}`n}`n"

$content = $part1 + $part2 + $part3 + $part4 + $part5
[System.IO.File]::WriteAllText($outFile, $content)
Write-Host "Generated $($content.Length) chars -> $outFile"
