using MediatR;
using WorkBalance.Core.Common;
using WorkBalance.Core.Models;

namespace WorkBalance.Core.Priorities.Get
{
    public class GetPrioritiesQuery : IRequest<BaseHandlerResult<PriorityModel[]>>
    {
    }
}
