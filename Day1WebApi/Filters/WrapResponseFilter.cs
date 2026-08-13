using Day1WebApi.Data;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Day1WebApi.Filters;

public class WrapResponseFilter : IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (context.Result is ObjectResult objectResult)
        {
            int statusCode = objectResult.StatusCode ?? 200;
            object? value = objectResult.Value;

            if (statusCode >= 200 && statusCode < 300)
            {
                var response = new ApiResponse<object?>(statusCode, "Request successful", value);
                objectResult.Value = response;
            }
            else if (statusCode == 404)
            {
                var response = new ApiResponse<object?>(statusCode, "Data not found", null);
                objectResult.Value = response;
            }
            else if (statusCode >= 400)
            {
                var response = new ApiResponse<object?>(statusCode, "Request failed", value);
                objectResult.Value = response;
            }
        }

        await next();
    }
}