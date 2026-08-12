namespace Day1WebApi.Data;

public record ApiResponse<T>(int StatusCode,
    string Message,
    T? Data);