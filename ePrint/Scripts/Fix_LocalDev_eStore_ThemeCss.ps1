# Creates missing eStore theme CSS files for local dev (localhost:2222).
# URLs are built as: {PublicDocPath}{ServerName}/store/{AccountId}/Themes/...
# Master CSS: {PublicDocPath}store/0/Themes/StyleSheet_B2B_Live404.css
#
# Requires tb_B2B_AppSettings.ServerName (e.g. "demo") and account id (e.g. 298).

param(
    [string]$WebStoreRoot = (Join-Path $PSScriptRoot "..\ePrint.WebStore"),
    [string]$ServerName = "demo",
    [int[]]$AccountIds = @(298)
)

$docRoot = Join-Path $WebStoreRoot "document"
$masterThemes = Join-Path $docRoot "store\0\Themes"
$templateCustom = Join-Path $docRoot "v3demo\store\52\Themes\CustomStyleSheet.css"
$templateB2B = Join-Path $docRoot "store\0\Themes\StyleSheet_B2B.css"

if (-not (Test-Path $templateB2B)) {
    Write-Error "Template not found: $templateB2B"
    exit 1
}

New-Item -ItemType Directory -Force -Path $masterThemes | Out-Null
$live404 = Join-Path $masterThemes "StyleSheet_B2B_Live404.css"
if (-not (Test-Path $live404)) {
    Copy-Item $templateB2B $live404 -Force
    Write-Host "Created $live404"
}

foreach ($accountId in $AccountIds) {
    $themes = Join-Path $docRoot "$ServerName\store\$accountId\Themes"
    New-Item -ItemType Directory -Force -Path $themes | Out-Null

    $custom = Join-Path $themes "CustomStyleSheet.css"
    $b2b = Join-Path $themes "StyleSheet_B2B.css"

    if (-not (Test-Path $custom)) {
        if (Test-Path $templateCustom) {
            Copy-Item $templateCustom $custom -Force
        } else {
            Set-Content -Path $custom -Value "/* local dev placeholder */" -Encoding UTF8
        }
        Write-Host "Created $custom"
    }

    if (-not (Test-Path $b2b)) {
        Copy-Item $templateB2B $b2b -Force
        Write-Host "Created $b2b"
    }
}

Write-Host "Done. Restart eStore (port 2222) if IIS had cached 404s."
