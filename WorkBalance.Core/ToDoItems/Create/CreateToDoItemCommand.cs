using MediatR;
using System.ComponentModel.DataAnnotations;
using WorkBalance.Core.Common;
using WorkBalance.Core.Models;

namespace WorkBalance.Core.ToDoItems.Create
{
    public class CreateToDoItemCommand : IRequest<BaseHandlerResult<ToDoItemModel>>
    {
        [Required]
        [MinLength(1)]
        public string? Title { get; set; }

        [Required]
        [MinLength(1)]
        public string? Description { get; set; }

        // TODO: consider using FluentValidator to validate complex bussines logics like DueDate
        public DateTime DueDate { get; set; }

        [Range(1, int.MaxValue)]
        public int PriorityId { get; set; }
    }
}
