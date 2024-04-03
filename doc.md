To initiate the project: dotnet new webapi -o api
To keep tabs of changes: dotnet watch run
Extension: C# Dev Kit, .Net Extension Pack, .Net install Tool, NuGet Gallary, Prettier, C# Extensions

// Short-cuts
prop + tab to create a property
ctor + tab to create a constructor

// General info
DotNet ORM (Object Relational Mapper): Entity Framework

// Installing Entity Framework
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.Design

NewtonSoft.Json and Microsoft.AspNetCore.Mvc.NewtonsoftJson for including other Models

// JWT
Microsoft.Extensions.Identity.Core
Microsoft.AspNetCore.Identity.EntityFrameworkCore
Microsoft.AspNetCore.Authentication.JwtBearer
// After setup, run dotnet ef migrations add Identity. Then dotnet ef database update

// Migrating roles
dotnet ef migrations add SeedRole
dotnet ef database update
Note: They are installed from NuGet Gallery. Open NuGet Gallery. Type in sqlserver and install entity framework

// Migration
dotnet ef migrations add init
dotnet ef database update
