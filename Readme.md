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

📦 Shared (Common Utilities & Extensions)
 ┣ 📜 Contains global utilities, helpers, DTOs, constants
 ┣ 📜 Referenced by Api, Application & Infrastructure Layers
 ┗ 📜 Should NOT include business logic
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

### **5. Script**

```
# Exit on error
$ErrorActionPreference = "Stop"

# Check if dotnet CLI is installed
if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) {
    Write-Host "❌ Error: .NET SDK is not installed. Please install it and try again." -ForegroundColor Red
    exit 1
}

# Define solution name
$SolutionName = "CleanArchitectureApp"
$BasePath = Join-Path -Path (Get-Location) -ChildPath $SolutionName

# Create the solution directory if it doesn't exist
if (-not (Test-Path $BasePath)) {
    New-Item -ItemType Directory -Path $BasePath | Out-Null
}

# Navigate to solution directory
Set-Location -Path $BasePath

# Create solution file
dotnet new sln -n $SolutionName

# Define projects
$projects = @{
    "CleanArchitecture.API"          = "webapi"
    "CleanArchitecture.Application"  = "classlib"
    "CleanArchitecture.Domain"       = "classlib"
    "CleanArchitecture.Infrastructure" = "classlib"
    "CleanArchitecture.Shared"       = "classlib"
    "CleanArchitecture.Tests"        = "xunit"
}

# Create projects and add to solution
foreach ($proj in $projects.Keys) {
    $ProjectPath = Join-Path -Path $BasePath -ChildPath "src\$proj"
    
    if (-not (Test-Path $ProjectPath)) {
        New-Item -ItemType Directory -Path $ProjectPath | Out-Null
    }

    dotnet new $projects[$proj] -n $proj -o $ProjectPath
    dotnet sln "$BasePath\$SolutionName.sln" add "$ProjectPath\$proj.csproj"
}

# Add references based on Clean Architecture
$references = @(
    @{ From = "CleanArchitecture.API"; To = "CleanArchitecture.Application" }
    @{ From = "CleanArchitecture.Application"; To = "CleanArchitecture.Domain" }
    @{ From = "CleanArchitecture.Infrastructure"; To = "CleanArchitecture.Application" }
    @{ From = "CleanArchitecture.Infrastructure"; To = "CleanArchitecture.Domain" }
    @{ From = "CleanArchitecture.API"; To = "CleanArchitecture.Infrastructure" }
    @{ From = "CleanArchitecture.Shared"; To = "CleanArchitecture.Application" }
    @{ From = "CleanArchitecture.Shared"; To = "CleanArchitecture.Infrastructure" }
)

foreach ($ref in $references) {
    dotnet add "src/$($ref.From)/$($ref.From).csproj" reference "src/$($ref.To)/$($ref.To).csproj"
}

# Define folder structure
$folders = @(
    # API
    "src/CleanArchitecture.API/Controllers"
    "src/CleanArchitecture.API/Middleware"
    "src/CleanArchitecture.API/Filters"
    "src/CleanArchitecture.API/Extensions"
    "src/CleanArchitecture.API/Routes"
    "src/CleanArchitecture.API/Swagger"
    "src/CleanArchitecture.API/GraphQL"

    # Application
    "src/CleanArchitecture.Application/Interfaces"
    "src/CleanArchitecture.Application/Services"
    "src/CleanArchitecture.Application/DTOs"
    "src/CleanArchitecture.Application/Requests"
    "src/CleanArchitecture.Application/Responses"
    "src/CleanArchitecture.Application/Validators"
    "src/CleanArchitecture.Application/Features"
    "src/CleanArchitecture.Application/Events"
    "src/CleanArchitecture.Application/BackgroundJobs"
    "src/CleanArchitecture.Application/Notifications"

    # Domain
    "src/CleanArchitecture.Domain/Entities"
    "src/CleanArchitecture.Domain/Enums"
    "src/CleanArchitecture.Domain/Events"

    # Infrastructure
    "src/CleanArchitecture.Infrastructure/Persistence/SQL"
    "src/CleanArchitecture.Infrastructure/Persistence/MongoDB"
    "src/CleanArchitecture.Infrastructure/Repositories"
    "src/CleanArchitecture.Infrastructure/Logging"
    "src/CleanArchitecture.Infrastructure/Caching"

    # Shared
    "src/CleanArchitecture.Shared/Helpers"
    "src/CleanArchitecture.Shared/Extensions"

    # Tests
    "src/CleanArchitecture.Tests/API"
    "src/CleanArchitecture.Tests/Application"
    "src/CleanArchitecture.Tests/Infrastructure"

    # Build, Scripts, Deployment
    "build"
    "scripts"
    "deployments/k8s"
    "deployments/terraform"
)

# Create directories
foreach ($folder in $folders) {
    $FolderPath = Join-Path -Path $BasePath -ChildPath $folder
    if (-not (Test-Path $FolderPath)) {
        New-Item -ItemType Directory -Path $FolderPath | Out-Null
    }
}

# Define essential files
$files = @(
    # API
    "src/CleanArchitecture.API/Controllers/UserController.cs"
    "src/CleanArchitecture.API/Controllers/OrderController.cs"
    "src/CleanArchitecture.API/Middleware/ExceptionHandlingMiddleware.cs"
    "src/CleanArchitecture.API/Filters/ValidationFilter.cs"
    "src/CleanArchitecture.API/Extensions/ServiceCollectionExtensions.cs"
    "src/CleanArchitecture.API/Program.cs"
    "src/CleanArchitecture.API/appsettings.json"

    # Application
    "src/CleanArchitecture.Application/Interfaces/IUserRepository.cs"
    "src/CleanArchitecture.Application/Services/UserService.cs"
    "src/CleanArchitecture.Application/DTOs/UserDto.cs"
    "src/CleanArchitecture.Application/Requests/CreateUserRequest.cs"
    "src/CleanArchitecture.Application/Responses/UserResponse.cs"
    "src/CleanArchitecture.Application/Validators/UserValidator.cs"

    # Domain
    "src/CleanArchitecture.Domain/Entities/User.cs"
    "src/CleanArchitecture.Domain/Enums/UserRole.cs"

    # Infrastructure
    "src/CleanArchitecture.Infrastructure/Persistence/SQL/AppDbContext.cs"
    "src/CleanArchitecture.Infrastructure/Repositories/UserRepository.cs"

    # Shared
    "src/CleanArchitecture.Shared/Helpers/DateHelper.cs"
    "src/CleanArchitecture.Shared/Extensions/ServiceCollectionExtensions.cs"

    # Tests
    "src/CleanArchitecture.Tests/API/UserControllerTests.cs"
    "src/CleanArchitecture.Tests/Application/UserServiceTests.cs"
    "src/CleanArchitecture.Tests/Infrastructure/UserRepositoryTests.cs"

    # Docker & Deployment
    "docker-compose.yml"
    "README.md"
)

# Create empty files
foreach ($file in $files) {
    $FilePath = Join-Path -Path $BasePath -ChildPath $file
    if (-not (Test-Path $FilePath)) {
        New-Item -ItemType File -Path $FilePath | Out-Null
    }
}

Write-Host "✅ Clean Architecture Solution Scaffolded Successfully on Windows!" -ForegroundColor Green

```



## **Conclusion**

This **Clean Architecture folder structure** is designed for **scalability, maintainability, and separation of concerns**. It supports **CQRS, DDD, Microservices**, and **enterprise-grade deployments** using **Kubernetes, Docker, and Terraform**.

🚀 **This is the ultimate setup for large-scale .NET applications!**

