using MediatR;
using System.ComponentModel.DataAnnotations;
using WorkBalance.Core.Models;

namespace WorkBalance.Core.Priorities.Delete
{
    public class DeletePriorityCommand : IRequest<BaseHandlerResult>
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}
