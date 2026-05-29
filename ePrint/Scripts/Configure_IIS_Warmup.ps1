#requires -RunAsAdministrator
<#
.SYNOPSIS
    Configures IIS for ePrint application warm-up so the login screen
    (and the rest of the app) no longer pays a cold-start cost.

.DESCRIPTION
    This script is intended to be run ONCE on the production IIS server
    after deploying the ePrint web application.

    It performs the following changes:
        1. Verifies (and reports if missing) the "Application Initialization"
           IIS feature.
        2. Sets the application pool startMode to AlwaysRunning so the
           worker process is started at server boot instead of on first
           request.
        3. Disables app-pool idle timeout (no more "I haven't used it for
           20 minutes, recompile everything").
        4. Disables the fixed periodic recycle that defaults to every
           1740 minutes (~29 hours).
        5. Enables preloadEnabled on the site/application so IIS triggers
           the warm-up URLs from web.config (<applicationInitialization>)
           at process start.

.PARAMETER SiteName
    IIS site name that hosts ePrint. Default: "ePrint".

.PARAMETER AppPath
    Application path inside the site (use "/" for the site root).
    Default: "/".

.PARAMETER AppPoolName
    Application pool name. If not supplied, the script reads it from the
    site/application binding.

.EXAMPLE
    .\Configure_IIS_Warmup.ps1 -SiteName "ePrint"

.EXAMPLE
    .\Configure_IIS_Warmup.ps1 -SiteName "Default Web Site" -AppPath "/eprint" -AppPoolName "ePrintAppPool"
#>

param(
    [Parameter(Mandatory = $false)]
    [string]$SiteName = "ePrint",

    [Parameter(Mandatory = $false)]
    [string]$AppPath = "/",

    [Parameter(Mandatory = $false)]
    [string]$AppPoolName
)

$ErrorActionPreference = "Stop"

Write-Host "=== ePrint IIS Warm-up Configuration ===" -ForegroundColor Cyan
Write-Host ""

# 1. Load the IIS administration module.
try {
    Import-Module WebAdministration -ErrorAction Stop
} catch {
    Write-Error "Failed to load the WebAdministration module. Run this script on the IIS server in an elevated PowerShell session."
    exit 1
}

# 2. Verify Application Initialization feature is present.
$feature = Get-WindowsFeature -Name Web-AppInit -ErrorAction SilentlyContinue
if ($feature -and -not $feature.Installed) {
    Write-Warning "The 'Application Initialization' IIS feature (Web-AppInit) is NOT installed."
    Write-Host  "  Install it with: Install-WindowsFeature -Name Web-AppInit" -ForegroundColor Yellow
    Write-Host  "  Continuing, but warm-up will not run until the feature is installed." -ForegroundColor Yellow
} else {
    Write-Host "[OK] Application Initialization feature is installed." -ForegroundColor Green
}

# 3. Resolve the IIS site and application.
$site = Get-Website -Name $SiteName -ErrorAction SilentlyContinue
if (-not $site) {
    Write-Error "IIS site '$SiteName' not found."
    exit 1
}
Write-Host ("[OK] Found IIS site '{0}' (state: {1})." -f $site.Name, $site.State) -ForegroundColor Green

# 4. Determine the application pool name if not supplied.
$appConfigPath = "IIS:\Sites\$SiteName" + ($(if ($AppPath -eq "/") { "" } else { $AppPath }))
if (-not $AppPoolName) {
    try {
        $AppPoolName = (Get-ItemProperty -Path $appConfigPath -Name applicationPool -ErrorAction Stop).Value
        if (-not $AppPoolName) {
            $AppPoolName = $site.applicationPool
        }
    } catch {
        $AppPoolName = $site.applicationPool
    }
}

if (-not $AppPoolName) {
    Write-Error "Could not determine the application pool. Pass -AppPoolName explicitly."
    exit 1
}
Write-Host ("[OK] Application pool: {0}" -f $AppPoolName) -ForegroundColor Green

# 5. Configure the application pool.
$poolPath = "IIS:\AppPools\$AppPoolName"
if (-not (Test-Path $poolPath)) {
    Write-Error "Application pool '$AppPoolName' not found in IIS."
    exit 1
}

Write-Host ""
Write-Host "Applying application pool settings ..." -ForegroundColor Cyan
Set-ItemProperty -Path $poolPath -Name "startMode"                      -Value "AlwaysRunning"
Set-ItemProperty -Path $poolPath -Name "processModel.idleTimeout"       -Value ([TimeSpan]::Zero)
Set-ItemProperty -Path $poolPath -Name "recycling.periodicRestart.time" -Value ([TimeSpan]::Zero)
Set-ItemProperty -Path $poolPath -Name "autoStart"                      -Value $true
Write-Host "  - startMode                      = AlwaysRunning"
Write-Host "  - processModel.idleTimeout       = 00:00:00 (never idle)"
Write-Host "  - recycling.periodicRestart.time = 00:00:00 (no periodic recycle)"
Write-Host "  - autoStart                      = True"
Write-Host "[OK] App pool configured." -ForegroundColor Green

# 6. Configure the site/application to preload.
Write-Host ""
Write-Host "Enabling preloadEnabled on $SiteName$AppPath ..." -ForegroundColor Cyan
Set-ItemProperty -Path $appConfigPath -Name "preloadEnabled" -Value $true
Write-Host "[OK] preloadEnabled = True" -ForegroundColor Green

# 7. Recycle the app pool so the new settings take effect immediately.
Write-Host ""
Write-Host "Recycling application pool to apply settings ..." -ForegroundColor Cyan
Restart-WebAppPool -Name $AppPoolName
Write-Host "[OK] App pool recycled. IIS will now warm up the URLs declared in web.config <applicationInitialization>." -ForegroundColor Green

Write-Host ""
Write-Host "Done. Reminder:" -ForegroundColor Cyan
Write-Host "  * web.config already contains <applicationInitialization> with /Login/Login.aspx as the warm-up URL."
Write-Host "  * Add more warm-up URLs in web.config if you want additional pages pre-compiled at startup."
Write-Host "  * The first request to the app after any deploy/recycle will now be served from an already-warm worker process."
