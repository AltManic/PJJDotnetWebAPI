using Day1WebApi.Data;
using Microsoft.AspNetCore.Diagnostics;

namespace Day1WebApi.ExceptionHandlers;

public class GlobalExceptionHandlers : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var response = new ApiResponse<object?>(500, "Internal server error", null);
        httpContext.Response.StatusCode = 500;
        httpContext.Response.ContentType = "application/json";
        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
        return true;
    }
}