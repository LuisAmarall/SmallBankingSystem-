# Small Banking System API

![.NET](https://img.shields.io/badge/.NET-8-purple)
![C#](https://img.shields.io/badge/C%23-Backend-blue)
![Architecture](https://img.shields.io/badge/Architecture-Clean-success)
![Status](https://img.shields.io/badge/Project-Study%20Project-orange)

A RESTful banking API built with **ASP.NET Core** designed using **layered architecture inspired by Clean Architecture**.

The system simulates core banking operations such as:

* Customer creation
* Account management
* Money transfers between accounts

This project was developed as a **backend architecture study project** focusing on separation of concerns and maintainable design.

---

# Architecture Overview

```mermaid
flowchart LR

API[API Layer]
APP[Application Layer]
DOMAIN[Domain Layer]
INFRA[Infrastructure Layer]
DB[(Database)]

API --> APP
APP --> DOMAIN
APP --> INFRA
INFRA --> DB
```

The architecture separates responsibilities across different layers to maintain a clean and scalable structure.

---

# Solution Structure

```text
SmallBankingSystem
│
├── SmallBankingSystem.API
│   ├── Controllers
│   │   ├── Customers
│   │   └── Transfers
│   │
│   ├── Middleware
│   ├── appsettings.json
│   └── Program.cs
│
├── SmallBankingSystem.Application
│   ├── Contracts
│   │   ├── Requests
│   │   │   ├── Account
│   │   │   ├── Customer
│   │   │   └── Transfer
│   │   │
│   │   └── Responses
│   │       ├── Account
│   │       ├── Customer
│   │       └── Transfer
│   │
│   ├── DependencyInjection
│   │
│   ├── Interfaces
│   │   ├── Repositories
│   │   └── Services
│   │
│   ├── Mappings
│   │   ├── AccountMappings
│   │   ├── CustomerMappings
│   │   └── TransferMappings
│   │
│   ├── Services
│   │
│   └── Validators
│       ├── CustomerValidators
│       └── TransferValidators
│
├── SmallBankingSystem.Domain
│   └── Models
│       ├── Entities
│       └── VOs
│
├── SmallBankingSystem.Infrastructure
│   ├── DependencyInjection
│   ├── Persistence
│   │   ├── Configuration
│   │   ├── DbContexts
│   │   └── Migrations
│   │
│   └── Repositories
│
└── SmallBankingSystem.Tests
```

---

# Layer Responsibilities

## API Layer

Responsible for handling HTTP requests and responses.

Contains:

* Controllers
* Middleware
* Application startup configuration

---

## Application Layer

Contains the application's business logic.

Responsibilities:

* Application Services
* DTOs (Requests and Responses)
* Validators
* Mappings
* Interfaces for services and repositories

---

## Domain Layer

Represents the **core business model**.

Contains:

* Entities
* Value Objects

This layer has **no dependencies on external frameworks**.

---

## Infrastructure Layer

Handles external concerns such as persistence and database access.

Contains:

* Entity Framework DbContext
* Database configuration
* Repository implementations
* Database migrations

---

## Tests

Contains automated tests for validating application behavior.

---

# Request Flow

```mermaid
sequenceDiagram

Client->>API: HTTP Request
API->>Service: Call Application Service
Service->>Validator: Validate Request
Service->>Repository: Access Data
Repository->>Database: Query / Save
Database-->>Repository: Data
Repository-->>Service: Result
Service-->>API: Response DTO
API-->>Client: HTTP Response
```

---

# Transfer Flow

```mermaid
flowchart TD

A[Client Request] --> B[TransfersController]
B --> C[TransferService]

C --> D{Validate Transfer}

D -->|Invalid| E[Return Error]
D -->|Valid| F[Get Origin Account]
F --> G[Get Target Account]

G --> H{Enough Balance?}

H -->|No| I[Return Insufficient Balance]
H -->|Yes| J[Debit Origin Account]
J --> K[Credit Target Account]

K --> L[Save Transfer]
L --> M[Return TransferResponse]
```

---

# API Endpoints

## Customers

Create customer

```
POST /api/customers
```

Example request:

```json
{
  "name": "John Doe",
  "email": "john@email.com"
}
```

---

Get customer by id

```
GET /api/customers/{id}
```

---

## Transfers

Create transfer

```
POST /api/transfers
```

Example request:

```json
{
  "originAccountId": "GUID",
  "targetAccountId": "GUID",
  "amount": 100
}
```

---

Get transfer by id

```
GET /api/transfers/{id}
```

---

# Error Handling

The API implements **global exception handling** using a custom middleware.

Errors follow the **ProblemDetails standard (RFC 7807)**.

Example error response:

```json
{
  "type": "https://httpstatuses.com/400",
  "title": "Invalid value",
  "status": 400,
  "detail": "Amount must be greater than zero",
  "instance": "/api/transfers"
}
```

---

# Technologies

* ASP.NET Core
* C#
* Entity Framework Core
* Swagger (OpenAPI)
* REST API

---

# Running the Project

Clone the repository:

```
git clone https://github.com/your-username/smallbankingsystem
```

Navigate to the project:

```
cd SmallBankingSystem
```

Run the application:

```
dotnet run
```

Swagger documentation will be available at:

```
https://localhost:{port}/swagger
```

---

# Future Improvements

* Add unit tests
* Add integration tests
* Implement authentication
* Improve validation layer
* Add transaction support

---

# Author
Luis Amaral
https://www.linkedin.com/in/luisamarall/

Backend architecture study project built with **ASP.NET Core**.
