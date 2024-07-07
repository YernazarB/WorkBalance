using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkBalance.Core.ToDoItems.AssignUser;
using WorkBalance.Core.ToDoItems.Complete;
using WorkBalance.Core.ToDoItems.Create;
using WorkBalance.Core.ToDoItems.Delete;
using WorkBalance.Core.ToDoItems.Get;
using WorkBalance.Core.ToDoItems.Update;

namespace WorkBalance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : BaseController
    {
        public ToDoItemsController(IMediator mediator, ILogger<ToDoItemsController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetToDoItemsQuery query)
        {
            var result = await Mediator.Send(query);

            return GetResponse(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateToDoItemCommand command)
        {
            var result = await Mediator.Send(command);

            return GetResponse(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateToDoItemCommand command)
        {
            var result = await Mediator.Send(command);

            return GetResponse(result);
        }

        [HttpPatch]
        [Route("complete")]
        public async Task<IActionResult> Complete(CompleteToDoItemCommand command)
        {
            var result = await Mediator.Send(command);

            return GetResponse(result);
        }

        [HttpPatch]
        [Route("assign")]
        public async Task<IActionResult> Assign(AssignUserCommand command)
        {
            var result = await Mediator.Send(command);

            return GetResponse(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteToDoItemCommand command)
        {
            var result = await Mediator.Send(command);

            return GetResponse(result);
        }
    }
}
