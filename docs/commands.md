# Commands
## Menambah ASP.NET Core Identity
```
dotnet add Day1WebApi package Mirosoft.AspNetCore.Identity.EntityFrameworkCore

dotnet ef migrations add AddIdentity

dotnet ef database update
```
## Menambah Role Manajemen
### Menambah IdentityRole
### Membuat AccountController
### Membuat API Tambah Role
### Membuat API Assign Role
### Mengetes API dengan Otorisasi Admin
## Claim Based Authorization
### 
### Melihat Klaim User
### Melihat Daftar Migrasi
```
dotnet ef migrations list --project Day1WebApi
```
### Melakukan Roll Back Database
```
dotnet ef database update AddDeletedAtColumn --project Day1WebApi

dotnet ef migrations remove --project Day1WebApi
```
### Membuat BaseIdentityModel
### Mengubah Pegawai
### Melakukan Update Database
```
dotnet ef migrations add AddPegawaiIdentity --project Day1WebApiD

dotnet ef database update --project Day1WebApi
```
### Menambah Registrasi Akun Pegawai
### 

Logging

Default Logger
- Console
- Windows event logs
Kekurangan:
- Hanya support beberapa output logging (console, Windows event logs)

Serilog Logger:
- Console
- Text file
- Sqlite
- RDMS (SQL Server, Postgre, MySQL, MariaDB)
- NoSQL (Elastic, MongoDb)

Serilog.AspNetCore
Serilog.Sinks.File