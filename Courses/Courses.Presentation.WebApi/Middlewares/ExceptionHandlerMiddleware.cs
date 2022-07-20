namespace Courses.Presentation.WebApi.Middlewares
{
    using System.Text.Json;
    using Courses.Core.Contracts.Exceptions;

    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                var response = httpContext.Response;
                response.ContentType = "application/json";

                response.StatusCode = exception switch
                {
                    InvalidValueException _ => StatusCodes.Status422UnprocessableEntity,
                    _ => StatusCodes.Status500InternalServerError
                };

                if (response.StatusCode == StatusCodes.Status500InternalServerError)
                {
                    _logger.LogError(exception, "Internal server error with message: {error}", exception.Message);
                }
                else
                {
                    _logger.LogError("Request failed with message: {error}", exception.Message);
                }

                var result = JsonSerializer.Serialize(new { message = exception?.Message });

                await response.WriteAsync(result);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
