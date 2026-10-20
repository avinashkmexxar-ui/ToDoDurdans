using Shared.DTOs;

namespace API.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next; 
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next; 
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = exception switch
            {
                HttpRequestException => StatusCodes.Status502BadGateway,
                ArgumentException => StatusCodes.Status400BadRequest,
                KeyNotFoundException => StatusCodes.Status404NotFound,
                InvalidOperationException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };
            context.Response.StatusCode = code;
            await context.Response.WriteAsJsonAsync(ResponseDto<object>.Fail(code, exception.Message));

        }
    }
}
