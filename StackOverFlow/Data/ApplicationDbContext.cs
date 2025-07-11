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
    }
}
