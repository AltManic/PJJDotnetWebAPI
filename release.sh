#!/usr/bin/env sh
rm -rf publish
dotnet build -c Release Day1WebApi
dotnet publish -c Release -o publish Day1WebApi
dotnet ef migrations bundle --self-contained -o ./publish/efbundle --project Day1WebApi --configuration Release