using Microsoft.EntityFrameworkCore;
using Secord_API.Models;

namespace Secord_API.DbContexts
{
    public class FirstDbContext:DbContext
    {
        public DbSet<FirstEntity> FirstEntities { get; set; }
        public FirstDbContext(DbContextOptions<FirstDbContext> options):base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
