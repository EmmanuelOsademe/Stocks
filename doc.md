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
Note: They are installed from NuGet Gallery. Open NuGet Gallery. Type in sqlserver and install entity framework

// Migration
dotnet ef migrations add init
dotnet ef database update
