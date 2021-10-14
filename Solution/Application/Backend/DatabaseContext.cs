using Microsoft.EntityFrameworkCore;

namespace SmartLock.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    } 
}