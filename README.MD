# CIDM 4390

A few examples of some software engineering concepts.

## Web API

1. From the root solution folder: `dotnet new globaljson --sdk-version 3.1.404`
2. `mkdir webapi` and then `cd webapi`
3. from within this folder: `dotnet new webapi --no-https`
4. also in webapi: `dotnet add package Microsoft.EntityFrameworkCore --version 3.1.10`
5. also in webapi (necessary for the scaffolder to work): `dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 3.1.10`
5. also in webapi: `dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 3.1.10`
6. also in webapi: `dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 3.1.10`

### WebApi Controller Scaffolding

Scaffolding is a simple way to generate a controller for API Endpoints.

We have a bunch of adding to do:

```
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 3.1.4
dotnet add package Microsoft.EntityFrameworkCore.Design --version 3.1.10
dotnet tool install --global dotnet-aspnet-codegenerator --version 3.1.4
dotnet aspnet-codegenerator controller -name VatsimMETARController -async -api -m METARStation -dc WebApiDbContext -outDir Controllers
```

We'll test against this api.



## Architecture

SOLID principles

* [unit of work](https://pradeeploganathan.com/architecture/repository-and-unit-of-work-pattern-asp-net-core-3-1/)
* [my demo from spring 2020 that implements unit of work](https://github.com/ahuimanu/wizarddemo)
* [older asp.net mvc documentation regarding repository and unit of work](https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application)

## Testing

XUnit for unit testing.

Projects:
* webapi
* tests

