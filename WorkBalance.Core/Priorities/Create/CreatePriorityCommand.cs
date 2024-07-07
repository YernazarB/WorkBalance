using MediatR;
using System.ComponentModel.DataAnnotations;
using WorkBalance.Core.Models;

namespace WorkBalance.Core.Priorities.Create
{
    public class CreatePriorityCommand : IRequest<BaseHandlerResult<PriorityModel>>
    {
        [Range(0, int.MaxValue)]
        public int Level { get; set; }
    }
}
