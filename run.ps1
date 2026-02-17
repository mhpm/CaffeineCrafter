Write-Host "Starting CaffeineCrafter API..."
Start-Process dotnet -ArgumentList "run --project CaffeineCrafter.API/CaffeineCrafter.API.csproj"

Write-Host "Starting CaffeineCrafter Client..."
Set-Location CaffeineCrafter.Client
Start-Process npm -ArgumentList "start"
Set-Location ..
