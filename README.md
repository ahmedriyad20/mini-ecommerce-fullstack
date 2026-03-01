# 🛒 Mini E-Commerce System
## 📋 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Architecture](#architecture)
- [Prerequisites](#prerequisites)
- [Installation & Setup](#installation--setup)
- [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)
- [Project Structure](#project-structure)
- [Business Rules](#business-rules)

## 🎯 Overview

This project is a simplified e-commerce system that demonstrates core backend and frontend development skills. It includes product management, order processing with automatic discount calculation, and stock validation.

## ✨ Features

### ✅ Completed User Stories

- **US-01: Create Product** - Add products with name, price validation (>0), and stock quantity (≥0)
- **US-02: List Products** - Display all products with **pagination support** ⭐
- **US-03: Create Order** - Process orders with real-time stock validation
- **US-04: Calculate Total** - Automatic discount application:
  - 2-4 items → 5% discount
  - 5+ items → 10% discount
- **US-05: Get Order Details** - View complete order information with breakdown

### 🎁 Bonus Features

- ✅ Pagination on product listing
- ✅ Clean Architecture with CQRS pattern
- ✅ FluentValidation for robust input validation
- ✅ Repository pattern with Unit of Work
- ✅ Responsive UI with Bootstrap 5

## 🛠️ Tech Stack

### Backend
- **Framework:** ASP.NET Core 10.0 Web API
- **ORM:** Entity Framework Core
- **Validation:** FluentValidation
- **Architecture:** Clean Architecture + CQRS
- **Database:** SQL Server (configurable)

### Frontend
- **Framework:** Blazor WebAssembly
- **UI Library:** Bootstrap 5
- **State Management:** Service-based architecture

## 🏗️ Architecture

The project follows **Clean Architecture** principles with clear separation of concerns:

## 📦 Prerequisites

Before running this application, ensure you have:

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) or later
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or SQL Server Express / LocalDB)
- [Visual Studio 2026](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- [Git](https://git-scm.com/)

## 🚀 Installation & Setup

### 1. Clone the Repository

### 2. Configure Database Connection

Update the connection string in `MiniECommerce.API/appsettings.json`:

**For SQL Server:**

### 3. Apply Database Migrations

Open a terminal in the `MiniECommerce.API` directory and run:

Or use Package Manager Console in Visual Studio:

### 4. Restore Dependencies

## ▶️ Running the Application

### Option 1: Visual Studio

1. Open `MiniECommerce.sln` in Visual Studio
2. Right-click on the solution → **Set Startup Projects**
3. Select **Multiple startup projects**
4. Set both `MiniECommerce.API` and `MiniECommerce.Blazor.WASM` to **Start**
5. Press `F5` or click **Run**

### 🌐 Access the Application

- **Blazor UI:** [https://localhost:7001](https://localhost:7001) (or check your console output)
- **API:** [https://localhost:7000](https://localhost:7000) (or check your console output)
- **Swagger:** [https://localhost:7000/swagger](https://localhost:7000/swagger)

## 📡 API Endpoints

### Products
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/products` | Get all products (paginated) |
| GET | `/api/products/{id}` | Get product by ID |
| POST | `/api/products` | Create new product |

### Orders
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/orders` | Get all orders (paginated) |
| GET | `/api/orders/{id}` | Get order details with discounts |
| POST | `/api/orders` | Create new order |

### Customers
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/customers` | Get all customers (paginated) |
| POST | `/api/customers` | Create new customer |

## 📂 Project Structure

## 📊 Business Rules

### Product Validation
- ✅ Name is required (max 200 characters)
- ✅ Price must be greater than 0
- ✅ Available quantity must be ≥ 0

### Order Processing
- ✅ Customer must be selected
- ✅ At least one item required
- ✅ Stock validation before order creation
- ✅ Automatic discount calculation:
  - **1 item:** No discount
  - **2-4 items:** 5% discount
  - **5+ items:** 10% discount

### Discount Calculation Example

## 🧪 Testing the Application

### Test Flow:

1. **Create Products**
   - Navigate to **Products** → **Add New Product**
   - Add at least 5 products with different prices

2. **Create a Customer**
   - Navigate to **Customers** → **Add New Customer**
   - Fill in customer details

3. **Create an Order**
   - Navigate to **Orders** → **Create New Order**
   - Select a customer
   - Add 2-4 items to see 5% discount
   - Add 5+ items to see 10% discount

4. **View Order Details**
   - Click **View Details** on any order
   - Verify discount calculation and final total

## 🎨 UI Features

- ✅ Responsive design (mobile-friendly)
- ✅ Bootstrap 5 styling
- ✅ Pagination controls
- ✅ Form validation with error messages
- ✅ Loading states
- ✅ Clean navigation

## 🔐 Security Notes

This is a **demo project** without authentication. In production, you should implement:
- JWT authentication
- Role-based authorization
- API rate limiting
- Input sanitization
- HTTPS enforcement

## 📝 License

This project is open-source and available under the [MIT License](LICENSE).

## 👨‍💻 Developer

**Ahmed Riyad**
- GitHub: [@ahmedriyad20](https://github.com/ahmedriyad20)

## 🙏 Acknowledgments

Built as part of a technical assessment demonstrating:
- Clean Architecture principles
- CQRS pattern implementation
- RESTful API design
- Modern frontend development with Blazor
- Entity Framework Core best practices

---
