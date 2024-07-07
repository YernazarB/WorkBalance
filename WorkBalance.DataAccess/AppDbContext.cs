using Microsoft.EntityFrameworkCore;
using WorkBalance.Domain.Entities;

namespace WorkBalance.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }  
    }
}
