# User Management API

An ASP.NET Core Web API for managing users using CRUD operations.

## Technologies

- C#
- ASP.NET Core
- .NET 10
- OpenAPI
- GitHub
- Microsoft Copilot

## Features

- Get all users
- Get a user by ID
- Create a user
- Update a user
- Delete a user
- Input validation
- Duplicate email prevention
- Error handling middleware
- Authentication middleware
- Request logging middleware

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/users` | Get all users |
| GET | `/api/users/{id}` | Get user by ID |
| POST | `/api/users` | Create a user |
| PUT | `/api/users/{id}` | Update a user |
| DELETE | `/api/users/{id}` | Delete a user |

## Validation

The API validates:

- Required user fields
- Name length
- Email format
- Department length
- Duplicate email addresses

Invalid requests return `400 Bad Request`, while duplicate email addresses return `409 Conflict`.

## Middleware

The application includes:

1. Error handling middleware
2. Authentication middleware
3. Request logging middleware

The middleware is configured in the required order in `Program.cs`.

Authentication uses a Bearer token for this educational demonstration.

## Testing

The API was tested using `curl`.

Examples of tested scenarios:

- Successful GET request → `200 OK`
- Successful POST request → `201 Created`
- Invalid POST/PUT data → `400 Bad Request`
- Duplicate email → `409 Conflict`
- Missing user → `404 Not Found`
- Missing authentication token → `401 Unauthorized`
- Invalid authentication token → `401 Unauthorized`
- Valid authentication token → `200 OK`
- Request/response logging verified in the terminal

## Microsoft Copilot

Microsoft Copilot was used during development to:

- Review the CRUD implementation
- Identify missing input validation
- Identify duplicate-email handling requirements
- Improve HTTP response handling
- Assist with debugging
- Create and configure middleware
- Review the API pipeline

## Project Structure

```text
UserManagementAPI/
├── Controllers/
│   └── UsersController.cs
├── Models/
│   └── User.cs
├── Middleware/
│   ├── ErrorHandlingMiddleware.cs
│   ├── AuthenticationMiddleware.cs
│   └── RequestLoggingMiddleware.cs
├── Program.cs
└── UserManagementAPI.csproj
