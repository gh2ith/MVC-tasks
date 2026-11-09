# University Cafeteria Management System

Task 7 uses ASP.NET Core MVC, Entity Framework Core and SQL Server.

## Run

Open UniversityCafeteria.sln in Visual Studio. The SQL Server connection is in appsettings.json.

```powershell
dotnet restore
dotnet ef database update
dotnet run
```

## Tables and relationships

- Category has Id, Name and Description. One category has many products.
- Supplier has Id, Name, Phone, Email and address. One supplier supplies many products.
- Product has Id, Name, Description, Price, Quantity, CategoryId and SupplierId.
- Employee has Id, FullName, Phone, Email, Position, Salary and HireDate. One employee handles many orders.
- Order has Id, CustomerName, OrderDate, TotalPrice, Status and EmployeeId.

## Pages and actions

Each section has Index, Create, Edit and Details views. Create and Edit have GET and POST actions.
Index lists records with Add New, Edit and Details links and a Delete button that sends a POST request.
Category and Supplier show Products Count. Employee shows Orders Count.
Product displays Low Stock when Quantity is less than 5.
The shared navigation links to all five sections.

Controllers use Find, Add, Update, Remove, SaveChanges and RedirectToAction.
Views use plain forms, named inputs, @Model values, Url.Action links, and HTML Helper dropdowns.
Edit forms include a hidden Id. Dropdowns select the category, supplier or employee.
TotalPrice is entered directly because the assignment does not specify order items or a calculation.
Existing migrations and connection settings are preserved.
