namespace WorkBalance.Domain.Entities
{
    public class Priority : BaseEntity
    {
        public Priority()
        {
            ToDoItems = new HashSet<ToDoItem>();
        }

        public int Level { get; set; }
        public ICollection<ToDoItem> ToDoItems { get; set; }
    }
}
