Remove-Item -Recurse -Force publish
dotnet build -c Release Day1WebApi
dotnet publish -c Release -o publish