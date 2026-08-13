namespace proj1.Core
{
    public class ServiceResult<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public int StatusCode { get; set; }

        public  static ServiceResult<T> SuccessResult(T data, int statusCode = StatusCodes.Status200OK)
        {
            return new ServiceResult<T>
            {
                Success = true,
                Data = data,
                StatusCode = statusCode
            };
        }

        public static ServiceResult<T> FailResult(string message, int statusCode = StatusCodes.Status400BadRequest)
        {
            return new ServiceResult<T>
            {
                Success = false,
                Data = default,
                Message = message,
                StatusCode = statusCode
            };
        }
        public ServiceResult(T? data, string? message, bool success, int statusCode)
        {
            Data = data;
            Message = message;
            Success = success;
            StatusCode = statusCode;
        }
        public ServiceResult()
        {
            
        }
    }
}
