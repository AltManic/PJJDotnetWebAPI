# Command untuk Menambah Identity
dotnet add Day1WebApi package Mirosoft.AspNetCore.Identity.EntityFrameworkCore
dotnet ef migrations add AddIdentity
dotnet ef database update
