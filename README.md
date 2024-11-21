# E-commerce Application

A .NET-based e-commerce application implementing a clean architecture pattern with API, Application, Infrastructure, and Domain layers.

## Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022, Visual Studio Code or preferenced C# supported IDE
- Git

## Dependencies

The application uses the following main packages:

### API Project
- Hangfire (v1.8.15) - For background job processing
- Hangfire.EntityFrameworkCore (v0.6.0) - EF Core integration for Hangfire
- Microsoft.EntityFrameworkCore (v9.0.0) - ORM framework
- Microsoft.EntityFrameworkCore.InMemory (v9.0.0) - In-memory database provider
- Swashbuckle.AspNetCore (v6.4.0) - API documentation and Swagger UI

### Infrastructure Project
- Microsoft.EntityFrameworkCore (v9.0.0)
- Microsoft.EntityFrameworkCore.InMemory (v9.0.0)

## Project Structure

The solution follows a clean architecture pattern with the following projects:
- Ecommerce.API - Web API and application entry point
- Ecommerce.Application - Application business logic and services
- Ecommerce.Infrastructure - Data access and external services implementation
- Ecommerce.Domain - Core business entities and logic

## Setup Instructions

1. Clone the repository
```bash
git clone https://github.com/renan-hath/ecommerce.git
cd ecommerce
```
2. Restore NuGet packages
```bash
dotnet restore
```
3. Build the solution
```bash
dotnet build
```
4. Run the application
```bash
cd src/Ecommerce.API
dotnet run
```
The application will start and be available at:

API: https://localhost:7001 (or similar port)
Swagger UI: https://localhost:7001/swagger
## Features
The application includes the following services:

- Customer Service
- Product Service
- Reservation Service
- Job Scheduling (using Hangfire)
## Development
The application uses:

- In-memory database for development
- Swagger for API documentation
- Hangfire for background job processing
- Dependency injection for service management
## Configuration
The application uses two configuration files:
- appsettings.json - Main configuration file
- appsettings.Development.json - Development-specific settings
Logging levels can be configured in these files according to your needs.

## Notes
- The application uses an in-memory database by default, which means data will be lost when the application is restarted
- Hangfire dashboard is available for monitoring background jobs
- API documentation is available through Swagger UI when running in development mode
