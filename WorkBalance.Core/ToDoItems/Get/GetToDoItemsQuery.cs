using MediatR;
using System.ComponentModel.DataAnnotations;
using WorkBalance.Core.Common;
using WorkBalance.Core.Models;

namespace WorkBalance.Core.ToDoItems.Get
{
    public class GetToDoItemsQuery : IRequest<BaseHandlerResult<ToDoItemModel[]>>
    {
        public bool? IsCompleted { get; set; }

        [Range(1, int.MaxValue)]
        public int? PriorityId { get; set; }

        [Range(1, int.MaxValue)]
        public int? UserId { get; set; }
    }
}
