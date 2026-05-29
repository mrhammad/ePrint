# One-time export: builds built-in registration seed SQL from a reference DB (default company 2144).
# Output: nms/nmsCommon/SeedData/SystemTemplatesRegistration.sql

param([int]$SourceCompanyId = 2144)

$ErrorActionPreference = 'Stop'
$projectRoot = Split-Path $PSScriptRoot -Parent
$outDir = Join-Path $projectRoot 'nms\nmsCommon\SeedData'
$outFile = Join-Path $outDir 'SystemTemplatesRegistration.sql'
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

function Sanitize-Key([string]$moduleName, [string]$name) {
    $k = ($moduleName + '_' + $name) -replace '[^a-zA-Z0-9_]', '_'
    if ($k -match '^\d') { return "T_$k" }
    return $k
}

function Sql-Value($reader, [string]$col) {
    $v = $reader[$col]
    if ($v -eq [DBNull]::Value) { return 'NULL' }
    if ($v -is [bool]) { return $(if ($v) { 1 } else { 0 }) }
    if ($v -is [string]) { return (Escape-SqlNvarchar $v) }
    if ($v -is [DateTime]) { return "'" + $v.ToString('yyyy-MM-dd HH:mm:ss.fff') + "'" }
    return $v.ToString()
}

$conn = New-Object System.Data.SqlClient.SqlConnection $connStr
$conn.Open()
$lines = New-Object System.Collections.Generic.List[string]
$lines.Add("-- Built-in System Templates registration seed (generated from company $SourceCompanyId).")
$lines.Add('-- Re-run Scripts/Export_SystemTemplatesRegistrationSeed.ps1 to refresh.')
$lines.Add('SET NOCOUNT ON;')
$lines.Add('IF @companyId <= 0 RETURN;')
$lines.Add('')

# PDFs
$pdfCmd = $conn.CreateCommand()
$pdfCmd.CommandText = 'SELECT PDFTitle, PdfName, ImageName, PDFKey, IsReady, ErrorMsg, ImageWidth, ImageHeight, ReportFileName, DateUploaded, TemplatesNo FROM tb_TemplatesPDF WHERE CompanyID = @cid'
[void]$pdfCmd.Parameters.AddWithValue('@cid', $SourceCompanyId)
$r = $pdfCmd.ExecuteReader()
while ($r.Read()) {
    $pk = Escape-SqlNvarchar $r['PDFKey'].ToString()
    $lines.Add("IF NOT EXISTS (SELECT 1 FROM tb_TemplatesPDF d WHERE d.CompanyID = @companyId AND d.PDFKey = $pk)")
    $lines.Add('INSERT INTO tb_TemplatesPDF (CompanyID, PDFTitle, PdfName, ImageName, PDFKey, IsReady, ErrorMsg, ImageWidth, ImageHeight, CreatedDate, ReportFileName, DateUploaded, TemplatesNo)')
    $lines.Add("VALUES (@companyId, $(Sql-Value $r 'PDFTitle'), $(Sql-Value $r 'PdfName'), $(Sql-Value $r 'ImageName'), $pk, $(Sql-Value $r 'IsReady'), $(Sql-Value $r 'ErrorMsg'), $(Sql-Value $r 'ImageWidth'), $(Sql-Value $r 'ImageHeight'), GETDATE(), $(Sql-Value $r 'ReportFileName'), $(Sql-Value $r 'DateUploaded'), $(Sql-Value $r 'TemplatesNo'));")
}
$r.Close()

$tplCmd = $conn.CreateCommand()
$tplCmd.CommandText = @'
SELECT TemplateID, Name, Description, Contents, ControlList, ModuleName, IsDefault, Isdelete, PDFID,
  FooterSpace, HeaderSpace, isSplit, iskeepWithPrevious, ItemSplitStatus, isCustom, IsShowPriceForAllItems,
  isSplitSubitem, isLocationBasedSorting, isGroupingBasedOnStockLocation
FROM tb_templates
WHERE CompanyID = @cid AND ISNULL(Isdelete,0)=0
  AND ModuleName IN (N'Estimate',N'PrintBroker',N'Job',N'Invoice',N'Purchase',N'Note',N'JobCard')
ORDER BY ModuleName, Name
'@
[void]$tplCmd.Parameters.AddWithValue('@cid', $SourceCompanyId)
$tplReader = $tplCmd.ExecuteReader()
$templateKeys = @{}
while ($tplReader.Read()) {
    $tid = [long]$tplReader['TemplateID']
    $name = $tplReader['Name'].ToString()
    $module = $tplReader['ModuleName'].ToString()
    $varName = '@tpl_' + (Sanitize-Key $module $name)
    $templateKeys[$tid] = $varName
    $pdfIdExpr = '0'
    if ($tplReader['PDFID'] -ne [DBNull]::Value -and [long]$tplReader['PDFID'] -gt 0) {
        $pdfIdExpr = "(SELECT TOP 1 d.PDFID FROM tb_TemplatesPDF d INNER JOIN tb_TemplatesPDF s ON s.PDFKey = d.PDFKey WHERE s.PDFID = $($tplReader['PDFID']) AND d.CompanyID = @companyId)"
    }
    $lines.Add('')
    $lines.Add("IF NOT EXISTS (SELECT 1 FROM tb_templates d WHERE d.CompanyID = @companyId AND d.ModuleName = $(Escape-SqlNvarchar $module) AND d.Name = $(Escape-SqlNvarchar $name) AND ISNULL(d.Isdelete,0)=0)")
    $lines.Add('BEGIN')
    $lines.Add("DECLARE $varName bigint;")
    $lines.Add('INSERT INTO tb_templates (CompanyID, Name, Description, Contents, ControlList, ModuleName, IsDefault, Isdelete, PDFID, FooterSpace, HeaderSpace, isSplit, iskeepWithPrevious, ItemSplitStatus, isCustom, IsShowPriceForAllItems, CreatedDate, isSplitSubitem, isLocationBasedSorting, isGroupingBasedOnStockLocation)')
    $lines.Add("VALUES (@companyId, $(Escape-SqlNvarchar $name), $(Sql-Value $tplReader 'Description'), $(Sql-Value $tplReader 'Contents'), $(Sql-Value $tplReader 'ControlList'), $(Escape-SqlNvarchar $module), $(Sql-Value $tplReader 'IsDefault'), $(Sql-Value $tplReader 'Isdelete'), $pdfIdExpr, $(Sql-Value $tplReader 'FooterSpace'), $(Sql-Value $tplReader 'HeaderSpace'), $(Sql-Value $tplReader 'isSplit'), $(Sql-Value $tplReader 'iskeepWithPrevious'), $(Sql-Value $tplReader 'ItemSplitStatus'), $(Sql-Value $tplReader 'isCustom'), $(Sql-Value $tplReader 'IsShowPriceForAllItems'), GETDATE(), $(Sql-Value $tplReader 'isSplitSubitem'), $(Sql-Value $tplReader 'isLocationBasedSorting'), $(Sql-Value $tplReader 'isGroupingBasedOnStockLocation'));")
    $lines.Add("SET $varName = SCOPE_IDENTITY();")
    $lines.Add('END')
    $lines.Add("ELSE SELECT $varName = d.TemplateID FROM tb_templates d WHERE d.CompanyID = @companyId AND d.ModuleName = $(Escape-SqlNvarchar $module) AND d.Name = $(Escape-SqlNvarchar $name) AND ISNULL(d.Isdelete,0)=0;")
}
$tplReader.Close()

foreach ($tid in $templateKeys.Keys) {
    $varName = $templateKeys[$tid]
    $fpCmd = $conn.CreateCommand()
    $fpCmd.CommandText = 'SELECT * FROM tb_TemplateFieldProperties WHERE TemplateID = @tid AND CompanyID = @cid'
    [void]$fpCmd.Parameters.AddWithValue('@tid', $tid)
    [void]$fpCmd.Parameters.AddWithValue('@cid', $SourceCompanyId)
    $fp = $fpCmd.ExecuteReader()
    while ($fp.Read()) {
        $objId = Escape-SqlNvarchar $fp['objID'].ToString()
        $pageNo = if ($fp['PageNo'] -eq [DBNull]::Value) { '0' } else { $fp['PageNo'].ToString() }
        $lines.Add("IF NOT EXISTS (SELECT 1 FROM tb_TemplateFieldProperties x WHERE x.TemplateID = $varName AND x.CompanyID = @companyId AND x.objID = $objId AND ISNULL(x.PageNo,0) = $pageNo)")
        $lines.Add('INSERT INTO tb_TemplateFieldProperties (TemplateID, CompanyID, objID, objType, objName, type, objValue, imgsrc, title, align, position, [top], [left], width, height, zindex, padding, display, overflow, fontfamily, fontsize, fontweight, fontstyle, fontcolor, textdecoration, textalign, border, backgroundcolor, visibility, maxlength, offsetwidth, offsetheight, offsettop, offsetleft, pixelwidth, pixelheight, pixeltop, [lock], canmove, canchangefontcolor, canchangefontsize, canchangefont, class, onmouseoverclass, objTag, isItem, GroupID, HGroupID, isHGroupMain, AssociatedLabel, CreatedDate, Repeat, PageNo)')
        $lines.Add("SELECT $varName, @companyId, $(Sql-Value $fp 'objID'), $(Sql-Value $fp 'objType'), $(Sql-Value $fp 'objName'), $(Sql-Value $fp 'type'), $(Sql-Value $fp 'objValue'), $(Sql-Value $fp 'imgsrc'), $(Sql-Value $fp 'title'), $(Sql-Value $fp 'align'), $(Sql-Value $fp 'position'), $(Sql-Value $fp 'top'), $(Sql-Value $fp 'left'), $(Sql-Value $fp 'width'), $(Sql-Value $fp 'height'), $(Sql-Value $fp 'zindex'), $(Sql-Value $fp 'padding'), $(Sql-Value $fp 'display'), $(Sql-Value $fp 'overflow'), $(Sql-Value $fp 'fontfamily'), $(Sql-Value $fp 'fontsize'), $(Sql-Value $fp 'fontweight'), $(Sql-Value $fp 'fontstyle'), $(Sql-Value $fp 'fontcolor'), $(Sql-Value $fp 'textdecoration'), $(Sql-Value $fp 'textalign'), $(Sql-Value $fp 'border'), $(Sql-Value $fp 'backgroundcolor'), $(Sql-Value $fp 'visibility'), $(Sql-Value $fp 'maxlength'), $(Sql-Value $fp 'offsetwidth'), $(Sql-Value $fp 'offsetheight'), $(Sql-Value $fp 'offsettop'), $(Sql-Value $fp 'offsetleft'), $(Sql-Value $fp 'pixelwidth'), $(Sql-Value $fp 'pixelheight'), $(Sql-Value $fp 'pixeltop'), $(Sql-Value $fp 'lock'), $(Sql-Value $fp 'canmove'), $(Sql-Value $fp 'canchangefontcolor'), $(Sql-Value $fp 'canchangefontsize'), $(Sql-Value $fp 'canchangefont'), $(Sql-Value $fp 'class'), $(Sql-Value $fp 'onmouseoverclass'), $(Sql-Value $fp 'objTag'), $(Sql-Value $fp 'isItem'), $(Sql-Value $fp 'GroupID'), $(Sql-Value $fp 'HGroupID'), $(Sql-Value $fp 'isHGroupMain'), $(Sql-Value $fp 'AssociatedLabel'), GETDATE(), $(Sql-Value $fp 'Repeat'), $(Sql-Value $fp 'PageNo');")
    }
    $fp.Close()
}

$jcCmd = $conn.CreateCommand()
$jcCmd.CommandText = 'SELECT SectionName, Description, IsChecked, LineSpacing, SectionKey, OrderNo, isDelete, EstimateType, ItemType FROM tb_jobcardsettings WHERE CompanyID = @cid AND ISNULL(isDelete,0)=0'
[void]$jcCmd.Parameters.AddWithValue('@cid', $SourceCompanyId)
$jc = $jcCmd.ExecuteReader()
while ($jc.Read()) {
    $sk = Escape-SqlNvarchar $jc['SectionKey'].ToString()
    $et = Escape-SqlNvarchar $jc['EstimateType'].ToString()
    $it = Escape-SqlNvarchar $jc['ItemType'].ToString()
    $lines.Add("IF NOT EXISTS (SELECT 1 FROM tb_jobcardsettings d WHERE d.CompanyID = @companyId AND ISNULL(d.isDelete,0)=0 AND d.SectionKey = $sk AND d.EstimateType = $et AND d.ItemType = $it)")
    $lines.Add('INSERT INTO tb_jobcardsettings (CompanyID, SectionName, Description, IsChecked, LineSpacing, SectionKey, OrderNo, isDelete, EstimateType, ItemType, CreatedDate)')
    $lines.Add("VALUES (@companyId, $(Sql-Value $jc 'SectionName'), $(Sql-Value $jc 'Description'), $(Sql-Value $jc 'IsChecked'), $(Sql-Value $jc 'LineSpacing'), $sk, $(Sql-Value $jc 'OrderNo'), $(Sql-Value $jc 'isDelete'), $et, $it, GETDATE());")
}
$jc.Close()
$conn.Close()

[System.IO.File]::WriteAllLines($outFile, $lines, [System.Text.UTF8Encoding]::new($false))
Write-Host "Wrote $outFile ($([math]::Round((Get-Item $outFile).Length/1MB,2)) MB)"
