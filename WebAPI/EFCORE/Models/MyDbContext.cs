using Microsoft.EntityFrameworkCore;

namespace EFCORE.Models
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }

    }
}
