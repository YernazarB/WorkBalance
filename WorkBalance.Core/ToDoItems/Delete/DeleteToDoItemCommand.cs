using MediatR;
using System.ComponentModel.DataAnnotations;
using WorkBalance.Core.Common;

namespace WorkBalance.Core.ToDoItems.Delete
{
    public class DeleteToDoItemCommand : IRequest<BaseHandlerResult>
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}
