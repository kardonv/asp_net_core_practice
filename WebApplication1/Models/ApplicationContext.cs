using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<TodoItemViewModel> TodoItems { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=DESKTOP-GQ77IKA;Initial Catalog=app;Encrypt=False;Integrated Security=True;");
        }
    }
}
