using Microsoft.EntityFrameworkCore;
using SmartLock.Models.User;

namespace SmartLock.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> users {get; set;}

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    } 
}