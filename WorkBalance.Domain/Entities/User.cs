namespace WorkBalance.Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            ToDoItems = new HashSet<ToDoItem>();
        }

        public string? Name { get; set; }
        public ICollection<ToDoItem> ToDoItems { get; set; }
    }
}
