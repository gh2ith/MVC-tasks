# University Cafeteria Management System

Task 6 solution using ASP.NET Core MVC, Entity Framework Core and SQL Server.

## Tables and relationships

- Categories: Id, Name, Description.
- Suppliers: Id, Name, Phone, Email.
- Products: Id, Name, Price, Quantity, CategoryId, SupplierId.
- One category has many products. One supplier supplies many products.
- Products.CategoryId and Products.SupplierId are required foreign keys.

## Run

Requirements: .NET 10 SDK and SQL Server LocalDB (usually installed with Visual Studio).

Open UniversityCafeteria.sln in Visual Studio, or open PowerShell in this folder:

```powershell
dotnet tool restore
dotnet restore
dotnet ef database update
dotnet run --urls http://localhost:5186
```

Open http://localhost:5186. Add a category, then a supplier, then a product.
The first two records populate the category and supplier dropdowns.

The connection string is in appsettings.json. For another SQL Server instance,
change Server and Database before running the database update command.
No database password is stored in this project.

## How it works

Each controller has Index, Create GET and Create POST actions. GET shows the form;
POST validates and saves using ApplicationDbContext, then redirects to Index.
Invalid forms redisplay the entered values and validation errors.
Product Index loads the related category and supplier with Include.
Views use HTML Helpers for forms, labels, inputs, dropdowns, links and display.
Each POST validates an anti-forgery token. Create actions bind only editable fields.

Models define the tables. Data/ApplicationDbContext.cs exposes the three DbSets.
Migrations contains the EF-generated initial database migration.
Controllers handle requests; Views contains each controller's Index and Create pages.
No edit/delete, authentication or other optional features are included.

EF setup follows Microsoft's documentation:
https://learn.microsoft.com/en-us/ef/core/providers/sql-server/
https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying
