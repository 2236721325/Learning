using EmptyWebAbp.Models;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EmptyWebAbp.Datas
{
    public class MyDbContext : AbpDbContext<MyDbContext>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
