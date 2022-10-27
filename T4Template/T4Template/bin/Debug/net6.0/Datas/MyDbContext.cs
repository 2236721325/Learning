
using Microsoft.EntityFrameworkCore;

namespace T4CodeGenerator
{
    public class MyDbContext : DbContext
    {
        public DbSetUser Users { get; set; }
        public DbSetHello Hellos { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }




    }
}
