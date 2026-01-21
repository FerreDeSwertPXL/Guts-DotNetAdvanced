using Microsoft.EntityFrameworkCore;
using ToDoListApp.Domain;

namespace ToDoListApp.Infrastructure
{
    public class ToDoListContext : DbContext
    {
        public DbSet<ToDoList> ToDoLists { get; set; }

        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoList>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<ToDoList>()
                .HasMany(t => t.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ToDoItem>()
                .HasKey(i => i.Id);
        }
    }
}
