# IWS Operations API

A small ASP.NET Core Web API for managing waste-pickup requests across a multi-site hauling operation. Built as a focused learning project to practice .NET 10 + EF Core patterns commonly used in enterprise business applications.

## What it does

Exposes a REST API for operations teams to create, view, update, and cancel pickup requests for commercial, residential, recycling, and medical waste customers. Models a real-world operational workflow:

- Customer + pickup address
- Waste type (Commercial / Residential / Recycling / Medical)
- Requested service date
- Status (Pending → Scheduled → Completed / Cancelled)
- Assigned truck

## Tech stack

| Layer | Choice |
|---|---|
| Runtime | .NET 10 (LTS) |
| Framework | ASP.NET Core Web API (controller-based) |
| ORM | Entity Framework Core 10 |
| Database | SQLite (file-based, zero-setup; same EF patterns as SQL Server) |
| API docs | Swashbuckle / Swagger UI |
| Language | C# 14 |

The project mirrors patterns used in larger enterprise stacks (DI, async data access, DTOs separate from entities, controller-routed endpoints) so the same code is portable to SQL Server with a one-line provider swap.

## Running locally

Requirements: [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

```bash
git clone https://github.com/iabubakartahir/iws-operations-api.git
cd iws-operations-api
dotnet restore
dotnet run
```

Then open Swagger UI in your browser: