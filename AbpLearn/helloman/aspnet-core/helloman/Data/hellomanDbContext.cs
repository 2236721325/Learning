using helloman.Services;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;


namespace helloman.Data;

public class hellomanDbContext : AbpDbContext<hellomanDbContext>
{
    public hellomanDbContext(DbContextOptions<hellomanDbContext> options)
        : base(options)
    {
    }
    public DbSet<Item>  Items { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

   
        /* Configure your own entities here */
    }
}
