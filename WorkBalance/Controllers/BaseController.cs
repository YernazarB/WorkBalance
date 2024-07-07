using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkBalance.Core.Common;

namespace WorkBalance.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMediator Mediator;
        protected readonly ILogger Logger;

        protected BaseController(IMediator mediator, ILogger logger)
        {
            Mediator = mediator;
            Logger = logger;
        }

        protected IActionResult GetResponse(BaseHandlerResult result)
        {
            if (result.Success)
            {
                return Ok(result);
            }
            
            if (result.ErrorCode.HasValue && result.ErrorCode.Value == HandlerErrorCode.NotFound)
            {
                return NotFound(result);
            }

            return BadRequest(result);
        }

        protected IActionResult GetResponse<T>(BaseHandlerResult<T> result) where T : class
        {
            var baseResult = result as BaseHandlerResult;
            return GetResponse(baseResult);
        }
    }
}
