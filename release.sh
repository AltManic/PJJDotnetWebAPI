#!/usr/bin/env sh
dotnet build -c Release Day1WebApi
dotnet publish -c Release -o release