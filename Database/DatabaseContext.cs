using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Models;

namespace WebApiTemplate.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt)
        {
            
        }

        public DbSet<Command> Commands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Password> Passwords { get; set; }
    }
}