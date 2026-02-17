# Stage 1: Build Angular Client
FROM node:22 AS client-build
WORKDIR /app
COPY CaffeineCrafter.Client/package*.json ./
RUN npm install
COPY CaffeineCrafter.Client/ ./
# Build the Angular app to dist/client
RUN npm run build -- --output-path=dist/client

# Stage 2: Build .NET API
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS api-build
WORKDIR /src
COPY CaffeineCrafter.API/CaffeineCrafter.API.csproj CaffeineCrafter.API/
RUN dotnet restore CaffeineCrafter.API/CaffeineCrafter.API.csproj
COPY CaffeineCrafter.API/ CaffeineCrafter.API/
WORKDIR /src/CaffeineCrafter.API
RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish

# Stage 3: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=api-build /app/publish .
# Copy Angular build output to wwwroot
# Note: Angular 17+ with application builder outputs to dist/client/browser
COPY --from=client-build /app/dist/client/browser ./wwwroot

# Expose port 8080 (Render default)
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "CaffeineCrafter.API.dll"]
