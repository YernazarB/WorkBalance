﻿namespace WorkBalance.Domain.Entities
{
    public class ToDoItem : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }

        public int PriorityId { get; set; }
        public Priority? Priority { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
