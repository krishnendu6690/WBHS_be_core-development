//// ==========================================================
//// ApiResponse<T>
//// Purpose: Standard API response wrapper
//// ==========================================================

//namespace WBHealthScheme.Domain.Common;

//public class ApiResponse<T>
//{
//    public bool Success { get; set; }

//    public string Message { get; set; } = string.Empty;

//    public string? Status { get; set; }

//    public T? Data { get; set; }

//    public List<string>? Errors { get; set; }
//}

namespace WBHealthScheme.Domain.Common;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public string? Status { get; set; }
    public T? Data { get; set; }
    public List<string>? Errors { get; set; }

    public static ApiResponse<T> Ok(T data, string message = "Success")
    {
        return new ApiResponse<T>
        {
            Success = true,
            Message = message,
            Status = "200",
            Data = data
        };
    }

    public static ApiResponse<T> Fail(string message, List<string>? errors = null)
    {
        return new ApiResponse<T>
        {
            Success = false,
            Message = message,
            Status = "500",
            Errors = errors
        };
    }
}