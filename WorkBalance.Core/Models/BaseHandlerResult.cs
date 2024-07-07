namespace WorkBalance.Core.Models
{
    public class BaseHandlerResult
    {
        public bool Success { get; set; }
        public HandlerErrorCode? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }

        public static BaseHandlerResult SuccessResult() => new() { Success = true };
        public static BaseHandlerResult ErrorResult(HandlerErrorCode errorCode, string errorMessage) => 
            new() { ErrorCode = errorCode, ErrorMessage = errorMessage };
    }

    public class BaseHandlerResult<T> : BaseHandlerResult where T : class
    {
        public T? Data { get; set; }

        public static BaseHandlerResult<T> SuccessResult(T data)
        {
            return new() 
            { 
                Success = true, 
                Data = data 
            };
        }

        public static new BaseHandlerResult<T> ErrorResult(HandlerErrorCode errorCode, string errorMessage)
        {
            return new() 
            { 
                ErrorCode = errorCode, 
                ErrorMessage = errorMessage
            };
        }
    }
}
