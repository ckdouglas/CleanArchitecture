**Ultimate Clean Architecture Folder Structure**

## Overview

This document provides a comprehensive guide to structuring a .NET application using the Clean Architecture pattern. The folder structure is designed for scalability, maintainability, and flexibility. Each layer follows domain-driven design (DDD) principles and includes necessary components for a robust enterprise application.

---

## **Diagrams**

### **1. Ultimate Clean Architecture Folder Structure**

```
📦 CleanArchitectureApp
 ┣ 📂 src
 ┃ ┣ 📂 CleanArchitecture.API
 ┃ ┣ 📂 CleanArchitecture.Application
 ┃ ┣ 📂 CleanArchitecture.Domain
 ┃ ┣ 📂 CleanArchitecture.Infrastructure
 ┃ ┣ 📂 CleanArchitecture.Shared
 ┃ ┣ 📂 CleanArchitecture.Tests
 ┣ 📂 build
 ┣ 📂 scripts
 ┣ 📂 deployments
 ┣ 📜 .gitignore
 ┣ 📜 docker-compose.yml
 ┣ 📜 README.md
 ┗ 📜 CleanArchitectureApp.sln
```

### **2. Ultimate Clean Architecture Folder Structure (Expanded with File Examples)**

```
📦 CleanArchitectureApp
 ┣ 📂 src
 ┃ ┣ 📂 CleanArchitecture.API                  # API Layer (Presentation)
 ┃ ┃ ┣ 📂 Controllers                          # API Endpoints
 ┃ ┃ ┃ ┣ 📜 UserController.cs
 ┃ ┃ ┃ ┣ 📜 OrderController.cs
 ┃ ┃ ┣ 📂 Middleware                           # Logging, Exception Handling
 ┃ ┃ ┃ ┣ 📜 ExceptionHandlingMiddleware.cs
 ┃ ┃ ┣ 📂 Filters                              # Custom Action Filters
 ┃ ┃ ┃ ┣ 📜 ValidationFilter.cs
 ┃ ┃ ┣ 📂 Extensions                           # API Extensions (DI, Swagger)
 ┃ ┃ ┃ ┣ 📜 ServiceCollectionExtensions.cs
 ┃ ┃ ┣ 📂 Routes                               # Custom route handling
 ┃ ┃ ┣ 📂 Swagger                              # OpenAPI Documentation
 ┃ ┃ ┣ 📂 GraphQL                              # GraphQL Schema, Queries, Mutations
 ┃ ┃ ┣ 📜 Program.cs                           # App entry point & DI setup
 ┃ ┃ ┣ 📜 appsettings.json                     # Configuration settings
 ┃ ┣ 📂 CleanArchitecture.Application          # Business Logic (Use Cases)
 ┃ ┃ ┣ 📂 Interfaces                           # Repository, Service Contracts
 ┃ ┃ ┃ ┣ 📜 IUserRepository.cs
 ┃ ┃ ┣ 📂 Services                             # Application Services (Use Cases)
 ┃ ┃ ┃ ┣ 📜 UserService.cs
 ┃ ┃ ┣ 📂 DTOs                                 # Data Transfer Objects
 ┃ ┃ ┃ ┣ 📜 UserDto.cs
 ┃ ┃ ┣ 📂 Requests                             # Request objects
 ┃ ┃ ┃ ┣ 📜 CreateUserRequest.cs
 ┃ ┃ ┣ 📂 Responses                            # Response objects
 ┃ ┃ ┃ ┣ 📜 UserResponse.cs
 ┃ ┃ ┣ 📂 Validators                           # Request validation rules
 ┃ ┃ ┃ ┣ 📜 UserValidator.cs
 ┃ ┃ ┣ 📂 Features                             # CQRS Handlers
 ┃ ┃ ┣ 📂 Events                               # Application Events (Mediator)
 ┃ ┃ ┣ 📂 BackgroundJobs                       # Hangfire, Quartz.NET
 ┃ ┃ ┣ 📂 Notifications                        # SignalR, WebSockets
 ┃ ┣ 📂 CleanArchitecture.Domain               # Core Business Entities (Domain Layer)
 ┃ ┃ ┣ 📂 Entities                             # Domain models
 ┃ ┃ ┃ ┣ 📜 User.cs
 ┃ ┃ ┣ 📂 Enums                                # Enum definitions
 ┃ ┃ ┣ 📂 Events                               # Domain Events (DDD)
 ┃ ┣ 📂 CleanArchitecture.Infrastructure       # Data & External Services
 ┃ ┃ ┣ 📂 Persistence                          # Database Implementations
 ┃ ┃ ┃ ┣ 📂 SQL                                # EF Core for PostgreSQL & SQL Server
 ┃ ┃ ┃ ┃ ┣ 📜 AppDbContext.cs
 ┃ ┃ ┃ ┣ 📂 MongoDB                            # MongoDB Repository Implementation
 ┃ ┃ ┣ 📂 Repositories                         # Repository Implementations
 ┃ ┃ ┃ ┣ 📜 UserRepository.cs
 ┃ ┃ ┣ 📂 Logging                              # Serilog, NLog
 ┃ ┃ ┣ 📂 Caching                              # Redis, Memory Cache
 ┃ ┣ 📂 CleanArchitecture.Shared               # Common Utilities & Extensions
 ┃ ┃ ┣ 📂 Helpers                              # Helper methods
 ┃ ┃ ┃ ┣ 📜 DateHelper.cs
 ┃ ┃ ┣ 📂 Extensions                           # Extension methods
 ┃ ┣ 📂 CleanArchitecture.Tests                # Unit & Integration Tests
 ┃ ┃ ┣ 📂 API                                  # API tests
 ┃ ┃ ┣ 📂 Application                          # Business Logic tests
 ┃ ┃ ┣ 📂 Infrastructure                       # Database & External Service tests
 ┣ 📂 build                                    # CI/CD & Docker files
 ┣ 📂 scripts                                  # Database migrations, automation scripts
 ┣ 📂 deployments                              # Kubernetes, Terraform
 ┣ 📜 .gitignore
 ┣ 📜 docker-compose.yml                       # Docker setup for PostgreSQL, SQL Server, and MongoDB
 ┣ 📜 README.md                                # Project documentation
 ┗ 📜 CleanArchitectureApp.sln                 # Solution file
```

### **3. Layered Dependency Flow in Clean Architecture**

```
📦 Presentation (API)
 ┣ 📜 Depends on Application Layer
 ┗ 📜 Calls Use Cases & Business Logic

📦 Application (Use Cases)
 ┣ 📜 Depends on Domain Layer
 ┣ 📜 Calls Repository & Service Interfaces
 ┗ 📜 Implements Business Rules

📦 Domain (Core Business Logic)
 ┣ 📜 Independent of all other layers
 ┣ 📜 Contains Entities, Enums, and Events
 ┗ 📜 Defines Business Rules

📦 Infrastructure (Persistence & Services)
 ┣ 📜 Implements Repository & External Integrations
 ┣ 📜 Provides Logging, Caching, and Messaging
 ┗ 📜 Depends on Application Layer Contracts
```

### **4. Commands to Add Projects to the Solution and References**

```sh
# Add projects to the solution
cd src
 dotnet new sln -n CleanArchitectureApp
 dotnet sln add CleanArchitecture.API/CleanArchitecture.API.csproj
 dotnet sln add CleanArchitecture.Application/CleanArchitecture.Application.csproj
 dotnet sln add CleanArchitecture.Domain/CleanArchitecture.Domain.csproj
 dotnet sln add CleanArchitecture.Infrastructure/CleanArchitecture.Infrastructure.csproj
 dotnet sln add CleanArchitecture.Shared/CleanArchitecture.Shared.csproj
 dotnet sln add CleanArchitecture.Tests/CleanArchitecture.Tests.csproj

# Add project references
cd CleanArchitecture.API
 dotnet add reference ../CleanArchitecture.Application/CleanArchitecture.Application.csproj
 dotnet add reference ../CleanArchitecture.Infrastructure/CleanArchitecture.Infrastructure.csproj

cd ../CleanArchitecture.Application
 dotnet add reference ../CleanArchitecture.Domain/CleanArchitecture.Domain.csproj

cd ../CleanArchitecture.Infrastructure
 dotnet add reference ../CleanArchitecture.Domain/CleanArchitecture.Domain.csproj
```

---

## **Conclusion**

This **Clean Architecture folder structure** is designed for **scalability, maintainability, and separation of concerns**. It supports **CQRS, DDD, Microservices**, and **enterprise-grade deployments** using **Kubernetes, Docker, and Terraform**.

🚀 **This is the ultimate setup for large-scale .NET applications!**

