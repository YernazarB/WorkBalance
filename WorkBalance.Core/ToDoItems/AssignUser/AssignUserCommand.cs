using MediatR;
using System.ComponentModel.DataAnnotations;
using WorkBalance.Core.Common;

namespace WorkBalance.Core.ToDoItems.AssignUser
{
    public class AssignUserCommand : IRequest<BaseHandlerResult>
    {
        [Range(1, int.MaxValue)]
        public int ToDoItemId { get; set; }

        [Range(1, int.MaxValue)]
        public int UserId { get; set; }
    }
}
