using LightAbp.Models;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace LightAbp.Datas
{
    //[ConnectionStringName("Default")]
    public class MyDbContext : AbpDbContext<MyDbContext>
    {
        //...在这里添加 DbSet properties
        public DbSet<Book> Books { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }
    }
}
