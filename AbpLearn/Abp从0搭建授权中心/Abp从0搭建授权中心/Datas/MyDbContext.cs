using Abp从0搭建授权中心.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Abp从0搭建授权中心.Datas
{
    [ConnectionStringName("Default")]
    public class MyDbContext : AbpDbContext<MyDbContext>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserRole>(e =>
            {
                e.HasKey(p => new { p.UserId, p.RoleId });
            });
            builder.Entity<RolePermission>(e =>
            {
                e.HasKey(p => new { p.RoleId, p.PermissionId });
            });
            
        }
    }
}
