![CI](https://github.com/RajeshManicavasagam/cloud-order-management/actions/workflows/ci.yml/badge.svg)

# Cloud Order Management (.NET 8)

This repository demonstrates a **cloud-native order management backend**
designed with **Clean Architecture** and **domain-driven principles**.

The project focuses on **order lifecycle management**, state transitions,
and testable business logic, rather than UI or frontend concerns.

---

## 🧱 Architecture Overview

The system is structured as an independent **Order Service** following
Clean Architecture:

API → Application → Domain
↓
Infrastructure


- **Domain**: Order aggregate and state machine
- **Application**: Use cases and business orchestration
- **Infrastructure**: Persistence and technical concerns
- **API**: HTTP interface (REST)

---

## 📦 Order Service

### Responsibilities
- Create orders
- Enforce valid order state transitions
- Prevent invalid lifecycle changes
- Expose REST API for order creation

---

## 🔄 Order Lifecycle

An order follows a strict state machine:

Created → Paid → Fulfilled
↓
Cancelled
↓
Failed


### Rules enforced in the domain:
- Only `Created` orders can be paid
- Only `Paid` orders can be fulfilled
- Fulfilled orders cannot be cancelled or failed

These rules are enforced **inside the domain model**, not in controllers.

---

## 🛠️ Technology Stack

- .NET 8 (LTS)
- ASP.NET Core Web API
- Clean Architecture
- xUnit for unit testing
- GitHub Actions for CI
- In-memory persistence (replaceable)

---

## 🧪 Testing Strategy

Tests focus on:
- Domain rules (order state transitions)
- Application use cases (Create Order)

Framework and infrastructure concerns are intentionally excluded from tests.

---

## 🔁 CI Pipeline

The repository includes a GitHub Actions pipeline that:
- Restores dependencies
- Builds the Order Service
- Runs all unit tests

Defined in:
.github/workflows/ci.yml



---

## ▶️ Running Locally

```bash
dotnet run --project services/order-service/Order.API

Swagger UI will be available at:
http://localhost:{port}/swagger

Future Improvements

Event-driven processing (payment & fulfillment events)

Database-backed persistence (PostgreSQL / SQL Server)

Idempotent order creation

Docker Compose for local orchestration

Distributed tracing (OpenTelemetry)


---

### Reference it in README

Add this section under **Order Lifecycle**:

```md
![Order Lifecycle](docs/order-lifecycle.png)



