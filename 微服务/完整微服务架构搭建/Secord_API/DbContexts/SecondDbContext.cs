using Microsoft.EntityFrameworkCore;
using Secord_API.Models;

namespace Secord_API.DbContexts
{
    public class SecondDbContext:DbContext
    {
        public DbSet<SecondEntity> SecondEntities { get; set; }
        public SecondDbContext(DbContextOptions<SecondDbContext> options):base(options)
        {
            this.Database.EnsureCreated();

        }
    }
}
