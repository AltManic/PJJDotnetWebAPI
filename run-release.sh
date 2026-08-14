#!/usr/bin/env sh
export ASPNETCORE_ENVIRONMENT=Staging
export DisableGlobalAuthorize=true
export Serilog__MinimumLevel=Information
dotnet ./publish/Day1WebApi.dll
