using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkBalance.Core.Users.Create;
using WorkBalance.Core.Users.Delete;
using WorkBalance.Core.Users.Get;
using WorkBalance.Core.Users.Update;

namespace WorkBalance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        public UsersController(IMediator mediator, ILogger<UsersController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetUsersQuery();
            var result = await Mediator.Send(query);

            return GetResponse(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var result = await Mediator.Send(command);

            return GetResponse(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserCommand command)
        {
            var result = await Mediator.Send(command);

            return GetResponse(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteUserCommand command)
        {
            var result = await Mediator.Send(command);

            return GetResponse(result);
        }
    }
}
