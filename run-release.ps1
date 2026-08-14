$env:ASPNETCORE_ENVIRONMENT="Staging"
$env:DisableGlobalAuthorize="true"
dotnet ./publish/Day1WebApi.dll
