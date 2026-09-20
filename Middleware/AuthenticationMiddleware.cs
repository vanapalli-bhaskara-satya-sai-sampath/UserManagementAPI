namespace UserManagementAPI.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        // Classroom/demo token only — not suitable for production
        private const string ValidToken = "my-secret-token";

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value ?? "";

            // Allow the OpenAPI document to be accessed without authentication
            if (path.StartsWith("/openapi"))
            {
                await _next(context);
                return;
            }

            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrEmpty(authHeader) ||
                !authHeader.StartsWith("Bearer "))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                await context.Response.WriteAsJsonAsync(new
                {
                    error = "Unauthorized. Please provide a valid Bearer token."
                });

                return;
            }

            var token = authHeader.Substring("Bearer ".Length).Trim();

            if (token != ValidToken)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                await context.Response.WriteAsJsonAsync(new
                {
                    error = "Invalid token."
                });

                return;
            }

            await _next(context);
        }
    }
}