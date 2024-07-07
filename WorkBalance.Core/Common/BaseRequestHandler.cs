using MediatR;
using Microsoft.Extensions.Logging;
using WorkBalance.DataAccess;

namespace WorkBalance.Core.Common
{
    public abstract class BaseRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected readonly AppDbContext DbContext;
        protected readonly ILogger Logger;

        protected BaseRequestHandler(AppDbContext dbContext, ILogger logger)
        {
            DbContext = dbContext;
            Logger = logger;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

        public static BaseHandlerResult SuccessResult() => BaseHandlerResult.SuccessResult();
        public static BaseHandlerResult ErrorResult(HandlerErrorCode errorCode, string errorMessage)
            => BaseHandlerResult.ErrorResult(errorCode, errorMessage);

        public static BaseHandlerResult<T> SuccessResult<T>(T data) where T : class
        {
            return BaseHandlerResult<T>.SuccessResult(data);
        }

        public static BaseHandlerResult<T> ErrorResult<T>(HandlerErrorCode errorCode, string errorMessage) where T : class
        {
            return BaseHandlerResult<T>.ErrorResult(errorCode, errorMessage);
        }
    }
}
