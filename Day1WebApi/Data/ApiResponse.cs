using System.Text.Json.Serialization;

namespace Day1WebApi.Data;

public record ApiResponse<T>(int StatusCode,
    string Message,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    T? Data);