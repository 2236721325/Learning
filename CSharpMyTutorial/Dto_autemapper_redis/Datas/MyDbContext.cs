using Dto_autemapper_redis.Models;
using Microsoft.EntityFrameworkCore;

namespace Dto_autemapper_redis.Datas
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{


        //}
        public DbSet<User> Users { get; set; }
    }
}

