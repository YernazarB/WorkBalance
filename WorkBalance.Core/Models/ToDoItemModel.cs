using WorkBalance.Domain.Entities;

namespace WorkBalance.Core.Models
{
    public class ToDoItemModel
    {
        private ToDoItemModel()
        {
        }

        public int Id { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public bool IsCompleted { get; private set; }
        public DateTime DueDate { get; private set; }
        public int PriorityId { get; private set; }
        public int? UserId { get; private set; }

        public static ToDoItemModel Create(ToDoItem item)
        {
            return new ToDoItemModel
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                IsCompleted = item.IsCompleted,
                DueDate = item.DueDate,
                PriorityId = item.PriorityId,
                UserId = item.UserId
            };
        }
    }
}
