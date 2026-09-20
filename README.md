# User Management API

A backend development mini project built using **ASP.NET Core, C#, .NET 10, and Microsoft Copilot**.

This project demonstrates how to build, debug, validate, secure, test, and document a RESTful Web API for managing users.

---

## 📌 Project Overview

The **User Management API** is an ASP.NET Core Web API that provides CRUD operations for managing users.

The project was developed as a practical backend development exercise covering:

- REST API development
- CRUD operations
- Input validation
- Error handling
- Authentication
- Request logging
- Middleware
- API testing
- Debugging with Microsoft Copilot
- Git and GitHub
- API documentation

For this educational project, user data is stored in an in-memory collection instead of a database.

---

## 🎯 Project Objectives

The main objectives of this project were:

1. Create an ASP.NET Core Web API.
2. Implement CRUD operations for users.
3. Use Microsoft Copilot for development and debugging.
4. Validate user input.
5. Handle invalid and missing data correctly.
6. Prevent duplicate email addresses.
7. Implement custom middleware.
8. Add basic authentication.
9. Add request and response logging.
10. Test the API using `curl`.
11. Manage and document the project using GitHub.

---

## 🛠️ Technologies Used

| Technology | Purpose |
|---|---|
| C# | Programming language |
| ASP.NET Core | Web API framework |
| .NET 10 | Application framework/runtime |
| OpenAPI | API documentation |
| Microsoft Copilot | Development and debugging assistance |
| curl | API testing |
| Git | Version control |
| GitHub | Source-code hosting |
| Visual Studio / VS Code | Development environment |

---

# 📂 Project Structure

```text
UserManagementAPI/
│
├── Controllers/
│   └── UsersController.cs
│
├── Models/
│   └── User.cs
│
├── Middleware/
│   ├── ErrorHandlingMiddleware.cs
│   ├── AuthenticationMiddleware.cs
│   └── RequestLoggingMiddleware.cs
│
├── Program.cs
├── UserManagementAPI.csproj
└── README.md
