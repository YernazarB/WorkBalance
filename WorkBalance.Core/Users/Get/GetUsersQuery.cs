using MediatR;
using WorkBalance.Core.Common;
using WorkBalance.Core.Models;

namespace WorkBalance.Core.Users.Get
{
    public class GetUsersQuery : IRequest<BaseHandlerResult<UserModel[]>>
    {
    }
}
