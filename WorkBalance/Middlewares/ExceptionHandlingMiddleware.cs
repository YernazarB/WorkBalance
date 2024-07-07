using System.Net;
using WorkBalance.Core.Common;

namespace WorkBalance.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = BaseHandlerResult.ErrorResult(HandlerErrorCode.InternalServerError, 
                "An error occurred on the server side. Please try again later ...");

            _logger.LogError($"Excpion was thrown, path: {context.Request.Path}, " +
                $"errorMessage: {exception.InnerException?.Message ?? exception.Message}");

            await context.Response.WriteAsJsonAsync(result);
        }
    }
}
