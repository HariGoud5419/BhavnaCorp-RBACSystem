namespace RBACSystem.Core.Utilities
{
    /// <summary>
    /// Standard API Response wrapper for all endpoints.
    /// </summary>
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public ApiResponse() { }

        public ApiResponse(bool success, string message, T? data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public static ApiResponse<T> SuccessResponse(string message, T? data = default) =>
            new(true, message, data);

        public static ApiResponse<T> Failure(string message) =>
            new(false, message, default);
    }
}
