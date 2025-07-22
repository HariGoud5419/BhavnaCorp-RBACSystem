# BhavnaCorp RBAC System

A Role-Based Access Control (RBAC) system developed using .NET 8 Web API and Angular 17+, backed by MySQL, showcasing modern software design principles like JWT Authentication, Unit of Work, Repository Pattern, Multi-layer Architecture, and Role-based Route Guards.

## Features

- Admin / Editor / Viewer roles
- JWT-based authentication
- Role-based API protection
- Clean architecture with separate layers
- Code-first EF Core migrations
- Multi-project .NET solution

## Tech Stack

- Backend: .NET 8 Web API, Entity Framework Core 8 (Pomelo MySQL)

- Frontend: Angular 17+ (Standalone Components, Typed Forms)

- Database: MySQL 8+

- Authentication: JWT Token (Bearer)

- Architecture: Clean Layered Architecture (Core, Infrastructure, API)

- Design Patterns: Repository, Unit of Work, DI, DTOs

## Getting Started

1. Clone this repo
2. Update the MySQL connection string in `appsettings.json`
3. Run `dotnet ef migrations add InitialCreate`
4. Run `dotnet ef database update`
5. Start the API project

## Features Overview

- Authentication & Authorization

- JWT Token-based authentication

- Role-based access control using Claims

- Secure API endpoints with [Authorize] & ClaimsPrincipal

## Roles Implemented

- Role

- Permissions

- Admin

- Full control. Manage users and roles.

- Editor

- Create and edit content only.

- Viewer

- View-only access.

## Angular Frontend

Login Form with typed reactive forms

Role-based UI rendering (Admin, Editor, Viewer dashboards)

Angular route guards with token parsing

Logout functionality

## Code Architecture

- Core: Entities, DTOs, Interfaces, Enums, Config

- Infrastructure: EF DbContext, Repositories, Services

- API: Controllers, Middleware, Seeding

- How To Run Locally

## Prerequisites

.NET 8 SDK

Node.js + Angular CLI

MySQL 8+

## Backend Setup

# Restore dependencies

cd RBACSystem.API

dotnet restore

# Run migrations (first-time only)

dotnet ef database update

# Run backend

dotnet run

- Default backend URL: https://localhost:5199

## -Frontend Setup

- cd Front-End
- npm install
- ng serve

- Default frontend URL: http://localhost:4200

## Seeded Users

Username

Email

Password

Role

admin

admin@rbac.com

Admin@123

Admin

editor

editor@rbac.com

Editor@123

Editor

viewer

viewer@rbac.com

Viewer@123

Viewer

## Key Implementation Highlights

- User Registration & Login

- Hashed passwords

- Role mapping via UserRole entity

- Secure token generation using JwtSecurityTokenHandler

## Claims-based Authorization

- ClaimTypes.Role used in JWT

- Extracted in Angular from token for guards

- [Authorize(Roles = "Admin")] on controller actions

## Middleware Ready

Centralized role policy enforcement

Future support for custom claims or permission matrix

## API Security

[ProducesResponseType] annotations

Global exception handling middleware (ready to be added)

Role-restricted endpoints for each dashboard role

## Project Structure

BhavnaCorp-RBACSystem/
|
|├── RBACSystem.Core/ # Core business models, DTOs, Interfaces
|├── RBACSystem.Infrastructure/ # EF Core, Repos, Services, DI Configs
|├── RBACSystem.API/ # API controllers, auth, program.cs
|└── Front-End/ # Angular 17+ SPA

## Security Best Practices Implemented

JWT token expiration and issuer/audience check

Roles added as role claim array

Angular guards parse token and allow secure routing

Logout clears token from local storage

## Assignment Objectives Covered

Requirement

## Status

- Implement JWT authentication mechanism
- Define role-based access policies using middleware
- Protect API endpoints with role-based authorization
- Use claims or role attributes to secure endpoints
- Create login UI + show/hide UI based on roles
- Implement Angular route guards for role-based access

## Future Enhancements

Secure token in HttpOnly cookies

Permission-based access matrix

Role management UI for Admins

Global Exception Middleware

## Contributors

Hari Goud (Developer)

## Final Notes

This project is designed for interview showcase, with emphasis on:

- Clean architecture

- Best practices

- Commented, readable code

- Realistic RBAC flows

## please find the repository code at this given Link

- Repo: https://github.com/HariGoud5419/BhavnaCorp-RBACSystem
