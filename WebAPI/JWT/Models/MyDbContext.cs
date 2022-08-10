using Microsoft.EntityFrameworkCore;

namespace JWT.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserInfo>(et =>
            {
                et.Property(t => t.UserName).HasMaxLength(24);
                et.Property(t => t.UserPwd).HasMaxLength(32);
                et.Property(t => t.Name).HasMaxLength(12);
                et.Ignore(t => t.TempPwd);
            });
        }
        public DbSet<UserInfo> UserInfos { get; set; }
    }
}
