namespace proj1.Dtos.CustomResponseDtos
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public string? Message { get; set; }
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public ApiResponse(T? data, string? message, bool success, int statusCode)
        {
            Data = data;
            Message = message;
            Success = success;
            StatusCode = statusCode;
        }
        public ApiResponse()
        {
            
        }
    }
   
}
