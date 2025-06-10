using Microsoft.EntityFrameworkCore;

namespace WebApiApp01.Models
{
    public class DbCtx : DbContext
    {
        public DbSet<TodoItem> TodoItems => Set<TodoItem>();

        public DbCtx(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().ToTable("TodoItem");
            modelBuilder.Entity<TodoItem>().HasKey(t => t.Id);
        }
    }
}
