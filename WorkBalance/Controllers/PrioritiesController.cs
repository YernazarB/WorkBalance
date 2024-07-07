using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkBalance.Core.Priorities.Create;
using WorkBalance.Core.Priorities.Delete;
using WorkBalance.Core.Priorities.Get;
using WorkBalance.Core.Priorities.Update;

namespace WorkBalance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrioritiesController : BaseController
    {
        public PrioritiesController(IMediator mediator, ILogger<PrioritiesController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetPrioritiesQuery();
            var result = await Mediator.Send(query);

            return GetResponse(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePriorityCommand command)
        {
            var result = await Mediator.Send(command);

            return GetResponse(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePriorityCommand command)
        {
            var result = await Mediator.Send(command);

            return GetResponse(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeletePriorityCommand command)
        {
            var result = await Mediator.Send(command);

            return GetResponse(result);
        }
    }
}
