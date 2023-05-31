using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Entities;

namespace WebApp.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        private string connectionString;
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(this.connectionString);
        }
    }
}
