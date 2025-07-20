# BhavnaCorp RBAC System

A secure, scalable Role-Based Access Control system using .NET 8 Web API, Entity Framework Core, MySQL, and JWT Authentication.

## Features

- Admin / Editor / Viewer roles
- JWT-based authentication
- Role-based API protection
- Clean architecture with separate layers
- Code-first EF Core migrations
- Multi-project .NET solution

## Tech Stack

- .NET 8 Web API
- EF Core 8
- MySQL (Pomelo provider)
- Clean Architecture
- React or Angular (frontend coming soon)

## Getting Started

1. Clone this repo
2. Update the MySQL connection string in `appsettings.json`
3. Run `dotnet ef migrations add InitialCreate`
4. Run `dotnet ef database update`
5. Start the API project

---
