using Microsoft.EntityFrameworkCore;
using StackOverFlow.Models;

namespace StackOverFlow.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users
        {
            get; set;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(new User
            {
                UsernameId = 1,
                Firstname = "Admin",
                LastName = "User",
                Email = "admin@gmail.com",
                Password = "admin123",
                Role = "Admin"
            });

        }
    }
}
