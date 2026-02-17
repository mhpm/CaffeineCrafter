@echo off
echo Starting CaffeineCrafter API...
start "CaffeineCrafter API" dotnet run --project CaffeineCrafter.API/CaffeineCrafter.API.csproj

echo Starting CaffeineCrafter Client...
cd CaffeineCrafter.Client
start "CaffeineCrafter Client" npm start
cd ..
