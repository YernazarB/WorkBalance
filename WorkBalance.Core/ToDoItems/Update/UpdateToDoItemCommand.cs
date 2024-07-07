using System.ComponentModel.DataAnnotations;
using WorkBalance.Core.ToDoItems.Create;

namespace WorkBalance.Core.ToDoItems.Update
{
    public class UpdateToDoItemCommand : CreateToDoItemCommand
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}
