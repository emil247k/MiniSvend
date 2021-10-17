using Microsoft.EntityFrameworkCore;
using SmartLock.Models;

namespace SmartLock.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<DbModel> Models {get; set;}
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    } 
}