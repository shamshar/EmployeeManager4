Getting Started

Welcome to EmployeeManager4, a Blazor .NET 8 Employee Management System built with a clean architecture following SOLID principles.

Before running this project, you need to first set up the database using the original project.

Step 1 — Clone and Run EmployeeManager3

Clone the original project repository:
EmployeeManager3

git clone https://github.com/shamshar/EmployeeManager3.git


Open the solution in Visual Studio.

Open the Package Manager Console and run:

Update-Database


This will apply all migrations and create the local database.

Step 2 — Configure EmployeeManager4

Clone or open EmployeeManager4.

In appsettings.json, make sure the connection string points to the same database created in Step 1:

"ConnectionStrings": {
    "EmployeeManagerDbContext": "YourConnectionStringHere"
}


No need to run migrations again — EmployeeManager4 will connect to the existing database.

Step 3 — Run EmployeeManager4

Launch the application.

You can now perform all CRUD operations for employees and departments.

The UI interacts with the database only through services and DTOs, keeping the system clean, maintainable, and following SOLID principles:

SOLID Highlights

Single Responsibility: Each class and service has a clear, single purpose

Open/Closed: Add features without modifying existing code

Liskov Substitution & Interface Segregation: Services are defined via interfaces for flexibility and testability

Dependency Inversion: Components depend on abstractions, not concrete implementations

Features

Complete CRUD operations for employees and departments

Modern Blazor UI for a responsive experience

Local database support (SQL Server/SQLite)

Clean architecture following best practices



Feel free to reach out if you have any questions or need further assistance.

Thank you,
Shamshar Ali

shamsharali1@gmail.com

ShamsharWiredBrainCoffee

EmployeeManager4 - Employee Management System
A Blazor .NET 8 web application for managing employee records with a clean architecture, modern UI, and full CRUD functionality.