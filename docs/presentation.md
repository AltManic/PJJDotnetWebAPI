# Release and Deployment
## Wrap Response API
### Respons Berhasil
#### Satu Objek

```
{
  "statusCode": 200,
  "message": "Request successful",
  "data": {
    ...
  }
}
```


#### Array Objek

```
{
  "statusCode": 200,
  "message": "Request successful",
  "data": [
     {
        ...    
     }         
  ]  
}
```
#### Respons Gagal
```
{
  "statusCode": 400,
  "message": "Request failed",
}
```
#### Respons Tidak Ditemukan
```
{
  "statusCode": 404,
  "message": "Data not found",
}
```
#### Model Respons API
```
namespace Day1WebApi.Data;

public record ApiResponse<T>(
    int StatusCode,
    string Message,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    T? Data);
```

#### Wrap Respons API Otomatis
```
using Day1WebApi.Data;
using Microsoft.AspNetCore.Mvc.Filters;

public class WrapResponseFilter : IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (context.Result is ObjectResult objectResult)
        {
            var statusCode = objectResult.StatusCode ?? 200;
            object? data = objectResult.Value;

            if (objectResult.Value is ProblemDetails)
            {
                data = null;
            }

            if (statusCode >= 200 && statusCode < 300)
            {
                objectResult.Value = new ApiResponse<object>(statusCode, "Request successful", data);
            }
            else if (statusCode == 404)
            {
                objectResult.Value = new ApiResponse<object>(statusCode, "Data not found", data);
            }
            else if (statusCode >= 400)
            {
                objectResult.Value = new ApiResponse<object>(statusCode, "Request failed", data);
            }
        }

        await next();
    }
}
```
#### Pagination Response
```
public class PaginationResponse<T>
{
    public int Total { get; set; }
    public List<T> Items { get; set; }
}
```