using Microsoft.EntityFrameworkCore;
using SmartLock.Models.Users;
using SmartLock.Models.Locks;

namespace SmartLock.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> users {get; set;}
        public DbSet<Lock> locks {get; set;}

        public DbSet<LockMembers> lockMembers {get; set;}

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    } 
}