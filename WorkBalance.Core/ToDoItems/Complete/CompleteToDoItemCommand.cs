using MediatR;
using System.ComponentModel.DataAnnotations;
using WorkBalance.Core.Common;

namespace WorkBalance.Core.ToDoItems.Complete
{
    public class CompleteToDoItemCommand : IRequest<BaseHandlerResult>
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}
