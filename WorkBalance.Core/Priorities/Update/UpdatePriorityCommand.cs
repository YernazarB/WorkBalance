using MediatR;
using System.ComponentModel.DataAnnotations;
using WorkBalance.Core.Common;
using WorkBalance.Core.Models;

namespace WorkBalance.Core.Priorities.Update
{
    public class UpdatePriorityCommand : IRequest<BaseHandlerResult<PriorityModel>>
    {
        [Range(1, int.MaxValue)]
        public int Id {  get; set; }

        [Range(0, int.MaxValue)]
        public int Level { get; set; }
    }
}
